﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stocks s1 = new Stocks();
            DialogResult dResult = s1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Items i1 = new Items();
            DialogResult dialogResult= i1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Suppliers suppliers= new Suppliers();
            DialogResult dialogResult= suppliers.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Customers c1 = new Customers();
            DialogResult dialogResult= c1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Supply_Permissions sp = new Supply_Permissions();
            DialogResult dialogResult= sp.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dispence_Permissions dp = new Dispence_Permissions();
            DialogResult dialogResult= dp.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Transfer T = new Transfer();
            DialogResult dialogResult = T.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Stocks_Reports sr = new Stocks_Reports();
            DialogResult dialogResult= sr.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Items_Reports ir = new Items_Reports();
            DialogResult dialogResult= ir.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Items_Movement im = new Items_Movement();
            DialogResult dialogResult = im.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Knowing_Duration kn = new Knowing_Duration();
            DialogResult dialogResult= kn.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Expired_Items  EI = new Expired_Items();
            DialogResult dialogResult= EI.ShowDialog();
        }
    }
}
