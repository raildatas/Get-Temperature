using System;
using System.Windows.Forms;

namespace wdj
{
    public partial class ErrorForm : Form
    {
        public ErrorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text.Contains("市"))
                Share.city = comboBox1.Text.Substring(0,comboBox1.Text.Length - 1);
            else
                Share.city = comboBox1.Text;
            this.Close();
        }
        private void ErrorForm_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "广州市";
        }
    }
}