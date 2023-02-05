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
    public partial class Items_Reports : Form
    {
        public Items_Reports()
        {
            InitializeComponent();
        }
        Model1 model= new Model1();
        private void Items_Reports_Load(object sender, EventArgs e)
        {
            foreach(Item i in model.Items)
            {
                comboBox1.Items.Add(i.Item_Id);
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            int ID = int.Parse(comboBox1.Text);
            foreach (Stock_Item s in model.Stock_Item)
            {
                if (s.Item.Item_Id == ID)
                {
                    comboBox2.Items.Add(s.Stock.Stock_Id);
                    comboBox3.Items.Add(s.Stock.Stock_Id);
                    comboBox4.Items.Add(s.Stock.Stock_Id);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                if(comboBox1.Text!= "" &&  comboBox2.Text!="" && comboBox3.Text == "" && comboBox4.Text == "")
                {
                    if (textBox1.Text == "" || textBox2.Text == "")
                    {
                        MessageBox.Show("Warning: Missing date");
                    }
                    else
                    {
                        DateTime x = Convert.ToDateTime(textBox1.Text);
                        DateTime y = Convert.ToDateTime(textBox2.Text);
                        int r = int.Parse(comboBox1.Text);
                        int p = int.Parse(comboBox2.Text);
                        var Items1 = (from sp in model.Supply_permission
                                      join s in model.Stocks
                                      on sp.Stock_Id equals s.Stock_Id
                                      join si in model.Stock_Item
                                      on s.Stock_Id equals si.Stock_id
                                      join i in model.Items
                                      on si.Item_id equals i.Item_Id
                                      where sp.permission_Date >= x && sp.permission_Date <= y && si.Item_id == r && si.Stock_id == p
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
                        foreach (var ii in Items1)
                        {
                            listBox1.Items.Add(ii.Stock_ID + " " + ii.Stock_Name + " " + ii.item_ID + " " + ii.Item_Name + " " + ii.quantity + " " + ii.production_Date + " " + ii.Expiary_Date);
                        }
                    }
                }
                else if (comboBox1.Text != "" && comboBox2.Text == "" && comboBox3.Text != "" && comboBox4.Text == "")
                {
                        if (textBox1.Text == "" || textBox2.Text == "")
                        {
                            MessageBox.Show("Warning: Missing date");
                        }
                        else
                        {
                            DateTime x = Convert.ToDateTime(textBox1.Text);
                            DateTime y = Convert.ToDateTime(textBox2.Text);
                            int r = int.Parse(comboBox1.Text);
                            int p = int.Parse(comboBox3.Text);
                            var Items1 = (from sp in model.Supply_permission
                                          join s in model.Stocks
                                          on sp.Stock_Id equals s.Stock_Id
                                          join si in model.Stock_Item
                                          on s.Stock_Id equals si.Stock_id
                                          join i in model.Items
                                          on si.Item_id equals i.Item_Id
                                          where sp.permission_Date >= x && sp.permission_Date <= y && si.Item_id == r && si.Stock_id == p
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
                            foreach (var ii in Items1)
                            {
                                listBox1.Items.Add(ii.Stock_ID + " " + ii.Stock_Name + " " + ii.item_ID + " " + ii.Item_Name + " " + ii.quantity + " " + ii.production_Date + " " + ii.Expiary_Date);
                            }
                        }
                }
            else if (comboBox1.Text != "" && comboBox2.Text == "" && comboBox3.Text == "" && comboBox4.Text != "")
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Warning: Missing date");
                }
                else
                {
                    DateTime x = Convert.ToDateTime(textBox1.Text);
                    DateTime y = Convert.ToDateTime(textBox2.Text);
                    int r = int.Parse(comboBox1.Text);
                    int p = int.Parse(comboBox4.Text);
                    var Items1 = (from sp in model.Supply_permission
                                  join s in model.Stocks
                                  on sp.Stock_Id equals s.Stock_Id
                                  join si in model.Stock_Item
                                  on s.Stock_Id equals si.Stock_id
                                  join i in model.Items
                                  on si.Item_id equals i.Item_Id
                                  where sp.permission_Date >= x && sp.permission_Date <= y && si.Item_id == r && si.Stock_id == p
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
                    foreach (var ii in Items1)
                    {
                        listBox1.Items.Add(ii.Stock_ID + " " + ii.Stock_Name + " " + ii.item_ID + " " + ii.Item_Name + " " + ii.quantity + " " + ii.production_Date + " " + ii.Expiary_Date);
                    }
                }
            }
            else if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text == "")
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Warning: Missing date");
                }
                else
                {
                    DateTime x = Convert.ToDateTime(textBox1.Text);
                    DateTime y = Convert.ToDateTime(textBox2.Text);
                    int r = int.Parse(comboBox1.Text);
                    int g = int.Parse(comboBox2.Text);
                    int p = int.Parse(comboBox3.Text);
                    var Items1 = (from sp in model.Supply_permission
                                  join s in model.Stocks
                                  on sp.Stock_Id equals s.Stock_Id
                                  join si in model.Stock_Item
                                  on s.Stock_Id equals si.Stock_id
                                  join i in model.Items
                                  on si.Item_id equals i.Item_Id
                                  where sp.permission_Date >= x && sp.permission_Date <= y && si.Item_id == r && (si.Stock_id == p || si.Stock_id == g)
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
                    foreach (var ii in Items1)
                    {
                        listBox1.Items.Add(ii.Stock_ID + " " + ii.Stock_Name + " " + ii.item_ID + " " + ii.Item_Name + " " + ii.quantity + " " + ii.production_Date + " " + ii.Expiary_Date);
                    }
                }
            }
            else if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text == "" && comboBox4.Text != "")
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Warning: Missing date");
                }
                else
                {
                    DateTime x = Convert.ToDateTime(textBox1.Text);
                    DateTime y = Convert.ToDateTime(textBox2.Text);
                    int r = int.Parse(comboBox1.Text);
                    int g = int.Parse(comboBox2.Text);
                    int p = int.Parse(comboBox4.Text);
                    var Items1 = (from sp in model.Supply_permission
                                  join s in model.Stocks
                                  on sp.Stock_Id equals s.Stock_Id
                                  join si in model.Stock_Item
                                  on s.Stock_Id equals si.Stock_id
                                  join i in model.Items
                                  on si.Item_id equals i.Item_Id
                                  where sp.permission_Date >= x && sp.permission_Date <= y && si.Item_id == r && (si.Stock_id == p || si.Stock_id == g)
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
                    foreach (var ii in Items1)
                    {
                        listBox1.Items.Add(ii.Stock_ID + " " + ii.Stock_Name + " " + ii.item_ID + " " + ii.Item_Name + " " + ii.quantity + " " + ii.production_Date + " " + ii.Expiary_Date);
                    }
                }
            }
            else if (comboBox1.Text != "" && comboBox2.Text == "" && comboBox3.Text != "" && comboBox4.Text != "")
            {
                if(textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Warning: Missing date");
                }
                else { 
                        DateTime x = Convert.ToDateTime(textBox1.Text);
                        DateTime y = Convert.ToDateTime(textBox2.Text);
                        int r = int.Parse(comboBox1.Text);
                        int g = int.Parse(comboBox3.Text);
                        int p = int.Parse(comboBox4.Text);
                        var Items1 = (from sp in model.Supply_permission
                                      join s in model.Stocks
                                      on sp.Stock_Id equals s.Stock_Id
                                      join si in model.Stock_Item
                                      on s.Stock_Id equals si.Stock_id
                                      join i in model.Items
                                      on si.Item_id equals i.Item_Id
                                      where sp.permission_Date >= x && sp.permission_Date <= y && si.Item_id == r && (si.Stock_id == p || si.Stock_id == g)
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
                        foreach (var ii in Items1)
                        {
                            listBox1.Items.Add(ii.Stock_ID + " " + ii.Stock_Name + " " + ii.item_ID + " " + ii.Item_Name + " " + ii.quantity + " " + ii.production_Date + " " + ii.Expiary_Date);
                        }
                }
            }
            else if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "")
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Warning: Missing date");
                }
                else
                {
                    DateTime x = Convert.ToDateTime(textBox1.Text);
                    DateTime y = Convert.ToDateTime(textBox2.Text);
                    int r = int.Parse(comboBox1.Text);
                    int g = int.Parse(comboBox2.Text);
                    int p = int.Parse(comboBox3.Text);
                    int Fourth_Stock_Input = int.Parse(comboBox4.Text);
                    var Items1 = (from sp in model.Supply_permission
                                  join s in model.Stocks
                                  on sp.Stock_Id equals s.Stock_Id
                                  join si in model.Stock_Item
                                  on s.Stock_Id equals si.Stock_id
                                  join i in model.Items
                                  on si.Item_id equals i.Item_Id
                                  where sp.permission_Date >= x && sp.permission_Date <= y && si.Item_id == r && (si.Stock_id == p || si.Stock_id == g || si.Stock_id == Fourth_Stock_Input)
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
                    foreach (var ii in Items1)
                    {
                        listBox1.Items.Add(ii.Stock_ID + " " + ii.Stock_Name + " " + ii.item_ID + " " + ii.Item_Name + " " + ii.quantity + " " + ii.production_Date + " " + ii.Expiary_Date);
                    }
                }
            }

        }
    }
}
