<%@ WebHandler Language="C#" Class="info" %>

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

public class info : IHttpHandler {
    public struct Array
    {
        public Double diedai;
        public Double time;
        public Double pareto_num;
    }
    
    public void ProcessRequest (HttpContext context) {
      Array array = new Array { };

        string conn = System.Configuration.ConfigurationManager.AppSettings["Connstr"];
        SqlConnection con = new SqlConnection(conn);//建立连接
        con.Open();

        String sqlcom1;//id="+i
        SqlCommand cmd1;
        String sqlcom2;//id="+i
        SqlCommand cmd2;
        //    String sqlcom11 = "Select feb from raining where id=1";

            array.diedai = 4000;
            sqlcom1 = "Select time from info where diedai=4000";
            cmd1 = new SqlCommand(sqlcom1, con);
            array.time = (Double)cmd1.ExecuteScalar();
            sqlcom2 = "Select pareto_num from info where diedai=4000";
            cmd2 = new SqlCommand(sqlcom2, con);
            array.pareto_num = (Double)cmd2.ExecuteScalar();



            context.Response.Write(new JavaScriptSerializer().Serialize(array));
       // con.Close();

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}