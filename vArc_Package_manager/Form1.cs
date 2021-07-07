using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Threading;

namespace vArc_Package_manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
		private struct header
		{
			public char[] ID;

			public short version;

			public int fileCount;

			public int namesTableSize;
		}

		private struct info_table
		{
			public short nsize;

			public int size;

			public int zsize;

			public int offset;
		}

		public class Log
		{
			private delegate void SafeCallDelegate(TextBox tb, string text);

			private static TextBox mTextBox;

			public static void SetControl(TextBox tb)
			{
				mTextBox = tb;
			}

			public static void WriteLine(string message)
			{
				_ = Thread.CurrentThread;
				string text = (!string.IsNullOrEmpty(message)) ? message : "";
				if (mTextBox != null)
				{
					WriteTextSafe(mTextBox, text);
				}
			}

			private static void WriteTextSafe(TextBox tb, string text)
			{
				if (tb.InvokeRequired)
				{
					SafeCallDelegate method = WriteTextSafe;
					tb.Invoke(method, tb, text);
				}
				else
				{
					tb.AppendText(text + "\r\n");
				}
			}
		}

		private int mThreadCount;

		private Logger mLogger = new Logger();

		private Dictionary<string, int> mUnpackFiles = new Dictionary<string, int>();

		private Dictionary<string, int> mPackFiles = new Dictionary<string, int>();

		private void Form1_Load(object sender, EventArgs e)
		{
			Log.SetControl(mLogger.TextBox);
			listBox1.SelectionMode = SelectionMode.MultiExtended;
			listBox2.SelectionMode = SelectionMode.MultiExtended;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			mLogger.Show();
			BackgroundWorker backgroundWorker = new BackgroundWorker();
			backgroundWorker.WorkerReportsProgress = false;
			backgroundWorker.WorkerSupportsCancellation = false;
			backgroundWorker.DoWork += Unpack;
			backgroundWorker.RunWorkerAsync();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			mLogger.Show();
			BackgroundWorker backgroundWorker = new BackgroundWorker();
			backgroundWorker.WorkerReportsProgress = false;
			backgroundWorker.WorkerSupportsCancellation = false;
			backgroundWorker.DoWork += Pack;
			backgroundWorker.RunWorkerAsync();
		}

		private void Unpack(object sender, DoWorkEventArgs e)
		{
			try
			{
				if (mUnpackFiles.Count == 0)
				{
					//throw new Exception("必須加入 vArc 檔案來源");
					throw new Exception("Must specific vArc source path!");
				}
				/*
				if (string.IsNullOrEmpty(textBox2.Text))
				{
					throw new Exception("請輸入路徑");
				}
				*/
				List<string> files = (from o in mUnpackFiles.ToList()
					select o.Key).ToList();
				DisableUI();
				Unpack(textBox2.Text, files);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
            finally
            {
				EnableUI();
			}
		}

		private void Pack(object sender, DoWorkEventArgs e)
		{
			try
			{
				if (mPackFiles.Count == 0)
				{
					//throw new Exception("必須加入 fsb 或 fev 檔案來源");
					throw new Exception("Must added fsb / fev source!");
				}
				if (string.IsNullOrEmpty(textBox3.Text))
				{
					//throw new Exception("請輸入 Output 檔案路徑");
					throw new Exception("Must specific Output path!");
				}
				List<string> files = (from o in mPackFiles.ToList()
					select o.Key).ToList();
				DisableUI();
				Pack(textBox3.Text, files);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				EnableUI();
			}
		}

		private void Unpack(string outputFolder, List<string> files)
		{
			Log.WriteLine($"Unpack to \"{(string.IsNullOrWhiteSpace(outputFolder) ? Application.StartupPath : outputFolder )}\"");
			int num = 0;
			int count = files.Count;
			foreach (string file in files)
			{
				string varc_name = file.Split('\\').Last();
				string write_path = outputFolder;
				if (checkBox1.Checked)
				{
					write_path = checkBox2.Checked ? Path.Combine(outputFolder, varc_name.Split('.').First(), "Sounds") : write_path = Path.Combine(outputFolder, varc_name.Split('.').First());
					if (!Directory.Exists(write_path))
						Directory.CreateDirectory(write_path);
				}
				Log.WriteLine($"({++num}/{count}) Unpacking {varc_name}");
				using (FileStream input = new FileStream(file, FileMode.Open))
				{
					using (BinaryReader binaryReader = new BinaryReader(input))
					{
						new string(binaryReader.ReadChars(14));
						binaryReader.ReadInt16();
						int num2 = binaryReader.ReadInt32();
						binaryReader.ReadInt32();
						binaryReader.BaseStream.Seek(32L, SeekOrigin.Begin);
						int num3 = num2 * 14 + 32;
						for (int i = 0; i < num2; i++)
						{
							short num4 = binaryReader.ReadInt16();
							int num5 = binaryReader.ReadInt32();
							int num6 = binaryReader.ReadInt32();
							int num7 = binaryReader.ReadInt32();
							long position = binaryReader.BaseStream.Position;
							binaryReader.BaseStream.Seek(num3, SeekOrigin.Begin);
							string extract_name = new string(binaryReader.ReadChars(num4));
							num3 += num4 + 1;
							if (num5 == num6)
							{
								extract_name = extract_name.Split('/')[1];
								Log.WriteLine($"({num}/{count}) Unpacking {varc_name} - ({i + 1}/{num2}) {extract_name}");
								using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(Path.Combine(write_path, extract_name), FileMode.Create)))
								{
									binaryReader.BaseStream.Seek(num7, SeekOrigin.Begin);
									byte[] buffer = binaryReader.ReadBytes(num5);
									binaryWriter.Write(buffer);
								}
							}
							binaryReader.BaseStream.Seek(position, SeekOrigin.Begin);
						}
					}
				}
			}
			Log.WriteLine("Done.");
			Log.WriteLine("");
		}

		private void Pack(string outputFilename, List<string> files)
		{
			string arg = outputFilename.Split('\\').Last();
			Log.WriteLine($"Start building {arg}.");
			byte[] buffer = new byte[8];
			header header = default(header);
			header.ID = "VISIONPACKAGE\0".ToCharArray();
			header.version = 1;
			header.fileCount = files.Count;
			header.namesTableSize = 0;
			header header2 = header;
			List<info_table> list = new List<info_table>();
			List<byte[]> list2 = new List<byte[]>();
			string[] array = files.Select((string filename, int index) => $"Sounds/{filename.Split('\\').Last()}\0").ToArray();
			int num = 0;
			int num2 = array.Length * 14 + 32;
			string[] array2 = array;
			foreach (string text in array2)
			{
				num += text.Length;
			}
			header2.namesTableSize = num;
			int num3 = num2 + num;
			for (int j = 0; j < files.Count; j++)
			{
				using (FileStream fileStream = new FileStream(files[j], FileMode.Open))
				{
					using (BinaryReader binaryReader = new BinaryReader(fileStream))
					{
						byte[] item = binaryReader.ReadBytes(Convert.ToInt32(fileStream.Length));
						list2.Add(item);
					}
				}
				num3 += ((j > 0) ? list2[j - 1].Length : 0);
				info_table info_table = default(info_table);
				info_table.nsize = Convert.ToInt16(array[j].Length - 1);
				info_table.size = list2[j].Length;
				info_table.zsize = list2[j].Length;
				info_table.offset = num3;
				info_table item2 = info_table;
				list.Add(item2);
			}
			using (FileStream output = File.Create(outputFilename))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(output))
				{
					binaryWriter.Write(header2.ID);
					binaryWriter.Write(header2.version);
					binaryWriter.Write(header2.fileCount);
					binaryWriter.Write(header2.namesTableSize);
					binaryWriter.Write(buffer);
					foreach (info_table item3 in list)
					{
						binaryWriter.Write(item3.nsize);
						binaryWriter.Write(item3.size);
						binaryWriter.Write(item3.zsize);
						binaryWriter.Write(item3.offset);
					}
					binaryWriter.BaseStream.Seek(num2, SeekOrigin.Begin);
					array2 = array;
					foreach (string text2 in array2)
					{
						binaryWriter.Write(text2.ToCharArray());
					}
					foreach (byte[] item4 in list2)
					{
						binaryWriter.Write(item4);
					}
				}
			}
			Log.WriteLine($"Build {arg} finish.");
		}

		private void DisableUI()
		{
			this.InvokeIfRequired(() =>
			{
				tabControl1.Enabled = false;
			});
		}

		private void EnableUI()
		{
			this.InvokeIfRequired(() =>
			{
				tabControl1.Enabled = true;
			});
		}

		private void button4_Click(object sender, EventArgs e)
		{
			GetFileList("vArc files (*.vArc)|*.vArc", ref mUnpackFiles);
			SetFilesToListBox(listBox2, ref mUnpackFiles);
		}

		private void GetFileList(string filter, ref Dictionary<string, int> files)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Select files";
			openFileDialog.InitialDirectory = Application.StartupPath;
			openFileDialog.Filter = filter;
			openFileDialog.Multiselect = true;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			string[] fileNames = openFileDialog.FileNames;
			foreach (string key in fileNames)
			{
				if (!files.ContainsKey(key))
				{
					files.Add(key, 0);
				}
			}
		}

		private void SetFilesToListBox(ListBox lb, ref Dictionary<string, int> files)
		{
			lb.Items.Clear();
			lb.BeginUpdate();
			foreach (KeyValuePair<string, int> file in files)
			{
				lb.Items.Add(file.Key.ToString());
			}
			lb.EndUpdate();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			RemoveFilesFromListBox(listBox2, ref mUnpackFiles);
		}

		private void RemoveFilesFromListBox(ListBox lb, ref Dictionary<string, int> files)
		{
			List<string> list = new List<string>();
			foreach (object selectedItem in lb.SelectedItems)
			{
				list.Add(selectedItem as string);
			}
			foreach (string item in list)
			{
				lb.Items.Remove(item);
				files.Remove(item);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			GetFileList("FMOD files (*.fsb,*.fev)|*.fsb;*.fev", ref mPackFiles);
			SetFilesToListBox(listBox1, ref mPackFiles);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			RemoveFilesFromListBox(listBox1, ref mPackFiles);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "vArc files (*.vArc)|*.vArc";
			saveFileDialog.FileName = string.IsNullOrWhiteSpace(textBox3.Text) ? "Untitled" : textBox3.Text.Split('\\').Last();
			saveFileDialog.DefaultExt = "vArc";
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.RestoreDirectory = true;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				textBox3.Text = saveFileDialog.FileName;
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			listBox2.Items.Clear();
			mUnpackFiles.Clear();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
			mPackFiles.Clear();
		}

		private void button10_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.SelectedPath = string.IsNullOrWhiteSpace(textBox2.Text) ? "" : textBox2.Text;
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				textBox2.Text = folderBrowserDialog.SelectedPath;
			}
		}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBox1.Checked)
				checkBox2.Enabled = true;
			else
				checkBox2.Enabled = false;
		}
    }
}
//擴充方法
public static class Extension
{
	//非同步委派更新UI
	public static void InvokeIfRequired(
		this Control control, MethodInvoker action)
	{
		if (control.InvokeRequired)//在非當前執行緒內 使用委派
		{
			control.Invoke(action);
		}
		else
		{
			action();
		}
	}
}