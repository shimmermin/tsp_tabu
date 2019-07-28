<%@ WebHandler Language="C#" Class="Foot_500" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Threading;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Data.SqlClient;

public class Foot_500 : IHttpHandler {

    public struct Array
    {
        public double dis;
        public double time;
    }

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        int n = 80;//数组行数

        Array[] array = new Array[n];

        SqlConnection con = new SqlConnection();//建立连接

        con.ConnectionString = "server=(local);uid=sa;pwd=1hu2xin3min;database=ldq";//连接数据库
        con.Open();

        String sqlcom1;//id="+i
        SqlCommand cmd1;
        String sqlcom2;//id="+i
        SqlCommand cmd2;
        //    String sqlcom11 = "Select feb from raining where id=1";
        String sqlcom3;
        SqlCommand cmd3;
        sqlcom3 = "select count(*) from tlist_500";
        cmd3 = new SqlCommand(sqlcom3, con);
        var num = (Int32)cmd3.ExecuteScalar();
        for (int i = 1; i <= num; i++)
        {
            sqlcom1 = "Select dis from tlist_500 where id=" + i;
            cmd1 = new SqlCommand(sqlcom1, con);
            array[i - 1].dis = (Double)cmd1.ExecuteScalar();
            sqlcom2 = "Select time from tlist_500 where id=" + i;
            cmd2 = new SqlCommand(sqlcom2, con);
            array[i - 1].time = (Double)cmd2.ExecuteScalar();

            //array[i-1].dis = (Double)cmd1.ExecuteScalar();
        }

        /*       var jser    = new JavaScriptSerializer();

               var json    = jser.Serialize(array);

               var arrays = jser.Deserialize<List<A>>(json);*/
        context.Response.Write(new JavaScriptSerializer().Serialize(array));
        con.Close();

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}