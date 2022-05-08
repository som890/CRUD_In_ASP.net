using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppSoccer.Models
{
    public class SoccerList
    {
        DBConnection db;

        public SoccerList()
        {
            db = new DBConnection();
        }
        public List<Soccer> GetStudents(string ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
            {
                sql = "SELECT * FROM Soccer";
            }
            else
            {
                sql = "SELECT * FROM Soccer WHERE ID = " + ID;

            }
            List<Soccer> stuList = new List<Soccer>();
            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();

            Soccer tmpStu;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpStu = new Soccer();
                tmpStu.ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                tmpStu.TenDoi = dt.Rows[i]["TenDoi"].ToString();
                tmpStu.LoGo = dt.Rows[i]["LoGo"].ToString();
                tmpStu.SoCauThu = Convert.ToInt32(dt.Rows[i]["SoCauThu"].ToString());
                tmpStu.NgayTao = Convert.ToDateTime(dt.Rows[i]["NgayTao"].ToString());
                stuList.Add(tmpStu);
            }
            return stuList;
        }

        public void AddStudent(Soccer stu)
        {
            string sql = "INSERT INTO Soccer(TenDoi, LoGo,SoCauThu,NgayTao) VALUES(N'" + stu.TenDoi + "', N'" + stu.LoGo + "', N'" + stu.SoCauThu + "', N'" + stu.NgayTao + "')";

            SqlConnection con = db.getConnection();
            SqlCommand cm = new SqlCommand(sql, con);

            con.Open();
            cm.ExecuteNonQuery();
            cm.Dispose();
            con.Close();
        }
        public void UpdateStudent(Soccer stu)
        {
            string sql = "UPDATE Soccer SET TenDoi = N'" + stu.TenDoi + "', LoGo = N'" + stu.LoGo + "',SoCauThu = N'" + stu.SoCauThu + "', NgayTao = N'" + stu.NgayTao + "' WHERE ID = " + stu.ID;

            SqlConnection con = db.getConnection();
            SqlCommand cm = new SqlCommand(sql, con);

            con.Open();
            cm.ExecuteNonQuery();
            cm.Dispose();
            con.Close();
        }

        public void DeleteStudent(Soccer stu)
        {
            string sql = "DELETE Soccer WHERE ID = " + stu.ID;
            SqlConnection con = db.getConnection();
            SqlCommand cm = new SqlCommand(sql, con);

            con.Open();
            cm.ExecuteNonQuery();
            cm.Dispose();
            con.Close();
        }
    }
}
