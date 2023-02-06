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
    public partial class Dispence_Permissions : Form
    {
        public Dispence_Permissions()
        {
            InitializeComponent();
        }
        Model1 model = new Model1();
        private void Dispence_Permissions_Load(object sender, EventArgs e)
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
            Dispence_Permission newsupply = new Dispence_Permission();
            if (textBox3 != null && textBox4 != null && textBox5 != null && comboBox1 != null && comboBox2 != null && comboBox3 != null)
            {
               Dispence_Permission supply = null;
                foreach (Dispence_Permission dp in model.Dispence_Permission)
                {
                    if (dp.Stock_Id == int.Parse(comboBox1.Text) && dp.Item_Id == int.Parse(comboBox2.Text) && dp.Supplier_Id == int.Parse(comboBox3.Text) && dp.Permission_Id == int.Parse(textBox3.Text))
                    {
                        supply = dp;
                    }
                }

                if (supply == null)
                {
                    newsupply.Stock_Id = int.Parse(comboBox1.Text);
                    newsupply.Item_Id = int.Parse(comboBox2.Text);
                    newsupply.Supplier_Id = int.Parse(comboBox3.Text);
                    newsupply.Permission_Id = int.Parse(textBox3.Text);
                    newsupply.Quantity = int.Parse(textBox4.Text);
                    newsupply.Permission_Date = DateTime.Now;
                    newsupply.Production_Date = Convert.ToDateTime(textBox5.Text);
                    newsupply.Expiary_Date = Convert.ToDateTime(textBox1.Text);
                    model.Dispence_Permission.Add(newsupply);
                    model.SaveChanges();
                    textBox1.Text = textBox3.Text = textBox4.Text = textBox5.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = "";
                }
                else { MessageBox.Show("the Dispence permission is already existed"); }
            }
            else { MessageBox.Show("Fill all the Rexquired info"); }
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Dispence_Permission dp in model.Dispence_Permission)
            {
                listBox1.Items.Add(dp.Stock_Id + " " + dp.Item_Id + " " + dp.Supplier_Id + " " + dp.Permission_Id + " " + dp.Quantity + " " + dp.Permission_Date + " " + dp.Production_Date + " " + dp.Expiary_Date);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && textBox3.Text != "")
            {
                Dispence_Permission supply = null;
                foreach (Dispence_Permission dp in model.Dispence_Permission)
                {
                    if (dp.Stock_Id == int.Parse(comboBox1.Text) && dp.Item_Id == int.Parse(comboBox2.Text) && dp.Supplier_Id == int.Parse(comboBox3.Text) && dp.Permission_Id == int.Parse(textBox3.Text))
                    {
                        supply = dp;
                    }
                }
                if (supply != null)
                {

                    supply.Production_Date = Convert.ToDateTime(textBox5.Text);
                    supply.Expiary_Date = Convert.ToDateTime(textBox1.Text);
                    model.SaveChanges();
                    MessageBox.Show("YOUR Dispence IS UPDATED");
                    textBox1.Text = textBox3.Text = textBox4.Text = textBox5.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = "";
                    listBox1.Items.Clear();
                    foreach (Dispence_Permission dp in model.Dispence_Permission)
                    {
                        listBox1.Items.Add(dp.Stock_Id + " " + dp.Item_Id + " " + dp.Supplier_Id + " " + dp.Permission_Id + " " + dp.Quantity + " " + dp.Permission_Date + " " + dp.Production_Date + " " + dp.Expiary_Date);
                    }
                }
            }
            else { MessageBox.Show("FILL the reqiured info"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text !="" && comboBox3.Text!= "" && textBox3.Text != "")
            {
                Dispence_Permission supply = null;
                foreach (Dispence_Permission dp in model.Dispence_Permission)
                {
                    if (dp.Stock_Id == int.Parse(comboBox1.Text) && dp.Item_Id == int.Parse(comboBox2.Text) && dp.Supplier_Id == int.Parse(comboBox3.Text) && dp.Permission_Id == int.Parse(textBox3.Text))
                    {
                        supply = dp;
                    }
                }
                if (supply != null)
                {
                    model.Dispence_Permission.Remove(supply);
                    model.SaveChanges();
                    MessageBox.Show("YOUR ROW IS DELETED");
                    listBox1.Items.Clear();
                    textBox1.Text = textBox3.Text = textBox4.Text = textBox5.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = "";
                    foreach (Dispence_Permission dp in model.Dispence_Permission)
                    {
                        listBox1.Items.Add(dp.Stock_Id + " " + dp.Item_Id + " " + dp.Supplier_Id + " " + dp.Permission_Id + " " + dp.Quantity + " " + dp.Permission_Date + " " + dp.Production_Date + " " + dp.Expiary_Date);
                    }
                }
            }
            else { MessageBox.Show("FILL the reqiured info"); }
        }
    }
}
