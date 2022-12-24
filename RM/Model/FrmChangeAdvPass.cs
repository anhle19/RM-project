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
    public partial class FrmChangeAdvPass : SampleAdd
    {
        public FrmChangeAdvPass()
        {
            InitializeComponent();
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            int id = 1;
            string qry = "Update advance Set pass = @pass where id = @id";
            Hashtable ht = new Hashtable();

            if (txtPass.Text != "" && txtConfirm.Text != "")
            {
                if (txtPass.Text == txtConfirm.Text)
                {
                    ht.Add("@id", id);
                    ht.Add("@Pass", txtPass.Text);

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
