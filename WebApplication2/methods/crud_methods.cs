using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebApplication2.Models;
using System.Configuration;
using System.Web.WebSockets;
using System.Xml.Linq;

namespace WebApplication2.methods
{
    public class crud_methods
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        DataSet ds;
        string s = ConfigurationManager.ConnectionStrings["veltech"].ToString();
        public int Insert_method(Register r)
        {
            con = new SqlConnection(s);
            con.Open();
            cmd = new SqlCommand("insert into student values(@id,@name,@dept,@yop)", con);
            cmd.Parameters.AddWithValue("@id", r.id);
            cmd.Parameters.AddWithValue("@name", r.name);
            cmd.Parameters.AddWithValue("@dept", r.dept);
            cmd.Parameters.AddWithValue("@yop", r.yop);
            int res = cmd.ExecuteNonQuery();
            return res;


        }
        public int Update_method(Register r)
        {

            con = new SqlConnection(s);
            con.Open();
            cmd = new SqlCommand("update  student  set name=@name,dept=@dept,yop=@yop where id=@id", con);
            cmd.Parameters.AddWithValue("@id", r.id);
            cmd.Parameters.AddWithValue("@name", r.name);
            cmd.Parameters.AddWithValue("@dept", r.dept);
            cmd.Parameters.AddWithValue("@yop", r.yop);
            int res = cmd.ExecuteNonQuery();
            return res;


        }

        public int Delete_method(Register r)
        {
            con = new SqlConnection(s);
            con.Open();
            cmd = new SqlCommand("delete from student where id=@id", con);
            cmd.Parameters.AddWithValue("@id", r.id);
            int res = cmd.ExecuteNonQuery();
            return res;
        }
        
        List<Register> l = new List<Register>();

        public List<Register> Showall_method()
        {

            con = new SqlConnection(s);
            con.Open();
            cmd = new SqlCommand("select * from student", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Register r = new Register()
                {
                    id = Convert.ToInt32(dr[0].ToString()),
                    name = dr[1].ToString(),
                    dept = dr[2].ToString(),
                    yop = Convert.ToInt32(dr[3].ToString())
                };
                l.Add(r);
            }
            return l;
        }

        public Register Showid_method(Register r)
        {
            Register r1 = new Register();
            con = new SqlConnection(s);
            con.Open();
            cmd = new SqlCommand("select * from student where id=@id", con);
            cmd.Parameters.AddWithValue("@id", r.id);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                r1.id = Convert.ToInt32(dr[0].ToString());
                r1.name = dr[1].ToString();
                r1.dept = dr[2].ToString();
                r1.yop = Convert.ToInt32(dr[3].ToString());
            }
            return r1;
        }
    }
}