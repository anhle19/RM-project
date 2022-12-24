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

namespace RM.Model
{
    public partial class FrmChangeUserInfor : SampleAdd
    {
        public FrmChangeUserInfor()
        {
            InitializeComponent();
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            int id = 1;
            string qry = "Update users Set username = @uName, upass = @Pass, uName = @Name, uphone = @Phone where userID = @id";
            Hashtable ht = new Hashtable();

            if (txtUsername.Text != "" && txtPass.Text != "" && txtConfirm.Text != "" && txtPhone.Text != "" && txtName.Text != "")
            {
                if (txtPass.Text == txtConfirm.Text)
                {
                    ht.Add("@id", id);
                    ht.Add("@uName", txtUsername.Text);
                    ht.Add("@Pass", txtPass.Text);
                    ht.Add("@Name", txtName.Text);
                    ht.Add("@Phone", txtPhone.Text);

                    if (MainClass.SQl(qry, ht) > 0)
                    {
                        guna2MessageDialog1.Show("Saved successfully...");
                        this.Close();
                    }
                    else
                        guna2MessageDialog1.Show("Error");
                }
                else
                    guna2MessageDialog1.Show("Check the information");
            }
            else
                guna2MessageDialog1.Show("Check the information");
        }
    }
}
