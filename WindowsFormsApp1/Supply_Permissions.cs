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
    public partial class Supply_Permissions : Form
    {
        public Supply_Permissions()
        {
            InitializeComponent();
        }
        Model1 model = new Model1();
        private void Supply_Permissions_Load(object sender, EventArgs e)
        {
            foreach (Stock s in model.Stocks)
            {
                comboBox1.Items.Add(s.Stock_Id);
            }
            foreach (Item item in model.Items)
            {
                comboBox2.Items.Add(item.Item_Id);
            }
            foreach (Supplier s in model.Suppliers)
            {
                comboBox3.Items.Add(s.Supplier_Id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Supply_permission newsupply = new Supply_permission();
            if (textBox3 != null && textBox4 != null && textBox5 != null && comboBox1 != null && comboBox2 != null && comboBox3 != null)
            {
                Supply_permission supply = null;
                foreach (Supply_permission sp in model.Supply_permission)
                {
                    if (sp.Stock_Id == int.Parse(comboBox1.Text) && sp.Item_Id == int.Parse(comboBox2.Text) && sp.Supplier_Id == int.Parse(comboBox3.Text) && sp.permission_Id == int.Parse(textBox3.Text))
                    {
                        supply = sp;
                    }
                }
                if (supply == null)
                {
                    newsupply.Stock_Id = int.Parse(comboBox1.Text);
                    newsupply.Item_Id = int.Parse(comboBox2.Text);
                    newsupply.Supplier_Id = int.Parse(comboBox3.Text);
                    newsupply.permission_Id = int.Parse(textBox3.Text);
                    newsupply.Quantity = int.Parse(textBox4.Text);
                    newsupply.permission_Date = DateTime.Now;
                    newsupply.production_Date = Convert.ToDateTime(textBox5.Text);
                    newsupply.Expiray_Date = Convert.ToDateTime(textBox1.Text);
                    model.Supply_permission.Add(newsupply);
                    model.SaveChanges();
                    textBox1.Text = textBox3.Text = textBox4.Text = textBox5.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = "";
                }
                else { MessageBox.Show("thecustomer is already existed"); }
            }
            else { MessageBox.Show("Fill all the Rexquired info"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Item item = new Item();
            if (textBox2.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                Item i = model.Items.Find(int.Parse(textBox2.Text));
                if (i == null)
                {
                    item.Item_Id = int.Parse(textBox2.Text);
                    item.Item_Name = textBox6.Text;
                    Measuring_unit mu = new Measuring_unit();
                    mu.Item_Id = item.Item_Id;
                    mu.unit = textBox7.Text;
                    model.Items.Add(item);
                    model.Measuring_unit.Add(mu);
                    model.SaveChanges();
                    comboBox2.Items.Add(item.Item_Id);
                    textBox2.Text = textBox6.Text = textBox7.Text = "";
                }
                else { MessageBox.Show("The Item is already exist"); }
            }
            else { MessageBox.Show("Fill all the required Text boxes"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Supply_permission sp in model.Supply_permission)
            {
                listBox1.Items.Add(sp.Stock_Id + " " + sp.Item_Id +" "+ sp.Supplier_Id + " " + sp.permission_Id + " " + sp.Quantity + " " + sp.permission_Date + " " + sp.production_Date + " " + sp.Expiray_Date);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Supply_permission supply = null;
            foreach (Supply_permission sp in model.Supply_permission)
            {
                if (sp.Stock_Id == int.Parse(comboBox1.Text) && sp.Item_Id == int.Parse(comboBox2.Text) && sp.Supplier_Id == int.Parse(comboBox3.Text) && sp.permission_Id == int.Parse(textBox3.Text))
                {
                    supply = sp;
                }
            }
            if (supply != null)
            {
               
                supply.production_Date = Convert.ToDateTime(textBox5.Text);
                supply.Expiray_Date = Convert.ToDateTime(textBox1.Text);
                model.SaveChanges();
                MessageBox.Show("YOUR SUPPLU IS UPDATED");
                textBox1.Text = textBox3.Text = textBox4.Text = textBox5.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = "";
                listBox1.Items.Clear();
                foreach (Supply_permission sp in model.Supply_permission)
                {
                    listBox1.Items.Add(sp.Stock_Id + " " + sp.Item_Id + " " + sp.Supplier_Id + " " + sp.permission_Id + " " + sp.Quantity + " " + sp.permission_Date + " " + sp.production_Date + " " + sp.Expiray_Date);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Supply_permission supply = null;
            foreach (Supply_permission sp in model.Supply_permission)
            {
                if (sp.Stock_Id == int.Parse(comboBox1.Text) && sp.Item_Id == int.Parse(comboBox2.Text) && sp.Supplier_Id == int.Parse(comboBox3.Text) && sp.permission_Id == int.Parse(textBox3.Text))
                {
                    supply = sp;
                }
            }
            if (supply != null)
            {
                model.Supply_permission.Remove(supply);
                model.SaveChanges();
                MessageBox.Show("YOUR ROW IS DELETED");
                listBox1.Items.Clear();
                textBox1.Text = textBox3.Text = textBox4.Text = textBox5.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = "";
                foreach (Supply_permission sp in model.Supply_permission)
                {
                    listBox1.Items.Add(sp.Stock_Id + " " + sp.Item_Id + " " + sp.Supplier_Id + " " + sp.permission_Id + " " + sp.Quantity + " " + sp.permission_Date + " " + sp.production_Date + " " + sp.Expiray_Date);
                }
            }
        }
    }
}
