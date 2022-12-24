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
    public partial class FrmCategoryAdd : SampleAdd
    {
        public FrmCategoryAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0)
            {
                qry = "Insert into category Values(@Name)";
            }
            else
            {
                qry = "Update category Set catname = @Name where catiD = @id";
            }

            Hashtable ht = new Hashtable();

            if (txtName.Text != "")
            {
                ht.Add("@id", id);
                ht.Add("@Name", txtName.Text);

                if (MainClass.SQl(qry, ht) > 0)
                {
                    guna2MessageDialog1.Show("Saved successfully...");
                    id = 0;
                    txtName.Text = "";
                    txtName.Focus();
                }
            }
            else
                guna2MessageDialog1.Show("Check the information");
        }
    }
}
