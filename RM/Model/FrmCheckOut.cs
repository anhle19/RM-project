using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RM.Model
{
    public partial class FrmCheckOut : SampleAdd
    {
        public FrmCheckOut()
        {
            InitializeComponent();
        }

        public double total=0;
        public bool check = false;
        public int MainID = 0;
        private void txtReceived_TextChanged(object sender, EventArgs e)
        {
            if (txtReceived.Text != "")
            {
                double amt = total;
                double received = 0;
                double change = 0;

                double.TryParse(txtReceived.Text, out received);

                change = received - amt;
                txtChange.Text = change.ToString();
                if (change >= 0) check = true;
            }
            else
                guna2MessageDialog1.Show("Check received");

        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = @"Update tblMain Set total = @total, received = @received, change = @change, status = 'Paid' where MainID = @id";

            Hashtable ht = new Hashtable();

            if(check)
            {
                ht.Add("@id", MainID);
                ht.Add("@total", txtAmount.Text);
                ht.Add("@received", txtReceived.Text);
                ht.Add("@change", txtChange.Text);

                if (MainClass.SQl(qry, ht) > 0)
                {
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Paid Successfull");
                    this.Close();
                }
            }
            else
                guna2MessageDialog1.Show("Check received");


        }

        //Create dialog to preview document before print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "PaymentBill";
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("Bill", 500, 400);
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            PrintPreviewDialog previewDlg = new PrintPreviewDialog();
            previewDlg.Document = printDoc;
            previewDlg.ShowDialog();
        }

        //Create document page have data to print bill
        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            DataGridView grid = DataGridViewCheckOut;
            Font font = new Font("Courier New", 12);
            Font title = new Font("Courier New", 18,FontStyle.Bold);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;

            int rowHeight = grid.RowTemplate.Height;
            int headerHeight = grid.ColumnHeadersHeight;

            int cellWidth;
            int cellHeight;

            int x = 0;
            int y = 0;
            graphics.DrawString("Payment Bill", title, Brushes.Black, x, y);
            y += headerHeight;
            //Draw column
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                cellWidth = grid.Columns[i].Width;
                cellHeight = headerHeight;
                RectangleF cellRect = new RectangleF(x, y, cellWidth, cellHeight);
                graphics.DrawString(grid.Columns[i].HeaderText, font, Brushes.Black, cellRect);

                x += cellWidth;
            }

            x = 0;
            y += headerHeight;

            //Draw row
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    cellWidth = grid.Columns[j].Width;
                    cellHeight = rowHeight;
                    RectangleF cellRect = new RectangleF(x, y, cellWidth, cellHeight);
                    graphics.DrawString(grid[j, i].Value.ToString(), font, Brushes.Black, cellRect);

                    x += cellWidth;
                }

                x = 0;
                y += rowHeight;
            }
            graphics.DrawString("Total price: "+total.ToString()+"$", font, Brushes.Black, x,y);
        }
    
        //Load bill data from Pos
        private void LoadData()
        {
            string qry = @"Select * from tblMain m
                                inner join tblDetails d on m.MainID = d.MainID
                                inner join products p on p.pID = d.proID
                                where d.MainID = " + MainID + "";

            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            DataGridViewCheckOut.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                string proName = item["pName"].ToString();
                string qty = item["qty"].ToString();
                string price = item["price"].ToString();
                string amount = item["amount"].ToString();

                Object[] obj = { 0, proName, qty, price, amount };
                DataGridViewCheckOut.Rows.Add(obj);
            }
        }
        //Call Load Data function for form
        private void FrmCheckOut_Load(object sender, EventArgs e)
        {
            LoadData();
            txtAmount.Text = total.ToString();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
        //Format Serialnumber for row in datagridview start from 1
        private void DataGridViewCheckOut_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in DataGridViewCheckOut.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }
    }
}
