using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM.Model
{
    public partial class FrmProductAdd : SampleAdd
    {
        public FrmProductAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        string filepath;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg, .png)|* .png; *.jpg";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                filepath = ofd.FileName;
                txtImage.Image = new Bitmap(filepath);
            }
        }
        public int cID = 0;

        private void FrmProductAdd_Load(object sender, EventArgs e)
        {
            // For combobox fill
            string qry = "Select catID 'id' , catName 'name' from category ";
            MainClass.CBFill(qry, cbCategory);

            if(cID>0)// For updates
            {
                cbCategory.SelectedValue = cID;
            }

            if(id>0)
            {
                ForUpdateLoadData();
            }
        }

        Byte[] imageByteArray;
        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0)
            {
                qry = "Insert into products Values(@Name, @price, @cat, @img)";
            }
            else
            {
                qry = "Update products Set pName = @Name, pPrice = @price, CategoryID = @cat, pImage = @img where pID = @id";
            }

            //For image
            Image temp = new Bitmap(txtImage.Image);
            MemoryStream ms = new MemoryStream();
            temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            imageByteArray = ms.ToArray();

            Hashtable ht = new Hashtable();
            if (txtName.Text != "" && txtPrice.Text != "")
            {
                ht.Add("@id", id);
                ht.Add("@Name", txtName.Text);
                ht.Add("@price", txtPrice.Text);
                ht.Add("@cat", Convert.ToInt32(cbCategory.SelectedValue));
                ht.Add("@img", imageByteArray);

                if (MainClass.SQl(qry, ht) > 0)
                {
                    guna2MessageDialog1.Show("Saved successfully...");
                    id = 0;
                    cID = 0;
                    txtName.Text = "";
                    txtPrice.Text = "";
                    cbCategory.SelectedIndex = -1;
                    txtImage.Image = RM.Properties.Resources.picBlue;
                    txtName.Focus();
                }
            }
            else
                guna2MessageDialog1.Show("Check the information");
        }

        private void ForUpdateLoadData()
        {
            string qry = @"Select * from products where pid = " + id + "";
            SqlCommand cmd = new SqlCommand(qry,MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["pName"].ToString();
                txtPrice.Text = dt.Rows[0]["pPrice"].ToString();

                Byte[] imageArray = (byte[])(dt.Rows[0]["pImage"]);
                byte[] imageByteArray = imageArray;
                txtImage.Image = Image.FromStream(new MemoryStream(imageArray));
            }
        }
    }
}
