using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
                comboBox1.Items.Add(s.Stock_Id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime x = Convert.ToDateTime(textBox1.Text);
            DateTime y = Convert.ToDateTime(textBox2.Text);
            int r = int.Parse(comboBox1.Text);
           /* if (textBox1.Text != ""&& textBox2.Text != "")
            {
                 x 
                 y 
            }
            else {
                MessageBox.Show("reput the date");
            }*/
            var Stocks = (from sp in model.Supply_permission
                          join s in model.Stocks
                          on sp.Stock_Id equals s.Stock_Id
                          join si in model.Stock_Item
                          on s.Stock_Id equals si.Stock_id
                          join i in model.Items
                          on si.Item_id equals i.Item_Id
                          /* where sp.permission_Date >= DateTime.ParseExact(textBox1.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) && sp.permission_Date <= DateTime.ParseExact(textBox2.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture)*/
                          /*  where sp.permission_Date >= Convert.ToDateTime(textBox1.Text) && sp.permission_Date <= Convert.ToDateTime(textBox2.Text)*/
                          where sp.permission_Date >= x && sp.permission_Date <= y  && si.Stock_id == r
                          select new
                          {
                              Stock_ID = si.Stock_id,
                              Stock_Name = s.Stock_Name,
                              item_ID = si.Item_id,
                              Item_Name = i.Item_Name,
                              quantity = si.Quantity,
                              production_Date = sp.production_Date,
                              Expiary_Date = sp.Expiray_Date
                          });
            listBox1.Items.Clear();
            foreach (var stoc in Stocks)
            {
                listBox1.Items.Add(stoc.Stock_ID + " " + stoc.Stock_Name + " " + stoc.item_ID + " " + stoc.Item_Name+" "+stoc.quantity+" "+stoc.production_Date+" "+stoc.Expiary_Date);
            }
        }
    }
}
