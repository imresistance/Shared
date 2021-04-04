using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        Thread TThread = null;
        bool Stage = false;
        int a;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TThread == null)
                {
                    TThread = new Thread(new ThreadStart(system));
                    TThread.Start();
                    Stage = true;
                }
                else
                {
                    MessageBox.Show("Thread running");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void system()
        {
            while (Stage)
            {
                a++;
                label1.Invoke(new Action(() => label1.Text = a.ToString()));
                Thread.Sleep(200);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stage = false;
            TThread = null;
        }
    }
}
