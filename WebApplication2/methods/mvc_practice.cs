using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;//
using System.Data.SqlClient;//
using System.Configuration;
using WebApplication2.Models;
using System.Web.UI;
using System.Xml.Linq;

namespace WebApplication2.methods
{
    public class mvc_practice
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;
        DataTable dt;

        string s = ConfigurationManager.ConnectionStrings["veltech"].ToString();

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int InsertMethod(form1 objform)
        {
                con = new SqlConnection(s);
                con.Open();
            cmd = new SqlCommand("insert into register values(@id,@name,@age,@mailid,@course)", con);
            cmd.Parameters.AddWithValue("@id", objform.id);
            cmd.Parameters.AddWithValue("@name", objform.name);
            cmd.Parameters.AddWithValue("@age", objform.age);
            cmd.Parameters.AddWithValue("@mailid", objform.mailid);
            cmd.Parameters.AddWithValue("@course", objform.course);
            int res = cmd.ExecuteNonQuery();
            return res;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public int UpdateMethod(form1 objform)
        {
            con = new SqlConnection(s);
            con.Open();
            cmd = new SqlCommand("Update register set name=@name,age=@age,mailid=@mailid,course=@course where id=@id", con);
            cmd.Parameters.AddWithValue("@name", objform.name);
            cmd.Parameters.AddWithValue("@age", objform.age);
            cmd.Parameters.AddWithValue("@mailid", objform.mailid);
            cmd.Parameters.AddWithValue("@course", objform.course);
            cmd.Parameters.AddWithValue("@id", objform.id);
            int res = cmd.ExecuteNonQuery();
            return res;
        }
        public int DeleteMethod(form1 objform)
        {

            con = new SqlConnection(s);
            con.Open();
            cmd = new SqlCommand("delete from register where id=@id", con);
            cmd.Parameters.AddWithValue("@id", objform.id);

            int res = cmd.ExecuteNonQuery();
            return res;
        }
        List<form1> li = new List<form1>();
        public List<form1> ShowAll_Method()
        {
            con = new SqlConnection(s);
            con.Open();
            cmd = new SqlCommand("select * from register", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                form1 f = new form1()
                {
                    id = Convert.ToInt32(dr["id"].ToString()),
                    name = dr["name"].ToString(),
                    age = Convert.ToInt32(dr["age"].ToString()),
                    course = dr["course"].ToString(),
                    mailid = dr["mailid"].ToString()

                };
                li.Add(f);
            }
            return li;
        }
        public form1 ShowSlingle_method(form1 f)
        {
            form1 objf = new form1(); 
            con = new SqlConnection(s);
            con.Open();
            cmd = new SqlCommand("select * from register where id=@id", con);
            cmd.Parameters.AddWithValue("@id", f.id);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                objf.id = Convert.ToInt32(dr["id"].ToString());
                objf.name = dr["name"].ToString();
                objf.age = Convert.ToInt32(dr["age"].ToString());
                objf.course = dr["course"].ToString();
                objf.mailid = dr["mailid"].ToString();
            }

            return objf;
        }

    }
}