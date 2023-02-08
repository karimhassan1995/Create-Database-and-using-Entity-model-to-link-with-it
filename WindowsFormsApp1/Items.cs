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
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();
        }
        Model1 model = new Model1();
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Item_id" + " | " + "item name" + " | " + "units");
            foreach (Item i in model.Items)
            {
                listBox1.Items.Add(i.Item_Id + "   " + i.Item_Name + "    " +i.Measuring_unit.unit);
            }
        }

       private void button2_Click(object sender, EventArgs e)
        {
          Item item = new Item();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                Item i = model.Items.Find(int.Parse(textBox1.Text));
                if (i == null)
                {
                    item.Item_Id = int.Parse(textBox1.Text);
                    item.Item_Name = textBox2.Text;
                    Measuring_unit mu = new Measuring_unit();
                    mu.Item_Id = item.Item_Id;
                    mu.unit = textBox3.Text;
                    model.Items.Add(item);
                    model.Measuring_unit.Add(mu);
                    model.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text =  "";
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Item_id" + " | " + "item name" + " | " + "units");
                    foreach (Item i1 in model.Items)
                    {
                        listBox1.Items.Add(i1.Item_Id + "   " + i1.Item_Name + "    " + i1.Measuring_unit.unit);
                    }
                }
                else { MessageBox.Show("The Item is already exist"); }
            }
            else { MessageBox.Show("Fill all the required Text boxes"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text!="")
            {
                Item i = model.Items.Find(int.Parse(textBox1.Text));
                if (textBox2.Text != " " && textBox3.Text != " ")
                {
                    i.Item_Name = textBox2.Text;
                    i.Measuring_unit.unit = textBox3.Text;
                    model.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text =  " ";
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Item_id" + " | " + "item name" + " | " + "units");
                    foreach (Item i2 in model.Items)
                    {
                        listBox1.Items.Add(i2.Item_Id + "   " + i2.Item_Name + "    " + i2.Measuring_unit.unit);
                    }
                }
                else { MessageBox.Show("Fill all the textboxes"); }
            }
            else { MessageBox.Show("The Item wanted to be updated is not exist"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text!="")
            {
                Item i = model.Items.Find(int.Parse(textBox1.Text));
                foreach (Stock_Item ii in model.Stock_Item)
                {
                    if (ii.Item_id == i.Item_Id)
                    {
                        model.Stock_Item.Remove(ii);
                    }
                }
              foreach (Supply_permission sp in model.Supply_permission)
                {
                    if (sp.Item_Id == i.Item_Id)
                    {
                        model.Supply_permission.Remove(sp);
                    }
                }
                foreach (Dispence_Permission dp in model.Dispence_Permission)
                {
                    if (dp.Item_Id == i.Item_Id)
                    {
                        model.Dispence_Permission.Remove(dp);
                    }
                }
                model.SaveChanges();
                model.Items.Remove(i);
                model.SaveChanges();
                textBox1.Text = "";
                listBox1.Items.Clear();
                listBox1.Items.Add("Item_id" + " | " + "item name" + " | " + "units");
                foreach (Item i3 in model.Items)
                {
                    listBox1.Items.Add(i3.Item_Id + "   " + i3.Item_Name + "    " + i3.Measuring_unit.unit);
                }
            }
            else { MessageBox.Show("fill the id "); }
        }

        private void Items_Load(object sender, EventArgs e)
        {

        }
    }
}
