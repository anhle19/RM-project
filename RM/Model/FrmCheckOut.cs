using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void FrmCheckOut_Load(object sender, EventArgs e)
        {
            txtAmount.Text = total.ToString();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
