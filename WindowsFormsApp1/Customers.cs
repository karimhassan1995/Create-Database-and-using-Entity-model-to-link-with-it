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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }
        Model1 model = new Model1();
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Customer c in model.Customers)
            {
                listBox1.Items.Add(c.Customer_id+ "  " + c.Customer_Name + "  " + c.phone + "  " + c.fax + "  " + c.mobile + "  " + c.mail + "  " + c.website);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            if (textBox1.Text!=""&& textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox4.Text != "" && textBox7.Text != "")
            {
                Customer cu = model.Customers.Find(int.Parse(textBox1.Text));
                if (cu == null)
                {
                    customer.Customer_id = int.Parse(textBox1.Text);
                    customer.Customer_Name = textBox2.Text;
                    customer.phone = textBox3.Text;
                    customer.fax = textBox4.Text;
                    customer.mobile = textBox5.Text;
                    customer.mail = textBox6.Text;
                    customer.website = textBox7.Text;
                    model.Customers.Add(customer);
                    model.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
                    listBox1.Items.Clear();
                    foreach (Customer c in model.Customers)
                    {
                        listBox1.Items.Add(c.Customer_id + "  " + c.Customer_Name + "  " + c.phone + "  " + c.fax + "  " + c.mobile + "  " + c.mail + "  " + c.website);
                    }
                }
                else { MessageBox.Show("the customer is already existed"); }
            }
            else { MessageBox.Show("Fill all the Rexquired info"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "")
            {
                Customer c = model.Customers.Find(int.Parse(textBox1.Text));
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox4.Text != "" && textBox7.Text != "")
                {
                    c.Customer_Name = textBox2.Text;
                    c.phone = textBox3.Text;
                    c.fax = textBox4.Text;
                    c.mobile = textBox5.Text;
                    c.mail = textBox6.Text;
                    c.website = textBox7.Text;
                    model.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
                    listBox1.Items.Clear();
                    foreach (Customer cu in model.Customers)
                    {
                        listBox1.Items.Add(cu.Customer_id + "  " + cu.Customer_Name + "  " + cu.phone + "  " + cu.fax + "  " + cu.mobile + "  " + cu.mail + "  " + cu.website);
                    }
                }
                else { MessageBox.Show("Fill all the required informaion"); }
            }
            else { MessageBox.Show("the customer wanted to be updated is not existed"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "")
            {
                Customer ci = model.Customers.Find(int.Parse(textBox1.Text));
                model.Customers.Remove(ci);
                model.SaveChanges();
                textBox1.Text = "";
                listBox1.Items.Clear();
                foreach (Customer c in model.Customers)
                {
                    listBox1.Items.Add(c.Customer_id + "  " + c.Customer_Name + "  " + c.phone + "  " + c.fax + "  " + c.mobile + "  " + c.mail + "  " + c.website);
                }
            }
        }
    }
}
