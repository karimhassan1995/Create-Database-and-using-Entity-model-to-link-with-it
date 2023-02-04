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
    public partial class Suppliers : Form
    {
        public Suppliers()
        {
            InitializeComponent();
        }
        Model1 model = new Model1();
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Supplier s in model.Suppliers)
            {
                listBox1.Items.Add(s.Supplier_Id + "  " + s.Supplier_Name + "  " + s.phone + "  " + s.fax+"  "+s.mobile+"  "+s.mail+"  "+s.website);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            if (textBox2 != null && textBox3 != null && textBox4 != null && textBox5 != null && textBox4 != null && textBox7 != null)
            {
                Supplier s = model.Suppliers.Find(int.Parse(textBox1.Text));
                if (s == null)
                {
                    supplier.Supplier_Id = int.Parse(textBox1.Text);
                    supplier.Supplier_Name = textBox2.Text;
                    supplier.phone = textBox3.Text;
                    supplier.fax = textBox4.Text;
                    supplier.mobile=textBox5.Text;
                    supplier.mail = textBox6.Text;
                    supplier.website = textBox7.Text;
                    model.Suppliers.Add(supplier);
                    model.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text= textBox7.Text= "";
                }
                else { MessageBox.Show("the Supplier is already exist"); }
            }
            else { MessageBox.Show("Fill all the Rexquired info"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Supplier s = model.Suppliers.Find(int.Parse(textBox1.Text));
            if (s != null)
            {
                if ( textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != " ")
                {
                    s.Supplier_Name = textBox2.Text;
                    s.phone= textBox3.Text;
                    s.fax = textBox4.Text;
                    s.mobile= textBox5.Text;
                    s.mail = textBox6.Text;
                    s.website= textBox7.Text;
                    model.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
                }
                else { MessageBox.Show("Fill all the textboxes"); }
            }
            else { MessageBox.Show("the stock wanted to be updated is not exist"); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*Supplier s = model.Suppliers.Find(int.Parse(textBox1.Text));
            if (s != null && textBox1.Text !="")
            {
                textBox2.Text = s.Supplier_Name;
                textBox3.Text = s.phone;
                textBox4.Text = s.fax;
                textBox5.Text = s.mobile;
                textBox6.Text = s.mail;
                textBox7.Text = s.website;
            } */
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Supplier s = model.Suppliers.Find(int.Parse(textBox1.Text));
            if (s != null)
            {

               
                foreach (Supply_permission sp in model.Supply_permission)
                {
                    if (sp.Supplier_Id == s.Supplier_Id)
                    {
                        model.Supply_permission.Remove(sp);
                    }
                }
                foreach (Dispence_Permission dp in model.Dispence_Permission)
                {
                    if (dp.Supplier_Id == s.Supplier_Id)
                    {
                        model.Dispence_Permission.Remove(dp);
                    }
                }
               
                model.Suppliers.Remove(s);
                model.SaveChanges();
                textBox1.Text = "";
            }
        }
    }
}
