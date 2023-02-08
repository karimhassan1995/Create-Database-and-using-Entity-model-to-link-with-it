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
               
            }
            foreach(Stock s1 in model.Stocks)
            {
                comboBox3.Items.Add(s1.Stock_Id);
            }
 
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            int STOCK_ID = int.Parse(comboBox1.Text);
            int ITEM_ID = int.Parse(comboBox2.Text);
            foreach (Supply_permission sp in model.Supply_permission)
            {
                if (sp.Stock_Id == STOCK_ID && sp.Item_Id == ITEM_ID)
                {
                    comboBox4.Items.Add(sp.Supplier_Id);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Stock_Item SI in model.Stock_Item)
            {
                
                    listBox1.Items.Add("The Stock with id = "+SI.Stock_id+" and name = "+SI.Stock.Stock_Name+" has an item with id = "+SI.Item_id+" and name = "+SI.Item.Item_Name+" and quantaty = " +SI.Quantity);
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            int STOCK_ID = int.Parse(comboBox1.Text);
            foreach (Stock_Item sp in model.Stock_Item)
            {
                if (sp.Stock_id == STOCK_ID)
                {
                    comboBox2.Items.Add(sp.Item_id);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispence_Permission dispence = new Dispence_Permission();
            Supply_permission newsupply = new Supply_permission();
            if (comboBox5.Text != "" && comboBox6.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox4.Text != "")
            {
                Supply_permission supply = null;
                foreach (Supply_permission sp in model.Supply_permission)
                {
                    if (sp.Stock_Id == int.Parse(comboBox1.Text) && sp.Item_Id == int.Parse(comboBox2.Text) && sp.Supplier_Id == int.Parse(comboBox4.Text) && sp.permission_Id == int.Parse(comboBox5.Text)  )
                    {
                        supply = sp;
                    }
                   
                }

                if (supply != null && int.Parse(textBox2.Text) <= int.Parse(comboBox6.Text) )
                {
                    dispence.Stock_Id = int.Parse(comboBox1.Text);
                    dispence.Item_Id = int.Parse(comboBox2.Text);
                    dispence.Supplier_Id = int.Parse(comboBox4.Text);
                    dispence.Permission_Id = int.Parse(textBox1.Text);
                    dispence.Quantity = int.Parse(textBox2.Text);
                    dispence.Permission_Date = DateTime.Now;
                    dispence.Production_Date = Convert.ToDateTime(supply.production_Date);
                    dispence.Expiary_Date = Convert.ToDateTime(supply.Expiray_Date);
                    model.Dispence_Permission.Add(dispence);
                    newsupply.Stock_Id = int.Parse(comboBox3.Text);
                    newsupply.Item_Id= int.Parse(comboBox2.Text);
                    newsupply.Supplier_Id= int.Parse(comboBox4.Text);
                    newsupply.permission_Id = int.Parse(textBox1.Text);
                    newsupply.Quantity = int.Parse(textBox2.Text);
                    newsupply.permission_Date = DateTime.Now;
                    newsupply.production_Date= Convert.ToDateTime(supply.production_Date);
                    newsupply.Expiray_Date = Convert.ToDateTime(supply.Expiray_Date);
                    model.Supply_permission.Add(newsupply);
                    model.SaveChanges();
                    comboBox4.Text = comboBox5.Text = comboBox6.Text = textBox2.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = textBox1.Text="";
                    MessageBox.Show("the transfer is completed");
                    listBox1.Items.Clear();
                    foreach (Stock_Item SI in model.Stock_Item)
                    {

                        listBox1.Items.Add("The Stock with id = " + SI.Stock_id + " and name = " + SI.Stock.Stock_Name + " has an item with id = " + SI.Item_id + " and name = " + SI.Item.Item_Name + " and quantaty = " + SI.Quantity);

                    }
                }
                else { MessageBox.Show("the Dispence permission is already existed"); }
            }
            else { MessageBox.Show("Fill all the Rexquired info"); }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            int STOCK_ID = int.Parse(comboBox1.Text);
            int ITEM_ID = int.Parse(comboBox2.Text);
            int SUPPLIER_ID = int.Parse(comboBox4.Text);
            foreach (Supply_permission sp in model.Supply_permission)
            {
                if (sp.Stock_Id == STOCK_ID && sp.Item_Id == ITEM_ID && sp.Supplier_Id == SUPPLIER_ID )
                {
                    comboBox5.Items.Add(sp.permission_Id);
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            int STOCK_ID = int.Parse(comboBox1.Text);
            int ITEM_ID = int.Parse(comboBox2.Text);
            int SUPPLIER_ID = int.Parse(comboBox4.Text);
            int PERMISSION_ID = int.Parse(comboBox5.Text);
            foreach (Supply_permission sp in model.Supply_permission)
            {
                if (sp.Stock_Id == STOCK_ID && sp.Item_Id == ITEM_ID && sp.Supplier_Id == SUPPLIER_ID && sp.permission_Id == PERMISSION_ID)
                {
                    comboBox6.Items.Add(sp.Quantity);
                }
            }
        }
    }
}
