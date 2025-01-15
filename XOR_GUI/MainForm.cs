using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XOR_GUI
{
    public partial class MainForm : Form
    {
        private static byte LionGameSecretByte = 0x55;
        private static bool flag = false;
        private delegate void SafeCallDelegate(string text);

        public MainForm()
        {
            InitializeComponent();

            // 設定執行緒池中的執行緒上限
            ThreadPool.SetMaxThreads(5, 5);
        }

        private void btn_XOR_Click(object sender, EventArgs e)
        {
            RunBackground();
        }

        private void Process(object sender, EventArgs e)
        {
            string iPath = tb_InputPath.Text;
            string oPath = tb_OutputPath.Text;
            var allFiles = Directory.GetFiles(iPath);
            allFiles = allFiles.Where(o => (o.IndexOf(".v") != -1)).ToArray();

            Object _lock = new Object();
            Object _memlock = new Object();
            long memoryUsage = 0;
            DoParallel(allFiles,
            (file) =>
            {
                long filesize = 0;
                string nfilename = Path.Combine(oPath, file.Split('\\').Last().Split('.')[0] + ".zip");
                using (FileStream fs = File.OpenRead(file))
                using (XorStream xoredStream = new XorStream(fs, LionGameSecretByte))
                using (BinaryWriter writer = new BinaryWriter(File.Open(nfilename, FileMode.Create)))
                {
                    lock(_lock)
                        //Progress($"開始處理 {nfilename}");
                        Progress($"Start process {nfilename}");
                    filesize = xoredStream.Length;

                    while (memoryUsage + filesize > 2000000000)
                        Thread.SpinWait(500);

                    lock (_memlock)
                        memoryUsage += filesize;

                    byte[] buff = new byte[xoredStream.Length];
                    xoredStream.Read(buff, 0, (int)xoredStream.Length);
                    writer.Write(buff, 0, (int)xoredStream.Length);

                    lock (_lock)
                        //Progress($"{nfilename} 處理完成");
                        Progress($"Process {nfilename} done.");
                }

                lock (_memlock)
                    memoryUsage -= filesize;

                GC.Collect();
            });

            //Progress($"全部處理完成");
            Progress($"All done.");
        }

        private delegate void FuncWork<T>(T item);

        private void DoParallel<T>(IEnumerable<T> args, FuncWork<T> func)
        {
            if (args.Count() == 0)
                return;

            using (var countdown = new MutipleThreadResetEvent(args.Count()))
            {
                foreach (var arg in args)
                {
                    var tmp1 = arg;
                    ThreadPool.QueueUserWorkItem(callBack =>
                    {
                        var tmp2 = tmp1;
                        func(tmp2);
                        countdown.SetOne();
                    });
                }
                countdown.WaitAll();
            }

        }

        private void RunBackground()
        {
            BackgroundWorker bw = new BackgroundWorker();
            //bw.WorkerReportsProgress = true;
            //bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(Process);
            //bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void Progress(string text)
        {
            if (tb_Log.InvokeRequired)
            {
                var d = new SafeCallDelegate(Progress);
                Invoke(d, new object[] { text });
            }
            else
            {
                tb_Log.AppendText(text + "\r\n");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tb_Log.ScrollBars = ScrollBars.Vertical;
        }

        private void btn_InputPath_Click(object sender, EventArgs e)
        {

        }

        private void btn_OutputPath_Click(object sender, EventArgs e)
        {

        }
    }
}
