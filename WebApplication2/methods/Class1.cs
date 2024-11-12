using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.methods
{
    public class Class1
    
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;
        DataTable dt;

        string s = ConfigurationManager.ConnectionStrings["practice"].ToString();
        public int insert(Register r)
        {
            con = new SqlConnection(s);
            con.Open();
            cmd = new SqlCommand("insert into practice values(@id,@name,@dept,@yop)", con);
            cmd.Parameters.AddWithValue("@id", r.id);
            cmd.Parameters.AddWithValue("@name", r.name);
            cmd.Parameters.AddWithValue("@dept", r.dept);
            cmd.Parameters.AddWithValue("@yop", r.yop);
            int res = cmd.ExecuteNonQuery();
            return res;
        }

        public int update(Register r)
        {
            con = new SqlConnection(s);
            con.Open();
            cmd = new SqlCommand("up", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", r.id);
            cmd.Parameters.AddWithValue("@name", r.name);
            cmd.Parameters.AddWithValue("@dept", r.dept);
            cmd.Parameters.AddWithValue("@yop", r.yop);
            int res = cmd.ExecuteNonQuery();
            return res;
        }

        List<Register> list = new List<Register>();

        public List<Register> show() 
        {
            con = new SqlConnection(s);
            con.Open();
            cmd = new SqlCommand("select * from practice", con);
            dr=cmd.ExecuteReader();
            while(dr.Read())
            {
                Register r = new Register()
                {
                    id = Convert.ToInt16(dr[0].ToString()),
                    name=dr[1].ToString(),
                    dept=dr[2].ToString(),
                    yop = Convert.ToInt32(dr[3].ToString())
                };
                list.Add(r);
            }
            return list;
        }

        public Register showid(Register r)
        {
            Register rr = new Register();
            con = new SqlConnection(s);
            con.Open();
            cmd = new SqlCommand("select * from practice where id=@id", con);
            cmd.Parameters.AddWithValue("@id", r.id);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                rr.id = Convert.ToInt16(dr[0].ToString());
                rr.name = dr[1].ToString();
                rr.dept = dr[2].ToString();
                rr.yop = Convert.ToInt32(dr[3].ToString());
            }
            return rr;
        }
    }
}

