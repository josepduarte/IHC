using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }
        static form1 MsgBox; static DialogResult result = DialogResult.No;
        public static DialogResult Show(String title, String text, String caption, string btnOK, string btnCancel)
        {
            MsgBox = new form1();
            MsgBox.Text = title;
            MsgBox.label1.Text = text;
            MsgBox.button1.Text = btnOK;
            MsgBox.button2.Text = btnCancel;
            MsgBox.ShowDialog();
            return result;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            MsgBox.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void form1_Load(object sender, EventArgs e)
        {

        }
    }
}
