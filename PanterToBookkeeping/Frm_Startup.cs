﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanterToBookkeeping
{
    public partial class Frm_Startup : Form
    {
        public Frm_Startup()
        {
            InitializeComponent();
        }

        private void Frm_Startup_Load(object sender, EventArgs e)
        {
            this.Show();
            this.ProgBar();
        }

        private void ProgBar()
        {
            var R = new Random();
            this.progressBar1.Value = this.progressBar1.Minimum;

            while (this.progressBar1.Value < this.progressBar1.Maximum)
            {
                Thread.Sleep(500);
                this.progressBar1.Value = R.Next(this.progressBar1.Value + 1, this.progressBar1.Maximum + 1);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Frm_Main FM = new Frm_Main();
            FM.Show();
            timer1.Enabled = false;
            this.Hide();
        }

    }
}
