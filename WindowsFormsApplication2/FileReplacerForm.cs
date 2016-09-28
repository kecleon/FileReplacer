using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
	public partial class FileReplacerForm : Form
	{
		public FileReplacerForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists(sourceTextBox.Text))
			{
				statusLabel.BackColor = Color.Red;
				statusLabel.Text = "Invalid Source Directory";
				return;
			}
			if (!Directory.Exists(sourceTextBox.Text))
			{
				statusLabel.BackColor = Color.Red;
				statusLabel.Text = "Invalid Update Directory";
				return;
			}
			int replacedCount = 0;
			statusLabel.BackColor = Color.LimeGreen;
			statusLabel.Text = "Directories OK";
			string[] srcFilenames = Directory.GetFiles(sourceTextBox.Text, "*" + extTextBox.Text, SearchOption.AllDirectories);
			string[] updFilenames = Directory.GetFiles(updateTextBox.Text, "*" + extTextBox.Text, SearchOption.AllDirectories);
			statusLabel.Text = srcFilenames.Length + " Source Files, " + updFilenames.Length + " Update Files";
			for(int x = 0; x < srcFilenames.Length; x++)
			{
				for(int y = 0; y < updFilenames.Length; y++)
				{
					string[] srcSplit = srcFilenames[x].Split('\\');
					string srcName = srcSplit[srcSplit.Length - 1];
					string[] updSplit = updFilenames[y].Split('\\');
					string updName = updSplit[updSplit.Length - 1];
					if(srcName == updName)
					{
						replacedCount++;
						File.Delete(srcFilenames[x]);
						File.Copy(updFilenames[y], srcFilenames[x]);
						statusLabel.Text = "Replaced " + srcName;
					}
				}
			}
			statusLabel.Text = "Replaced: " + replacedCount + " files";
		}
	}
}
