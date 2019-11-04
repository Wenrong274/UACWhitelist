using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UACWhitelist
{
    public partial class Form1 : Form
    {
        RegEditWhiteList regEditWhiteList = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = "EXE(*.EXE)|*.EXE|" + "所有檔案|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (regEditWhiteList == null)
            {
                MessageBox.Show("執行檔路徑錯誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (System.IO.File.Exists(regEditWhiteList.keyName))
            {
                regEditWhiteList.SendRegedit();
                MessageBox.Show("新增成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("執行檔路徑錯誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            regEditWhiteList = new RegEditWhiteList(textBox1.Text);
        }
    }
}
