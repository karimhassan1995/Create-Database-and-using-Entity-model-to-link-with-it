using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Transfer : Form
    {
        public Transfer()
        {
            InitializeComponent();
        }
        Model1 model= new Model1();
        private void Transfer_Load(object sender, EventArgs e)
        {

            foreach(Stock_Item s in model.Stock_Item)
            {
                comboBox1.Items.Add(s.Stock_id );
                comboBox3.Items.Add(s.Stock_id);
            }
 
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Stock_Item SI in model.Stock_Item)
            {
                
                    listBox1.Items.Add(SI.Stock_id+" "+SI.Stock.Stock_Name+" "+SI.Item_id+" "+SI.Item.Item_Name+" " +SI.Quantity);
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            int STOCK_ID = int.Parse(comboBox1.Text);
            foreach (Stock_Item i in model.Stock_Item)
            {
                if (i.Stock_id == STOCK_ID)
                {
                    comboBox2.Items.Add(i.Item_id);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean qw = true;
            Boolean zero = false;
            Stock_Item deleted = new Stock_Item();
            int minus_Id = int.Parse(comboBox1.Text);
            int item_Id = int.Parse(comboBox2.Text);
            int plus_Id = int.Parse(comboBox3.Text);
            foreach (Stock_Item s in model.Stock_Item)
            {
                if(s.Stock_id == minus_Id)
                {
                   s.Quantity -= int.Parse(textBox1.Text);
                   if(s.Quantity <= 0)
                    {
                        zero = true;
                        deleted = s;
                    }
           
                }
                if(s.Stock_id == plus_Id)
                {
                    if(s.Item_id == item_Id)
                    {
                        s.Quantity += int.Parse(textBox1.Text);
                    }
                    else
                    {
                        qw = false;
                    }
                }
            }
            if (qw == false)
            {
                Stock_Item z = new Stock_Item();
                z.Stock_id = plus_Id;
                z.Item_id = item_Id;
                z.Quantity = int.Parse(textBox1.Text);
                model.Stock_Item.Add(z);
                model.SaveChanges();
                MessageBox.Show("kemo");
                qw = true;
               
            }
            if(zero == true)
            {
                model.Stock_Item.Remove(deleted);
                model.SaveChanges();
                zero = false ;
            }

        }
    }
}
