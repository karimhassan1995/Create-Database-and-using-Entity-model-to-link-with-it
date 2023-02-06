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
    public partial class Items_Movement : Form
    {
        public Items_Movement()
        {
            InitializeComponent();
        }
        Model1 model = new Model1();
        private void Items_Movement_Load(object sender, EventArgs e)
        {
            foreach(Item item in model.Items) 
            { 
                comboBox1.Items.Add(item.Item_Id);
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
             if (comboBox2.Text == "" && comboBox3.Text == "" && comboBox4.Text == "") 
            { 
                    MessageBox.Show("you need to choose a stock");
            }
            else if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text == "" && comboBox4.Text == "")
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Warning: Missing date");
                }
                else
                {
                    DateTime x = Convert.ToDateTime(textBox1.Text);
                    DateTime y = Convert.ToDateTime(textBox2.Text);
                    int Item_Id = int.Parse(comboBox1.Text);
                    int First_Stock_Id = int.Parse(comboBox2.Text);
                    var Items1 = (from sp in model.Supply_permission
                                  join s in model.Stocks
                                  on sp.Stock_Id equals s.Stock_Id
                                  join i in model.Items
                                  on sp.Item_Id equals i.Item_Id

                                  where sp.permission_Date >= x && sp.permission_Date <= y && sp.Item_Id == Item_Id && (sp.Stock_Id == First_Stock_Id)
                                  select new
                                  {
                                      Stock_ID = sp.Stock_Id,
                                      Stock_Name = s.Stock_Name,
                                      item_ID = i.Item_Id,
                                      Item_Name = i.Item_Name,
                                      spplied_quantity = sp.Quantity,
                                      supplied_date = sp.permission_Date,

                                  });
                    var Items2 = (from dp in model.Dispence_Permission
                                  join s in model.Stocks
                                  on dp.Stock_Id equals s.Stock_Id
                                  join i in model.Items
                                  on dp.Item_Id equals i.Item_Id
                                  where dp.Permission_Date >= x && dp.Permission_Date <= y && dp.Item_Id == Item_Id && (dp.Stock_Id == First_Stock_Id )
                                  select new
                                  {
                                      despenced_quantaty = dp.Quantity,
                                      depenced_date = dp.Permission_Date
                                  });

                    listBox1.Items.Clear();
                    foreach (var ii in Items1)
                    {
                        listBox1.Items.Add("the item with id " + ii.item_ID + " with name " + ii.Item_Name + " in stock " + ii.Stock_Name + " is supplied by quantaty= " + ii.spplied_quantity + " in " + ii.supplied_date /*+ " and dispenced by quantaty= " /*+ ii.dispenced_quantaty + " in " + ii.dispenced_date**/);
                    }
                    foreach (var d in Items2)
                    {
                        listBox1.Items.Add(" and dispenced by quantaty = " + d.despenced_quantaty + " in date " + d.depenced_date);
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
                    int Item_Id = int.Parse(comboBox1.Text);
                    int First_Stock_Id = int.Parse(comboBox3.Text);
                    var Items1 = (from sp in model.Supply_permission
                                  join s in model.Stocks
                                  on sp.Stock_Id equals s.Stock_Id
                                  join i in model.Items
                                  on sp.Item_Id equals i.Item_Id

                                  where sp.permission_Date >= x && sp.permission_Date <= y && sp.Item_Id == Item_Id && (sp.Stock_Id == First_Stock_Id)
                                  select new
                                  {
                                      Stock_ID = sp.Stock_Id,
                                      Stock_Name = s.Stock_Name,
                                      item_ID = i.Item_Id,
                                      Item_Name = i.Item_Name,
                                      spplied_quantity = sp.Quantity,
                                      supplied_date = sp.permission_Date,

                                  });
                    var Items2 = (from dp in model.Dispence_Permission
                                  join s in model.Stocks
                                  on dp.Stock_Id equals s.Stock_Id
                                  join i in model.Items
                                  on dp.Item_Id equals i.Item_Id
                                  where dp.Permission_Date >= x && dp.Permission_Date <= y && dp.Item_Id == Item_Id && (dp.Stock_Id == First_Stock_Id )
                                  select new
                                  {
                                      despenced_quantaty = dp.Quantity,
                                      depenced_date = dp.Permission_Date
                                  });

                    listBox1.Items.Clear();
                    foreach (var ii in Items1)
                    {
                        listBox1.Items.Add("the item with id " + ii.item_ID + " with name " + ii.Item_Name + " in stock " + ii.Stock_Name + " is supplied by quantaty= " + ii.spplied_quantity + " in " + ii.supplied_date /*+ " and dispenced by quantaty= " /*+ ii.dispenced_quantaty + " in " + ii.dispenced_date**/);
                    }
                    foreach (var d in Items2)
                    {
                        listBox1.Items.Add(" and dispenced by quantaty = " + d.despenced_quantaty + " in date " + d.depenced_date);
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
                    int Item_Id = int.Parse(comboBox1.Text);
                    int First_Stock_Id = int.Parse(comboBox4.Text);
                    var Items1 = (from sp in model.Supply_permission
                                  join s in model.Stocks
                                  on sp.Stock_Id equals s.Stock_Id
                                  join i in model.Items
                                  on sp.Item_Id equals i.Item_Id

                                  where sp.permission_Date >= x && sp.permission_Date <= y && sp.Item_Id == Item_Id && (sp.Stock_Id == First_Stock_Id )
                                  select new
                                  {
                                      Stock_ID = sp.Stock_Id,
                                      Stock_Name = s.Stock_Name,
                                      item_ID = i.Item_Id,
                                      Item_Name = i.Item_Name,
                                      spplied_quantity = sp.Quantity,
                                      supplied_date = sp.permission_Date,

                                  });
                    var Items2 = (from dp in model.Dispence_Permission
                                  join s in model.Stocks
                                  on dp.Stock_Id equals s.Stock_Id
                                  join i in model.Items
                                  on dp.Item_Id equals i.Item_Id
                                  where dp.Permission_Date >= x && dp.Permission_Date <= y && dp.Item_Id == Item_Id && (dp.Stock_Id == First_Stock_Id )
                                  select new
                                  {
                                      despenced_quantaty = dp.Quantity,
                                      depenced_date = dp.Permission_Date
                                  });

                    listBox1.Items.Clear();
                    foreach (var ii in Items1)
                    {
                        listBox1.Items.Add("the item with id " + ii.item_ID + " with name " + ii.Item_Name + " in stock " + ii.Stock_Name + " is supplied by quantaty= " + ii.spplied_quantity + " in " + ii.supplied_date /*+ " and dispenced by quantaty= " /*+ ii.dispenced_quantaty + " in " + ii.dispenced_date**/);
                    }
                    foreach (var d in Items2)
                    {
                        listBox1.Items.Add(" and dispenced by quantaty = " + d.despenced_quantaty + " in date " + d.depenced_date);
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
                    int Item_Id = int.Parse(comboBox1.Text);
                    int First_Stock_Id = int.Parse(comboBox2.Text);
                    int second_Stock_Id = int.Parse(comboBox3.Text);
                    var Items1 = (from sp in model.Supply_permission
                                  join s in model.Stocks
                                  on sp.Stock_Id equals s.Stock_Id
                                  join i in model.Items
                                  on sp.Item_Id equals i.Item_Id

                                  where sp.permission_Date >= x && sp.permission_Date <= y && sp.Item_Id == Item_Id && (sp.Stock_Id == First_Stock_Id || sp.Stock_Id == second_Stock_Id )
                                  select new
                                  {
                                      Stock_ID = sp.Stock_Id,
                                      Stock_Name = s.Stock_Name,
                                      item_ID = i.Item_Id,
                                      Item_Name = i.Item_Name,
                                      spplied_quantity = sp.Quantity,
                                      supplied_date = sp.permission_Date,

                                  });
                    var Items2 = (from dp in model.Dispence_Permission
                                  join s in model.Stocks
                                  on dp.Stock_Id equals s.Stock_Id
                                  join i in model.Items
                                  on dp.Item_Id equals i.Item_Id
                                  where dp.Permission_Date >= x && dp.Permission_Date <= y && dp.Item_Id == Item_Id && (dp.Stock_Id == First_Stock_Id || dp.Stock_Id == second_Stock_Id )
                                  select new
                                  {
                                      despenced_quantaty = dp.Quantity,
                                      depenced_date = dp.Permission_Date
                                  });

                    listBox1.Items.Clear();
                    foreach (var ii in Items1)
                    {
                        listBox1.Items.Add("the item with id " + ii.item_ID + " with name " + ii.Item_Name + " in stock " + ii.Stock_Name + " is supplied by quantaty= " + ii.spplied_quantity + " in " + ii.supplied_date /*+ " and dispenced by quantaty= " /*+ ii.dispenced_quantaty + " in " + ii.dispenced_date**/);
                    }
                    foreach (var d in Items2)
                    {
                        listBox1.Items.Add(" and dispenced by quantaty = " + d.despenced_quantaty + " in date " + d.depenced_date);
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
                    int Item_Id = int.Parse(comboBox1.Text);
                    int First_Stock_Id = int.Parse(comboBox2.Text);
                    int second_Stock_Id = int.Parse(comboBox4.Text);
                    var Items1 = (from sp in model.Supply_permission
                                  join s in model.Stocks
                                  on sp.Stock_Id equals s.Stock_Id
                                  join i in model.Items
                                  on sp.Item_Id equals i.Item_Id

                                  where sp.permission_Date >= x && sp.permission_Date <= y && sp.Item_Id == Item_Id && (sp.Stock_Id == First_Stock_Id || sp.Stock_Id == second_Stock_Id )
                                  select new
                                  {
                                      Stock_ID = sp.Stock_Id,
                                      Stock_Name = s.Stock_Name,
                                      item_ID = i.Item_Id,
                                      Item_Name = i.Item_Name,
                                      spplied_quantity = sp.Quantity,
                                      supplied_date = sp.permission_Date,

                                  });
                    var Items2 = (from dp in model.Dispence_Permission
                                  join s in model.Stocks
                                  on dp.Stock_Id equals s.Stock_Id
                                  join i in model.Items
                                  on dp.Item_Id equals i.Item_Id
                                  where dp.Permission_Date >= x && dp.Permission_Date <= y && dp.Item_Id == Item_Id && (dp.Stock_Id == First_Stock_Id || dp.Stock_Id == second_Stock_Id )
                                  select new
                                  {
                                      despenced_quantaty = dp.Quantity,
                                      depenced_date = dp.Permission_Date
                                  });

                    listBox1.Items.Clear();
                    foreach (var ii in Items1)
                    {
                        listBox1.Items.Add("the item with id " + ii.item_ID + " with name " + ii.Item_Name + " in stock " + ii.Stock_Name + " is supplied by quantaty= " + ii.spplied_quantity + " in " + ii.supplied_date /*+ " and dispenced by quantaty= " /*+ ii.dispenced_quantaty + " in " + ii.dispenced_date**/);
                    }
                    foreach (var d in Items2)
                    {
                        listBox1.Items.Add(" and dispenced by quantaty = " + d.despenced_quantaty + " in date " + d.depenced_date);
                    }
                }
            }
            else if (comboBox1.Text != "" && comboBox2.Text == "" && comboBox3.Text != "" && comboBox4.Text != "")
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Warning: Missing date");
                }
                else
                {
                    DateTime x = Convert.ToDateTime(textBox1.Text);
                    DateTime y = Convert.ToDateTime(textBox2.Text);
                    int Item_Id = int.Parse(comboBox1.Text);
                    int First_Stock_Id = int.Parse(comboBox3.Text);
                    int second_Stock_Id = int.Parse(comboBox4.Text);
                    var Items1 = (from sp in model.Supply_permission
                                  join s in model.Stocks
                                  on sp.Stock_Id equals s.Stock_Id
                                  join i in model.Items
                                  on sp.Item_Id equals i.Item_Id

                                  where sp.permission_Date >= x && sp.permission_Date <= y && sp.Item_Id == Item_Id && (sp.Stock_Id == First_Stock_Id || sp.Stock_Id == second_Stock_Id )
                                  select new
                                  {
                                      Stock_ID = sp.Stock_Id,
                                      Stock_Name = s.Stock_Name,
                                      item_ID = i.Item_Id,
                                      Item_Name = i.Item_Name,
                                      spplied_quantity = sp.Quantity,
                                      supplied_date = sp.permission_Date,

                                  });
                    var Items2 = (from dp in model.Dispence_Permission
                                  join s in model.Stocks
                                  on dp.Stock_Id equals s.Stock_Id
                                  join i in model.Items
                                  on dp.Item_Id equals i.Item_Id
                                  where dp.Permission_Date >= x && dp.Permission_Date <= y && dp.Item_Id == Item_Id && (dp.Stock_Id == First_Stock_Id || dp.Stock_Id == second_Stock_Id )
                                  select new
                                  {
                                      despenced_quantaty = dp.Quantity,
                                      depenced_date = dp.Permission_Date
                                  });

                    listBox1.Items.Clear();
                    foreach (var ii in Items1)
                    {
                        listBox1.Items.Add("the item with id " + ii.item_ID + " with name " + ii.Item_Name + " in stock " + ii.Stock_Name + " is supplied by quantaty= " + ii.spplied_quantity + " in " + ii.supplied_date /*+ " and dispenced by quantaty= " /*+ ii.dispenced_quantaty + " in " + ii.dispenced_date**/);
                    }
                    foreach (var d in Items2)
                    {
                        listBox1.Items.Add(" and dispenced by quantaty = " + d.despenced_quantaty + " in date " + d.depenced_date);
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
                    int Item_Id = int.Parse(comboBox1.Text);
                    int First_Stock_Id = int.Parse(comboBox2.Text);
                    int second_Stock_Id = int.Parse(comboBox3.Text);
                    int Third_Stock_Id = int.Parse(comboBox4.Text);
                    var Items1 = (from sp in model.Supply_permission
                                  join s in model.Stocks
                                  on sp.Stock_Id equals s.Stock_Id
                                  join i in model.Items
                                  on sp.Item_Id equals i.Item_Id
                                  
                                  where sp.permission_Date >= x && sp.permission_Date <= y && sp.Item_Id == Item_Id && (sp.Stock_Id == First_Stock_Id || sp.Stock_Id == second_Stock_Id || sp.Stock_Id == Third_Stock_Id)
                                  select new
                                  {
                                      Stock_ID = sp.Stock_Id,
                                      Stock_Name = s.Stock_Name,
                                      item_ID = i.Item_Id,
                                      Item_Name = i.Item_Name,
                                      spplied_quantity = sp.Quantity,
                                      supplied_date = sp.permission_Date,
                                      
                                  });
                    var Items2 = (from dp in model.Dispence_Permission
                                  join s in model.Stocks
                                  on dp.Stock_Id equals s.Stock_Id
                                  join i in model.Items
                                  on dp.Item_Id equals i.Item_Id
                                  where dp.Permission_Date >= x && dp.Permission_Date <= y && dp.Item_Id == Item_Id && (dp.Stock_Id == First_Stock_Id || dp.Stock_Id == second_Stock_Id || dp.Stock_Id == Third_Stock_Id)
                                  select new
                                  {
                                        despenced_quantaty = dp.Quantity,
                                        depenced_date = dp.Permission_Date
                                  });

                    listBox1.Items.Clear();
                    foreach (var ii in Items1)
                    {
                        listBox1.Items.Add("the item with id " + ii.item_ID + " with name " + ii.Item_Name + " in stock " + ii.Stock_Name + " is supplied by quantaty= " + ii.spplied_quantity + " in " + ii.supplied_date /*+ " and dispenced by quantaty= " /*+ ii.dispenced_quantaty + " in " + ii.dispenced_date**/);
                    }
                    foreach (var d in Items2)
                    {
                        listBox1.Items.Add(" and dispenced by quantaty = " + d.despenced_quantaty +" in date " + d.depenced_date);
                    }
                }
            }
        }
    }
}
