using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Threading;

public partial class tsp : System.Web.UI.Page
{
    public static TimeSpan subtimen;
    public static int Pareto_num;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
       
    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
       // Response.Write(" 开始");
        Program p = new Program();
        p.tsp(p);          
        subtimen = p.time_interval();
        Pareto_num = p.paretoNum();       
      
        cishu.Text = "迭代次数：";
        Label1.Text = "500次";
        shijian.Text = "运行时间：";
        Label2.Text = subtimen.ToString();
        num.Text = "求出Pareto解数量：";
        Label3.Text = Pareto_num.ToString();
        Label4.Text = "个";

    }

   
}