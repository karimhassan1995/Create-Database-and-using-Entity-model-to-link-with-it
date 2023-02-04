using System;
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
    public partial class Stocks_Reports : Form
    {
        public Stocks_Reports()
        {
            InitializeComponent();
        }
        Model1 model = new Model1();
        private void Stocks_Reports_Load(object sender, EventArgs e)
        {
            foreach(Stock s in model.Stocks)
            {
                comboBox1.Items.Add(s.Stock_Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Supply_permission supply in model.Supply_permission)
            {
                if (supply.Stock.Stock_Name == comboBox1.Text && supply.permission_Date >= Convert.ToDateTime(textBox1.Text) && supply.permission_Date <= Convert.ToDateTime(textBox2.Text))
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add(supply.Stock.Stock_Name + " " + supply.Item.Item_Name);
                }
            }
        }
    }
}
