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
    public partial class Stocks : Form
    {
        public Stocks()
        {
            InitializeComponent();
        }
        Model1 model = new Model1();    

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); 
            foreach (Stock st in model.Stocks)
            {
                listBox1.Items.Add(st.Stock_Id+" "+st.Stock_Name+" "+st.Manager_Id+" "+st.Manager_Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock();
            if(textBox1.Text!= "" && textBox2.Text!= "" && textBox3.Text!="" && textBox4.Text!="") 
            {
                Stock s = model.Stocks.Find(int.Parse(textBox1.Text));
                if(s==null)
                {
                    stock.Stock_Id = int.Parse(textBox1.Text);
                    stock.Stock_Name = textBox2.Text;
                    stock.Manager_Id= int.Parse(textBox3.Text);
                    stock.Manager_Name = textBox4.Text;
                    model.Stocks.Add(stock);
                    model.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                    listBox1.Items.Clear();
                    foreach (Stock st in model.Stocks)
                    {
                        listBox1.Items.Add(st.Stock_Id + " " + st.Stock_Name + " " + st.Manager_Id + " " + st.Manager_Name);
                    }
                }
                else { MessageBox.Show("the stock is already exist"); }
            }
            else { MessageBox.Show("fill all the text boxes"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if(textBox1.Text!="")
            {
                Stock s = model.Stocks.Find(int.Parse(textBox1.Text));
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    s.Stock_Name=textBox2.Text;
                    s.Manager_Id= int.Parse(textBox3.Text);
                    s.Manager_Name= textBox4.Text;
                    model.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = " ";
                    listBox1.Items.Clear();
                    foreach (Stock st in model.Stocks)
                    {
                        listBox1.Items.Add(st.Stock_Id + " " + st.Stock_Name + " " + st.Manager_Id + " " + st.Manager_Name);
                    }
                }
                else { MessageBox.Show("fill all the textboxes"); }
            }
            else { MessageBox.Show("the stock wanted to be updated is not exist"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text != "")
            {
                Stock s = model.Stocks.Find(int.Parse(textBox1.Text));
                foreach (Stock_Item si in model.Stock_Item)
                {
                    if (si.Stock_id == s.Stock_Id)
                    {
                        model.Stock_Item.Remove(si);
                    }
                }
                foreach(Supply_permission sp in model.Supply_permission)
                {
                    if(sp.Stock_Id == s.Stock_Id)
                    {
                        model.Supply_permission.Remove(sp);
                    }
                }
                foreach (Dispence_Permission dp in model.Dispence_Permission)
                {
                    if (dp.Stock_Id == s.Stock_Id)
                    {
                        model.Dispence_Permission.Remove(dp);
                    }
                }
                model.SaveChanges() ;
                model.Stocks.Remove(s);
                model.SaveChanges();
                textBox1.Text = "";
                listBox1.Items.Clear();
                foreach (Stock st in model.Stocks)
                {
                    listBox1.Items.Add(st.Stock_Id + " " + st.Stock_Name + " " + st.Manager_Id + " " + st.Manager_Name);
                }
            }
        }

        private void Stocks_Load(object sender, EventArgs e)
        {

        }
    }
}
