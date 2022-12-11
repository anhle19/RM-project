using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM
{
    internal class MainClass
    {
        public static readonly string con_string = "Data Source=LAPTOP-7F516QL8\\SQLEXPRESS;Initial Catalog=RM;Integrated Security=True";
        public static SqlConnection con = new SqlConnection(con_string);

        //Method check user validation
        public static bool IsValidUser(string user, string pass)
        {
            bool isValid = false;
            string qry = "Select * from users where username = '"+user+ "' and upass ='" + pass + "' ";
            SqlCommand cmd = new SqlCommand(qry, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                isValid = true;
                USER = dt.Rows[0]["uname"].ToString();
            }
            return isValid;
        }
        //create property for username
        public static string user;
        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }
        

    }
}
