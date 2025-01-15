using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vArc_Package_manager
{
	public partial class Logger : Form
	{
		public Logger()
		{
			InitializeComponent();
		}

		public TextBox TextBox => tb_Log;

		private void Logger_Load(object sender, EventArgs e)
		{
			tb_Log.ScrollBars = ScrollBars.Vertical;
		}

		private void Logger_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			Hide();
		}
	}
}
