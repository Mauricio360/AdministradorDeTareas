using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administrador_de_Tareas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            actualizar();
        }



        public void actualizar()
        {
            listProcesos.Items.Clear();

            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                ListViewItem proc = new ListViewItem();

                proc.Text = p.ProcessName;
                proc.SubItems.Add(p.MainWindowTitle.ToString());
                proc.SubItems.Add(p.Id.ToString());
                proc.SubItems.Add(Math.Round(Convert.ToDouble(p.PrivateMemorySize64/1024))+" K");
                proc.SubItems.Add(Math.Round(Convert.ToDouble(p.VirtualMemorySize64 / 1024)) + " K");

                listProcesos.Items.Add(proc);
                proc = null;
            }

            lblcant.Text = listProcesos.Items.Count.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            actualizar();
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            if (listProcesos.SelectedItems.Count > 0)
            {
                ListViewItem d = listProcesos.SelectedItems[0];

                foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
                {
                    if(p.ProcessName== d.Text)
                    {
                        p.Kill();
                    }
                }
                actualizar();
            }
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            actualizar();
        }



        //---------------------------------------
    }
}
