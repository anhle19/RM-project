using Guna.UI2.WinForms;
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
    public partial class FrmBillList : SampleAdd
    {
        public FrmBillList()
        {
            InitializeComponent();
        }

        public int MainID = 0;
        private void FrmBillList_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            string qry = @"Select MainID, TableName, WaiterName, orderType, status, total 
                            from tblMain where status <> 'Pending' ";

            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvTable);
            lb.Items.Add(dgvWaiter);
            lb.Items.Add(dgvType);
            lb.Items.Add(dgvStatus);
            lb.Items.Add(dgvTotal);

            MainClass.LoadData(qry, DataGridViewBills, lb);

        }

        private void DataGridViewBills_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // For serial no
            int count = 0;

            foreach (DataGridViewRow row in DataGridViewBills.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        private void DataGridViewBills_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Edit selected row
            if (DataGridViewBills.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                MainID = Convert.ToInt32(DataGridViewBills.CurrentRow.Cells["dgvid"].Value);
                this.Close();
            }
            
        }
    }
}
