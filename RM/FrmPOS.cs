using RM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace RM
{
    public partial class FrmPOS : Form
    {
        public FrmPOS()
        {
            InitializeComponent();
        }

        public int MainID = 0;
        public string OrderType;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Load categories and product to Panel
        private void FrmPOS_Load(object sender, EventArgs e)
        {
            DataGridViewPOS.BorderStyle = BorderStyle.FixedSingle;
            AddCategory();

            ProductPanel.Controls.Clear();
            LoadProduct();
        }

        // add categories buttons to panel
        private void AddCategory()
        {
            string qry = "Select * from Category";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CategoryPanel.Controls.Clear();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.FillColor = Color.FromArgb(50,55,89);
                    b.Size = new Size(134,45);
                    b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    b.Text = row["catName"].ToString();

                    //Event for click category button
                    b.Click += new EventHandler(b_Click);
                    CategoryPanel.Controls.Add(b);
                }
            }
        }

        //show product by click category buttons
        private void b_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender;
            foreach (var item in ProductPanel.Controls)
            {
                var product = (ucProduct)item;
                product.Visible = product.PCategory.ToLower().Contains(b.Text.Trim().ToLower());
            }
        }
        

        //Add item to datagridview
        private void AddItems(string id, string name, string proID, string cat, string price, Image image)
        {
            try
            {
                var w = new ucProduct()
                {
                    PName = name,
                    PPrice = price,
                    PCategory = cat,
                    PImage = image,
                    id = Convert.ToInt32(proID)
                };

                ProductPanel.Controls.Add(w);
                w.onSelect += (ss, ee) =>
                {
                    var wdg = (ucProduct)ss;
                    foreach (DataGridViewRow item in DataGridViewPOS.Rows)
                    {
                        //this will check it product already there then a one to quantity and update price
                        if (Convert.ToInt32(item.Cells["dgvproID"].Value) == wdg.id)
                        {
                            item.Cells["dgvQty"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) + 1;
                            item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) *
                                                            double.Parse(item.Cells["dgvPrice"].Value.ToString());
                            return;
                        }
                    }
                    //this line add new product first for sr# and second 0 from id
                    DataGridViewPOS.Rows.Add(new object[] { 0, 0, wdg.PName, wdg.id, 1, wdg.PPrice, wdg.PPrice });
                    GetTotal();
                };
            }
            catch (Exception)
            {

                MessageBox.Show("Error");
            }
        }

        //Load product to panel
        private void LoadProduct()
        {
            string qry = "Select * from products inner join category on catID = CategoryID";
            SqlCommand cmd = new SqlCommand(qry,MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                Byte[] imagearray = (byte[])item["pImage"];
                byte[] imagebytearray = imagearray;

                AddItems("0",item["pName"].ToString(), item["pID"].ToString(), item["catName"].ToString(),
                    item["pPrice"].ToString(), Image.FromStream(new MemoryStream(imagearray)));

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in ProductPanel.Controls)
            {
                var product = (ucProduct)item;
                product.Visible = product.PName.ToLower().Contains(txtSearch.Text.Trim().ToLower());
            }
        }

        private void DataGridViewPOS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //for serial no
            int count = 0;
            foreach (DataGridViewRow row in DataGridViewPOS.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        private void GetTotal()
        {
            double total = 0;
            lblTotal.Text = "";
            foreach (DataGridViewRow row in DataGridViewPOS.Rows)
            {
                total += double.Parse(row.Cells["dgvAmount"].Value.ToString());
            }

            lblTotal.Text = total.ToString("N2");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnDin.Checked = false;
            btnDelivery.Checked = false;
            btnTakeAway.Checked = false;
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            lblTotal.Text = "0.00";
            DataGridViewPOS.Rows.Clear();
            MainID = 0;
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            OrderType = "Delivery";
        }

        private void btnTakeAway_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            OrderType = "Take Away";
        }

        private void btnDin_Click(object sender, EventArgs e)
        {
            OrderType = "Din in";
            //need to create form for table selection and waiter selection
            FrmTableSelect frm = new FrmTableSelect();
            MainClass.BlurBackground(frm);
            if(lblTable.Text != "")
            {
                lblTable.Text = frm.TableName;
                lblTable.Visible = true;
            }
            else
            {
                lblTable.Text = "";
                lblTable.Visible = false;
            }
            FrmWaiterSelect frm2 = new FrmWaiterSelect();
            MainClass.BlurBackground(frm2);
            if (lblWaiter.Text != "")
            {
                lblWaiter.Text = frm2.WaiterName;
                lblWaiter.Visible = true;
            }
            else
            {
                lblWaiter.Text = "";
                lblWaiter.Visible = false;
            }
        }

        private void btnKOT_Click(object sender, EventArgs e)
        {
            //Save data into database
            //Create tables
            string qry1 = "";//Main table
            string qry2 = "";//Detail table

            int detailID = 0;
            if(MainID == 0)
            {
                qry1 = @"Insert into tblMain Values(@aDate, @aTime, @TableName, @WaiterName, @status, @orderType,
                            @total, @received, @change); 
                            Select SCOPE_IDENTITY()";
                //This line will get recent add id value
            }
            else//Update detail
            {
                qry1 = @"Update tblMain Set status = @status, total = @total, received = @received, change = @change
                         where MainID = @ID";
            }


            SqlCommand cmd = new SqlCommand(qry1,MainClass.con);
            cmd.Parameters.AddWithValue("@MainID", MainID);
            cmd.Parameters.AddWithValue("@aDate", Convert.ToDateTime(DateTime.Now.Date));
            cmd.Parameters.AddWithValue("@aTime", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@TableName", lblTable.Text);
            cmd.Parameters.AddWithValue("@WaiterName", lblWaiter.Text);
            cmd.Parameters.AddWithValue("@status", "Pending");
            cmd.Parameters.AddWithValue("orderType", OrderType);
            cmd.Parameters.AddWithValue("total", Convert.ToDouble(lblTotal.Text));// as we only saving data for kitchen value will update when payment received
            cmd.Parameters.AddWithValue("@received", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@change", Convert.ToDouble(0));

            try
            {
                if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                if (MainID == 0) { MainID = Convert.ToInt32(cmd.ExecuteScalar()); } else { cmd.ExecuteNonQuery(); }
                if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                foreach (DataGridViewRow row in DataGridViewPOS.Rows)
                {
                    detailID = Convert.ToInt32(row.Cells["dgvid"].Value);

                    if (detailID == 0)
                    {
                        qry2 = @" Insert into tblDetails Values( @MainID, @proID, @qty, @price, @amount)";
                    }
                    else
                    {
                        qry2 = @" Update tblDetails Set proID = @proID, qty = @qty, price = @price, amount = @amount 
                            where DetailID = @ID";
                    }

                    SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                    cmd2.Parameters.AddWithValue("@DetailID", detailID);
                    cmd2.Parameters.AddWithValue("@MainID", MainID);
                    cmd2.Parameters.AddWithValue("@proID", Convert.ToInt32(row.Cells["dgvproID"].Value));
                    cmd2.Parameters.AddWithValue("@qty", Convert.ToInt32(row.Cells["dgvQty"].Value));
                    cmd2.Parameters.AddWithValue("@price", Convert.ToDouble(row.Cells["dgvPrice"].Value));
                    cmd2.Parameters.AddWithValue("@amount", Convert.ToDouble(row.Cells["dgvAmount"].Value));

                    if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                    cmd2.ExecuteNonQuery();
                    if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
                }
                POSMessageBox.Show("Saved Successfully");
                MainID = 0;
                detailID = 0;
                DataGridViewPOS.Rows.Clear();
                lblTable.Text = "";
                lblWaiter.Text = "";
                lblTable.Visible = false;
                lblWaiter.Visible = false;
                lblTotal.Text = "0.00";
            }
            catch (Exception)
            {
                MessageBox.Show("Check the order again!!!");
            }
            
        }

        public int id = 0;
        private void btnBillList_Click(object sender, EventArgs e)
        {
            FrmBillList frm = new FrmBillList();
            MainClass.BlurBackground(frm);

            if (frm.MainID > 0)
            {
                id = frm.MainID;
                LoadEntries();
            }
        }

        //Load data from bill list to FrmPos 
        private void LoadEntries()
        {
            string qry = @"Select * from tblMain m
                                inner join tblDetails d on m.MainID = d.MainID
                                inner join products p on p.pID = d.proID
                                where d.MainID = " + id + "";

            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows[0]["orderType"].ToString() == "Delivery")
            {
                btnTakeAway.Checked = false;
                btnDin.Checked = false;
                btnDelivery.Checked = true;
                lblTable.Visible = false;
                lblWaiter.Visible = false;
            }
            if (dt.Rows[0]["orderType"].ToString() == "Take Away") 
            {
                btnDin.Checked = false;
                btnDelivery.Checked = false;
                btnTakeAway.Checked = true;
                lblTable.Visible = false;
                lblWaiter.Visible = false;
            }
            else
            {
                btnTakeAway.Checked = false;
                btnDelivery.Checked = false;
                btnDin.Checked = true;
                lblTable.Visible = true;
                lblWaiter.Visible = true;
            }

            DataGridViewPOS.Rows.Clear();

            foreach (DataRow item in dt.Rows)
            {
                lblTable.Text = item["TableName"].ToString();
                lblWaiter.Text = item["WaiterName"].ToString();
                string detailID = item["DetailID"].ToString();
                string proName = item["pName"].ToString();
                string proid = item["proID"].ToString();
                string qty = item["qty"].ToString();
                string price = item["price"].ToString();
                string amount = item["amount"].ToString();

                Object[] obj = {0, detailID, proName, proid, qty, price, amount};
                DataGridViewPOS.Rows.Add(obj);
            }
            GetTotal();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            FrmCheckOut frm = new FrmCheckOut();
            frm.MainID = id;
            frm.total = double.Parse(lblTotal.Text);
            MainClass.BlurBackground(frm);
            MainID = 0;
            DataGridViewPOS.Rows.Clear();
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            lblTotal.Text = "0.00";
        }
    }
}
