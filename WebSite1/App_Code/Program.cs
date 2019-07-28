using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Windows.Forms;
/// <summary>
///Program 的摘要说明
/// </summary>
public class Program
{
   // public DateTime datetime1;
  //  public DateTime datetime2;
    public static DateTime datetime1, datetime2, datetime3, datetime4, datetime5, datetime6, datetime7, datetime8, datetime9, datetime10, datetime11, datetime12, datetime13, datetime14, datetime15, datetime16;
   /* public TimeSpan subtime1;
    public TimeSpan subtime;
    public TimeSpan subtime50;
    public TimeSpan subtime100;
    public TimeSpan subtime150;
    public TimeSpan subtime200;
    public TimeSpan subtime300;
    public TimeSpan subtime400;
    public TimeSpan subtime500;*/
    public int pareto_num;

    public double[,] initial(int n)     //初始化函数，计算出距离数组
    {
        double[,] city = new double[34, 2] { { 9932 ,4439}, { 10109, 4351 }, { 11552, 3472 }, { 10302, 3290 }, { 8776 ,3333 }, { 7040, 4867 }, { 9252, 4278}, { 9395, 4539 }, { 11101,2540}, { 9825, 5087 }, 
                                                  { 10047, 4879 }, { 10227 ,4648 }, { 10027, 4229 }, { 9878, 4211 }, { 9087, 4065 }, { 10438, 4075 }, { 10382 ,3865 }, { 11196, 3563 }, { 11075 ,3543 }, { 11544 ,3365}, 
                                                  { 11915, 2900 }, { 11305, 3189 }, { 11073 ,3137 }, { 10950 ,3394 }, { 11576, 2575 }, {12239 ,2785 }, { 11529, 2226 }, { 9328 ,4006 }, { 10012, 3811 }, { 9952 ,3410 },
                                                   {10612, 2954 },{10349, 2784 },{11747, 2469 },{11673, 2461 }
                                                  };
        //城市坐标数组**************************************************************输入



        string sql = "";//用来盛放sql语句
        SqlConnection con = new SqlConnection();//建立连接

        con.ConnectionString = "server=(local);uid=sa;pwd=1hu2xin3min;database=ldq";//连接数据库
        con.Open();         //打开连接

        String sql_1 = "DELETE  FROM city";
        SqlCommand com_1 = new SqlCommand(sql_1, con);
        com_1.ExecuteNonQuery();

        for (int i = 0; i < n - 1; i++)
        {
            sql = "insert  into city(x,y) values('" + city[i, 0] + "','" + city[i, 1] + "')";//这块是用来把数据插入数据库表中的
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
        }

        con.Close();






        double[,] arraydis = new double[n - 1, n - 1];
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                arraydis[i, j] = Math.Pow(Math.Pow(city[i, 0] - city[j, 0], 2) + Math.Pow(city[i, 1] - city[j, 1], 2), 0.5);
            }

            //arraydis[i, i] = 0;
        }
        return arraydis;//城市距离数组

    }
    public double[,] time()
    {//30个城市之间时间数组
        double[,] arraytime = new double[34, 34]{
             {0.5, 0.6 ,1.2, 0.8 , 1.0,     1.3 , 0.8, 0.4 , 0.5, 0.9 ,    1.2, 1.5 , 1.1, 1.2 ,1.3,    1.4 , 1.6, 1.3, 0.9, 0.8  ,     0.6,0.4, 0.5 , 0.6,0.8 ,     0.9, 1.3 ,1.0, 0.9 ,0.8,1.2,0.5,0.4,0.7},
             {0.8, 0.4 ,1.2, 0.8 , 1.2,     1.5 , 0.5, 0.9 , 0.4, 0.5 ,    0.7, 0.6,  1.6, 1.3 ,1.0,    0.9 , 0.8 ,1.6, 1.3, 0.7,       0.7, 0.6,1.2 ,1.3, 0.6,      0.8 ,1.4 , 1.6,1.0, 1.1,0.5,0.4, 0.5 , 0.6},
             {1.3 , 0.8, 0.4 , 0.5, 0.9 ,   1.2, 1.5 , 1.1, 1.2 ,1.3,      1.3 , 0.8, 0.4 , 0.5, 0.9 ,  1.3, 0.9, 0.8  ,0.7, 0.6,       0.8 ,1.4 , 1.6,1.0, 1.1,     0.7, 0.6,1.2 ,1.3, 0.6,0.6 ,1.4 , 1.6,1.0},
             {1.5 , 0.5, 0.9 , 0.4, 0.5 ,   0.5, 0.6 ,1.2, 0.8 , 1.0,      1.2, 1.5 , 1.1, 1.2 ,1.3,    0.4 , 0.5, 0.9 , 1.2, 1.5 ,     0.7, 0.6,0.4, 0.5 , 0.6,     1.0, 1.3 , 0.8, 0.4 , 0.5,0.7, 0.5, 0.9 , 1.2 },
             {0.5, 0.6 ,1.2, 0.8 , 1.0,     1.3 , 0.8, 0.4 , 0.5, 0.9 ,    0.5, 0.9 , 1.2, 1.5 , 1.1,   1.3, 1.4 , 1.6, 1.3, 0.9,       0.6,0.4, 0.5 , 0.6,0.8 ,     0.8 ,0.9, 1.3 ,1.0, 0.9,0.8 , 1.6, 1.3, 0.9 },
             {1.5 , 0.5, 0.9 , 0.4, 0.5 ,   0.5, 0.6 ,1.2, 0.8 , 1.0,      1.2, 1.5 , 1.1, 1.2 ,1.3,    0.4 , 0.5, 0.9 , 1.2, 1.5 ,     0.7, 0.6,0.4, 0.5 , 0.6,     1.0, 1.3 , 0.8, 0.4 , 0.5,0.9 , 1.1, 1.2 ,1.3},
             {0.5, 0.6 ,1.2, 0.8 , 1.0,     1.3 , 0.8, 0.4 , 0.5, 0.9 ,    0.5, 0.9 , 1.2, 1.5 , 1.1,   1.3, 1.4 , 1.6, 1.3, 0.9,       0.6,0.4, 0.5 , 0.6,0.8 ,     0.8 ,0.9, 1.3 ,1.0, 0.9,1.0, 0.4 , 0.5, 0.9 },
             {1.3 , 0.8, 0.4 , 0.5, 0.9 ,   1.2, 1.5 , 1.1, 1.2 ,1.3,      1.3 , 0.8, 0.4 , 0.5, 0.9 ,  1.3, 0.9, 0.8  ,0.7, 0.6,       0.8 ,1.4 , 1.6,1.0, 1.1,     0.7, 0.6,1.2 ,1.3, 0.6,2.5 , 1.1, 1.2 ,1.3},
             {1.5 , 0.5, 0.9 , 0.4, 0.5 ,   0.5, 0.6 ,1.2, 0.8 , 1.0,      1.2, 1.5 , 1.1, 1.2 ,1.3,    0.4 , 0.5, 0.9 , 1.2, 1.5 ,     0.7, 0.6,0.4, 0.5 , 0.6,     1.0, 1.3 , 0.8, 0.4 , 0.5,3.5, 0.4 , 0.5, 0.9 },
             {0.5, 0.6 ,1.2, 0.8 , 1.0,     1.3 , 0.8, 0.4 , 0.5, 0.9 ,    0.5, 0.9 , 1.2, 1.5 , 1.1,   1.3, 1.4 , 1.6, 1.3, 0.9,       0.6,0.4, 0.5 , 0.6,0.8 ,     0.8 ,0.9, 1.3 ,1.0, 0.9,1.5, 0.8  ,0.7, 0.6 },
             
             
             {1.3 , 0.8, 0.4 , 0.5, 0.9 ,   1.2, 1.5 , 1.1, 1.2 ,1.3,      1.3 , 0.8, 0.4 , 0.5, 0.9 ,  1.3, 0.9, 0.8  ,0.7, 0.6,       0.8 ,1.4 , 1.6,1.0, 1.1,     0.7, 0.6,1.2 ,1.3, 0.6,1.3 ,0.4, 0.5 , 0.6},
             {0.5, 0.6 ,1.2, 0.8 , 1.0,     1.3 , 0.8, 0.4 , 0.5, 0.9 ,    0.5, 0.9 , 1.2, 1.5 , 1.1,   1.3, 1.4 , 1.6, 1.3, 0.9,       0.6,0.4, 0.5 , 0.6,0.8 ,     0.8 ,0.9, 1.3 ,1.0, 0.9,0.5, 0.8  ,0.7, 0.6 },
             {1.3 , 0.8, 0.4 , 0.5, 0.9 ,   1.2, 1.5 , 1.1, 1.2 ,1.3,      1.3 , 0.8, 0.4 , 0.5, 0.9 ,  1.3, 0.9, 0.8  ,0.7, 0.6,       0.8 ,1.4 , 1.6,1.0, 1.1,     0.7, 0.6,1.2 ,1.3, 0.6,1.6, 0.5, 0.9 , 1.2 },
             {1.5 , 0.5, 0.9 , 0.4, 0.5 ,   0.5, 0.6 ,1.2, 0.8 , 1.0,      1.2, 1.5 , 1.1, 1.2 ,1.3,    0.4 , 0.5, 0.9 , 1.2, 1.5 ,     0.7, 0.6,0.4, 0.5 , 0.6,     1.0, 1.3 , 0.8, 0.4 , 0.5,1.5, 0.5 , 0.6,0.8 },
             {0.5, 0.6 ,1.2, 0.8 , 1.0,     1.3 , 0.8, 0.4 , 0.5, 0.9 ,    0.5, 0.9 , 1.2, 1.5 , 1.1,   1.3, 1.4 , 1.6, 1.3, 0.9,       0.6,0.4, 0.5 , 0.6,0.8 ,     0.8 ,0.9, 1.3 ,1.0, 0.9,0.4, 1.3 ,1.0, 0.9 },
             {0.8, 0.4 ,1.2, 0.8 , 1.2,     1.5 , 0.5, 0.9 , 0.4, 0.5 ,    0.7, 0.6,  1.6, 1.3 ,1.0,    0.9 , 0.8 ,1.6, 1.3, 0.7,       0.7, 0.6,1.2 ,1.3, 0.6,      0.8 ,1.4 , 1.6,1.0, 1.1,0.2,1.3, 0.9, 0.8},
             {1.3 , 0.8, 0.4 , 0.5, 0.9 ,   1.2, 1.5 , 1.1, 1.2 ,1.3,      1.3 , 0.8, 0.4 , 0.5, 0.9 ,  1.3, 0.9, 0.8  ,0.7, 0.6,       0.8 ,1.4 , 1.6,1.0, 1.1,     0.7, 0.6,1.2 ,1.3, 0.6 ,0.5,0.4, 0.5 , 0.6},     
             {0.8, 0.4 ,1.2, 0.8 , 1.2,     1.5 , 0.5, 0.9 , 0.4, 0.5 ,    0.7, 0.6,  1.6, 1.3 ,1.0,    0.9 , 0.8 ,1.6, 1.3, 0.7,       0.7, 0.6,1.2 ,1.3, 0.6,      0.8 ,1.4 , 1.6,1.0, 1.1,0.7, 1.6, 1.3, 0.9},   
             {0.5, 0.6 ,1.2, 0.8 , 1.0,     1.3 , 0.8, 0.4 , 0.5, 0.9 ,    1.2, 1.5 , 1.1, 1.2 ,1.3,    1.4 , 1.6, 1.3, 0.9, 0.8  ,     0.6,0.4, 0.5 , 0.6,0.8 ,     0.9, 1.3 ,1.0, 0.9 ,0.8,0.8, 0.5 , 0.6,0.8}, 
             {1.3 , 0.8, 0.4 , 0.5, 0.9 ,   1.2, 1.5 , 1.1, 1.2 ,1.3,      1.3 , 0.8, 0.4 , 0.5, 0.9 ,  1.3, 0.9, 0.8  ,0.7, 0.6,       0.8 ,1.4 , 1.6,1.0, 1.1,     0.7, 0.6,1.2 ,1.3, 0.6 ,0.9,1.0, 0.9,1.5},   
             
             
             {1.3 , 0.8, 0.4 , 0.5, 0.9 ,   1.2, 1.5 , 1.1, 1.2 ,1.3,      1.3 , 0.8, 0.4 , 0.5, 0.9 ,  1.3, 0.9, 0.8  ,0.7, 0.6,       0.8 ,1.4 , 1.6,1.0, 1.1,     0.7, 0.6,1.2 ,1.3, 0.6,0.5 , 0.8  ,0.7, 0.6},
             {1.5 , 0.5, 0.9 , 0.4, 0.5 ,   0.5, 0.6 ,1.2, 0.8 , 1.0,      1.2, 1.5 , 1.1, 1.2 ,1.3,    0.4 , 0.5, 0.9 , 1.2, 1.5 ,     0.7, 0.6,0.4, 0.5 , 0.6,     1.0, 1.3 , 0.8, 0.4 , 0.5,1.4 , 1.4 , 1.6, 1.3},
             {0.5, 0.6 ,1.2, 0.8 , 1.0,     1.3 , 0.8, 0.4 , 0.5, 0.9 ,    0.5, 0.9 , 1.2, 1.5 , 1.1,   1.3, 1.4 , 1.6, 1.3, 0.9,       0.6,0.4, 0.5 , 0.6,0.8 ,     0.8 ,0.9, 1.3 ,1.0, 0.9,1.3, 1.6, 1.3, 0.9 },         
             {1.3 , 0.8, 0.4 , 0.5, 0.9 ,   1.2, 1.5 , 1.1, 1.2 ,1.3,      1.3 , 0.8, 0.4 , 0.5, 0.9 ,  1.3, 0.9, 0.8  ,0.7, 0.6,       0.8 ,1.4 , 1.6,1.0, 1.1,     0.7, 0.6,1.2 ,1.3, 0.6,0.4 , 0.5 , 0.6,0.8},
             {0.5, 0.6 ,1.2, 0.8 , 1.0,     1.3 , 0.8, 0.4 , 0.5, 0.9 ,    0.5, 0.9 , 1.2, 1.5 , 1.1,   1.3, 1.4 , 1.6, 1.3, 0.9,       0.6,0.4, 0.5 , 0.6,0.8 ,     0.8 ,0.9, 1.3 ,1.0, 0.9,0.3 ,1.4 , 1.6,1.0},
             {1.3 , 0.8, 0.4 , 0.5, 0.9 ,   1.2, 1.5 , 1.1, 1.2 ,1.3,      1.3 , 0.8, 0.4 , 0.5, 0.9 ,  1.3, 0.9, 0.8  ,0.7, 0.6,       0.8 ,1.4 , 1.6,1.0, 1.1,     0.7, 0.6,1.2 ,1.3, 0.6,1.4, 1.3, 0.9, 0.8 }, 
             {0.5, 0.6 ,1.2, 0.8 , 1.0,     1.3 , 0.8, 0.4 , 0.5, 0.9 ,    1.2, 1.5 , 1.1, 1.2 ,1.3,    1.4 , 1.6, 1.3, 0.9, 0.8  ,     0.6,0.4, 0.5 , 0.6,0.8 ,     0.9, 1.3 ,1.0, 0.9 ,0.8,1.6, 0.8 ,1.6, 1.3},
             {1.3 , 0.8, 0.4 , 0.5, 0.9 ,   1.2, 1.5 , 1.1, 1.2 ,1.3,      1.3 , 0.8, 0.4 , 0.5, 0.9 ,  1.3, 0.9, 0.8  ,0.7, 0.6,       0.8 ,1.4 , 1.6,1.0, 1.1,     0.7, 0.6,1.2 ,1.3, 0.6,1.7, 0.9, 0.8  ,0.7 },     
             {0.8, 0.4 ,1.2, 0.8 , 1.2,     1.5 , 0.5, 0.9 , 0.4, 0.5 ,    0.7, 0.6,  1.6, 1.3 ,1.0,    0.9 , 0.8 ,1.6, 1.3, 0.7,       0.7, 0.6,1.2 ,1.3, 0.6,      0.8 ,1.4 , 1.6,1.0, 1.1,1.8,0.4, 0.5 , 0.6},   
             {0.5, 0.6 ,1.2, 0.8 , 1.0,     1.3 , 0.8, 0.4 , 0.5, 0.9 ,    0.5, 0.9 , 1.2, 1.5 , 1.1,   1.3, 1.4 , 1.6, 1.3, 0.9,       0.6,0.4, 0.5 , 0.6,0.8 ,     0.8 ,0.9, 1.3 ,1.0, 0.9,1.9, 0.9, 0.8  ,0.7 },
              {0.5, 0.6 ,1.2, 0.8 , 1.0,     1.3 , 0.8, 0.4 , 0.5, 0.9 ,    0.5, 0.9 , 1.2, 1.5 , 1.1,   1.3, 1.4 , 1.6, 1.3, 0.9,       0.6,0.4, 0.5 , 0.6,0.8 ,     0.8 ,0.9, 1.3 ,1.0, 0.9,0.5, 0.6,1.2 ,1.3 },
               {1.5 , 0.5, 0.9 , 0.4, 0.5 ,   0.5, 0.6 ,1.2, 0.8 , 1.0,      1.2, 1.5 , 1.1, 1.2 ,1.3,    0.4 , 0.5, 0.9 , 1.2, 1.5 ,     0.7, 0.6,0.4, 0.5 , 0.6,     1.0, 1.3 , 0.8, 0.4 , 0.5,1.4 , 1.4 , 1.6, 1.3},
               {0.5, 0.6 ,1.2, 0.8 , 1.0,     1.3 , 0.8, 0.4 , 0.5, 0.9 ,    0.5, 0.9 , 1.2, 1.5 , 1.1,   1.3, 1.4 , 1.6, 1.3, 0.9,       0.6,0.4, 0.5 , 0.6,0.8 ,     0.8 ,0.9, 1.3 ,1.0, 0.9,1.5, 0.8  ,0.7, 0.6 },
               {0.8, 0.4 ,1.2, 0.8 , 1.2,     1.5 , 0.5, 0.9 , 0.4, 0.5 ,    0.7, 0.6,  1.6, 1.3 ,1.0,    0.9 , 0.8 ,1.6, 1.3, 0.7,       0.7, 0.6,1.2 ,1.3, 0.6,      0.8 ,1.4 , 1.6,1.0, 1.1,0.5,0.4, 0.5 , 0.6}
             };


        return arraytime;
    }

    public int[] differSamenessRandomNum(int num, int minValue, int maxValue)//在区间[minValue,maxValue]取出num个互不相同的随机数，返回数组。
    {
        Random ra = new Random(unchecked((int)DateTime.Now.Ticks));//保证产生的数字的随机性

        int[] arrNum = new int[num];//初始解数组

        int tmp = 0;

        for (int i = 0; i <= num - 1; i++)
        {
            tmp = ra.Next(minValue, maxValue); //随机取数

            arrNum[i] = getRandomNum(arrNum, tmp, minValue, maxValue, ra); //取出值赋到数组中

        }

        return arrNum;//随机抽取的初始解

    }



    public int getRandomNum(int[] arrNum, int tmp, int minValue, int maxValue, Random ra)
    {


        int n = 0;
    step: for (n = 0; n < arrNum.Length - 1; n++)
        {
            if (arrNum[n] == tmp)
            {
                tmp = ra.Next(minValue, maxValue); //重新随机获取。
                goto step;
            }
        }
        return tmp;

    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="tsp"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public double[,] two_opt(double[] current, int n, Program prop, double[,] arraydis, double[,] arraytime, int l)   //2-opt邻域产生：输入当前城市序列，输入城市数30，输入要交换的城市编号
    {
        double[] temp = new double[n];

        double[,] lin_list = new double[l, n + 3];//邻域表结构：城市序列+总距离+总时间+禁忌状态
        int m = 0;
        for (int gap = 3; gap <= n - 1; gap++)
        {
            for (int i = 0, r = m; i < n - gap; i++, r++)
            {
                for (int k = 1; k < gap; k++)
                {
                    temp[i + k] = current[i + gap - k];
                }
                for (int q = 0; q <= i; q++)
                {
                    temp[q] = current[q];
                }
                for (int q = i + gap; q < n; q++)
                {
                    temp[q] = current[q];
                }
                for (int s = 0; s < n; s++)
                {
                    lin_list[r, s] = temp[s];
                }

                lin_list[r, n] = prop.distance(temp, n, arraydis);
                lin_list[r, n + 1] = prop.count_time(temp, n, arraytime);
                lin_list[r, n + 2] = 0;
                m++;
            }

        }

        return lin_list;
    }



    public double distance(double[] tsp, int n, double[,] arraydis)   //算总距离函数
    {
        double dis = 0;
        for (int i = 0; i < n - 1; i++)
        {
            dis += arraydis[(int)tsp[i] - 1, (int)tsp[i + 1] - 1];

        }

        return dis;
    }

    public double count_time(double[] tsp, int n, double[,] arraytime)   //算总时间函数
    {
        double t = 0;
        for (int i = 0; i < n - 1; i++)
        {
            t += arraytime[(int)tsp[i] - 1, (int)tsp[i + 1] - 1];

        }

        return t;
    }


    public double[,] array_pareto(double[,] lin_list, int n, int l, int hou_num)    //对候选解集合排序函数//擂台赛找出pareto集
    {                                                          //输入邻域表，输出候选表

        double[,] hou_list = new double[hou_num, n + 3];
        for (int i = 0; i < n + 3; i++)//第一个邻域解进入候选表，
        {
            //进入候选表
            hou_list[0, i] = lin_list[0, i];
        }
        for (int j = 1; j < l; j++)//从第二个邻域解开始去打擂
        {//遍历邻域表
            int score = 0;//计算打擂得分            
            //打擂
            int q = 0;

            for (int g = 0; hou_list[g, 0] == 100; g++)//q从不为0的候选表解开始//候选表的结构可能是
            {                                                                  //100
                q++;                                                           //3    4    5
            }                                                                  //0或者是null
            while (hou_list[q, 0] != 0)
            {
                for (int g = q; hou_list[g, 0] == 100; g++)//q从不为0的候选表解开始//候选表的结构可能是
                {                                                                  //100
                    q++;                                                           //3    4    5
                }
                if (lin_list[j, n] <= hou_list[q, n] && lin_list[j, n + 1] < hou_list[q, n + 1] || lin_list[j, n] < hou_list[q, n] && lin_list[j, n + 1] <= hou_list[q, n + 1])//打擂成功
                {   //赢了一次
                    //删除输的一方
                    hou_list[q, 0] = 100;
                    score++;
                }

                else if (lin_list[j, n] > hou_list[q, n] && lin_list[j, n + 1] > hou_list[q, n + 1])//打擂失败
                {   //败了一次
                    score--;
                }
                else if (lin_list[j, n] > hou_list[q, n] && lin_list[j, n + 1] < hou_list[q, n + 1] || lin_list[j, n] < hou_list[q, n] && lin_list[j, n + 1] > hou_list[q, n + 1])//打擂平手
                {   //平了一次
                    //不计分
                }
                else//各种无效的等于的情况
                {
                    score--; //视为输

                }
                q++;

            }
            //判断score的值，看要不要将打擂者加入pareto解集
            if (score > 0)
            {
                //赢，加入pareto解集
                for (int i = 0; i < n + 3; i++)
                {
                    hou_list[q, i] = lin_list[j, i];
                }
            }
            else if (score == 0)
            {
                //平，加入pareto解集
                for (int i = 0; i < n + 3; i++)
                {
                    hou_list[q, i] = lin_list[j, i];
                }
            }
            else
            {
                //输，不加入解集  score<0
            }


        }


        return hou_list;
    }

    public double[] seeds(double[,] hou_list, int n, int hou_num)    //候选解产生种子解
    //输入候选表，输出种子解
    {
        double[] seed = new double[n + 3];
        //候选表长度为351
        //在0到350中随机选一个数a
        int a;
        Random ra = new Random(unchecked((int)DateTime.Now.Ticks));//保证产生的数字的随机性;
        // a = ra.Next(0, n - 1);
        //判断候选解集是否已经无法选出种子解
        int num = 0;
        int num1 = 0;
        int j = 0;
        while (hou_list[j, 0] != 0)
        {
            if (hou_list[j, 0] == 100 || hou_list[j, n + 2] == 1)
            {
                num++;
            }
            num1++;
            j++;
        }
        if (num == num1)
        {//如果候选集已经没有可用的解
            seed = null;
            return seed;
        }
        else
        {
            a = ra.Next(0, hou_num - 1);
            while (hou_list[a, 0] == 100 || hou_list[a, 0] == 0 || hou_list[a, n + 2] == 1)//候选表中禁忌状态为1的解不能被选，无效解不能被选
            {
                a = ra.Next(0, hou_num - 1); //重新生成种子解
            }
            for (int i = 0; i < n + 3; i++)
            {
                seed[i] = hou_list[a, i];
            }
            return seed;
        }
    }

    public double[] pro_current(double[,] hou_list, double[,] tlist, double[] seed, int n, Program prop, int tlist_num, int hou_num)    //种子解产生当前解//输入种子解，候选表，禁忌表
    //输出当前解
    {
        double[] current = new double[n + 3];

        int tlist_length = prop.tlist_length(tlist, tlist_num);
        int p = 0;
        int d = 0;//迭代次数

        while (seed != null)//d控制循环次数，防止进入死循环，
        {    //即当候选解与禁忌表擂台赛全都失败的时候或者候选表全被禁忌的时候，使用特赦规则

            //如果能产生种子解，判断种子解是否在禁忌表中
            for (int i = 0; i < tlist_length; i++)//种子解与禁忌表匹配
            {
                if (seed[n] == tlist[i, n] && seed[n + 1] == tlist[i, n + 1])
                {
                    p = 1;//种子解在禁忌表中，p=1
                }
            }
            if (p == 0)
            {//种子解不在禁忌表中
                //种子解与禁忌表中的解进行擂台赛
                int score = 0;
                int q = 0;
                for (int g = 0; tlist[g, n + 3] == 100; g++)//q从tlist[34]不为100的解开始打擂//禁忌表第34位的结构可能是
                {                                                                           //100
                    q++;                                                                   //0
                    //100
                }
                while (tlist[q, 0] != 0)
                {
                    for (int g = q; tlist[g, n + 3] == 100; g++)//q从tlist[34]不为100的解开始打擂//禁忌表第34位的结构可能是
                    {                                                                           //100
                        q++;                                                                   //0
                        //100
                    }

                    if (seed[n] <= tlist[q, n] && seed[n + 1] < tlist[q, n + 1] || seed[n] < tlist[q, n] && seed[n + 1] <= tlist[q, n + 1])//打擂成功
                    {   //赢了一次
                        //删除输的一方
                        tlist[q, n + 3] = 100;
                        score++;
                    }

                    else if (seed[n] > tlist[q, n] && seed[n + 1] > tlist[q, n + 1])//打擂失败
                    {   //败了一次
                        score--;
                    }
                    else if (seed[n] > tlist[q, n] && seed[n + 1] < tlist[q, n + 1] || seed[n] < tlist[q, n] && seed[n + 1] > tlist[q, n + 1])//打擂平手
                    {   //平了一次
                        //不计分
                    }
                    else//各种无效的等于的情况
                    {
                        score--; //视为输

                    }
                    q++;

                }

                if (score >= 0)
                {   //判断score的值，打擂成功，将打擂者加入pareto解集
                    //种子解作为current
                    for (int i = 0; i < n + 3; i++)
                    {
                        current[i] = seed[i];
                    }
                    return current;
                }
                else //打擂失败，候选表的解变成无效解，重选种子解
                {
                    d++;
                  //  Console.Write("第几次打擂失败：");
                  //  Console.Write(d);
                  //  Console.Write("\n");
                    for (int j = 0; j < hou_num; j++)
                    {
                        if (seed[n] == hou_list[j, n] && seed[n + 1] == hou_list[j, n + 1])
                        {
                            hou_list[j, 0] = 100;//候选表该解为无效解
                        }
                    }
                   // Console.Write(" 打擂失败后，重选种子解过程\n");
                    seed = prop.seeds(hou_list, n, hou_num);
                    //输出种子解  
                   // Console.Write(" 打擂失败后重选的种子解：\n");
                    if (seed != null)
                    {
                        for (int i = 0; i < n + 3; i++)
                        {

                          //  Console.Write(seed[i] + " ");

                        }
                    }
                    else
                    {
                      //  Console.Write(" 种子解重选失败");
                    }
                    p = 0;//修改种子解在禁忌表中的记录值p，代表新的种子未经判断前不在禁忌表中。

                }

            }
            else
            {//种子解在禁忌表中，更新候选表禁忌状态
               // Console.Write("第几次在禁忌表中：");
                d++;
              //  Console.Write(d);
               // Console.Write("\n");
                //种子解和候选表匹配
                for (int j = 0; j < hou_num; j++)
                {
                    if (seed[n] == hou_list[j, n] && seed[n + 1] == hou_list[j, n + 1])
                    {
                        hou_list[j, n + 2] = 1;//候选表该禁忌状态为1
                    }
                }
               // Console.Write(" 种子解在禁忌表中，重选种子解过程\n");
                seed = prop.seeds(hou_list, n, hou_num);
                //输出种子解  
               // Console.Write(" 种子解在禁忌表中，重选的种子解\n");
                if (seed != null)
                {
                    for (int i = 0; i < n + 3; i++)
                    {

                     //   Console.Write(seed[i] + " ");

                    }
                }
                else
                {
                 //   Console.Write("种子解重选失败 ");
                }
                p = 0;//修改种子解在禁忌表中的记录值p，代表新的种子未经判断前不在禁忌表中。

            }

        }

        //种子解为空，特赦规则，
        //禁忌表中最老的解作为当前解
        Double[] temp = new Double[n + 4];
        //冒泡排序，禁忌表中所有的解根据禁忌长度进行从大到小排序，选择第一个赢的解作为当前解
        for (int m = 1; m < tlist_length; m++)
        {
            for (int i = 0; i < tlist_length - m; i++)
            {
                if (tlist[i, n + 2] < tlist[i + 1, n + 2])
                {
                    for (int j = 0; j < n + 4; j++)
                    {
                        temp[j] = tlist[i, j];
                        tlist[i, j] = tlist[i + 1, j];
                        tlist[i + 1, j] = temp[j];
                    }
                }
            }
        }
        int k = 0;
        while (tlist[k, n + 3] == 100)
        {//跳过无效解
            k++;

        }
        for (int i = 0; i < n + 2; i++)
        {
            current[i] = tlist[k, i];
        }

        current[n + 2] = 0;//当前解，禁忌状态为0
        tlist[k, n + 3] = 100;//从禁忌表中删除该记录
      //  Console.Write(" 候选表无法产生种子解，特赦禁忌表中最老的解为当前解：\n");
        return current;
    }

    //计算禁忌表长度
    public int tlist_length(double[,] tlist, int tlist_num)
    {
        int t_length = 0;
        for (int i = 0; i < tlist_num; i++)
        {
            if (tlist[i, 0] != 0)
            {
                t_length++;
            }

        }
        return t_length;
    }


    public void tsp(Program prop)
    {
       // Program prop = new Program();//实例化类

        int n = 35;//城市数目

        int l = 528;//邻域表解的个数

        int hou_num = 528;//候选表解的个数,与邻域解个数相关

        int tlist_num = 501;//禁忌表解的个数，由于程序设定问题，禁忌表容量大于foot循环步数  每步一个禁忌解，加上一个初始解

        int foot = 500;   //终止准则foot步循环

       // int[] tspx = new int[n];//城市序列

        double[] current = new double[n + 3];//当前解：城市序列+总距离+总时间+禁忌状态

        double[] tspselect = new double[n + 3];//存放一条路径信息：城市序列+总距离+总时间+禁忌状态

        double[] seed = new double[n + 3];//种子解：城市序列+总距离+总时间+禁忌状态

        double[,] lin_list = new double[l, n + 3];//邻域表结构：城市序列+总距离+总时间+禁忌状态

        double[,] hou_list = new double[hou_num, n + 3];//候选表结构：城市序列+总距离+总时间+禁忌状态
        //候选表解的个数为pareto解集的解个数， 候选表解个数未知，暂定100

        double[,] tlist = new double[tlist_num, n + 4];//禁忌表结构：城市序列+总距离+总时间+禁忌长度+输赢状态，  禁忌表个数暂定100，有计算禁忌表解个数的函数



        double[,] arraydis = new double[n, n];//距离矩阵

        double[,] arraytime = new double[n, n];//时间矩阵

        arraydis = prop.initial(n);//初始化产生距离矩阵

        arraytime = prop.time();//初始化产生时间矩阵

        // DateTime datetime1, datetime2, datetime3, datetime4, datetime5, datetime6, datetime7, datetime8, datetime9, datetime10, datetime11, datetime12, datetime13, datetime14, datetime15, datetime16;
       //先清空各个数据表
       
        SqlConnection con5 = new SqlConnection();//建立连接

        con5.ConnectionString = "server=(local);uid=sa;pwd=1hu2xin3min;database=ldq";//连接数据库
        con5.Open();         //打开连接

        String sqlcity = "DELETE  FROM city";
        SqlCommand comcity = new SqlCommand(sqlcity, con5);
        comcity.ExecuteNonQuery();
        String sqltlist_50 = "DELETE  FROM tlist_50";
        SqlCommand com50 = new SqlCommand(sqltlist_50, con5);
        com50.ExecuteNonQuery();
        String sqltlist_100 = "DELETE  FROM tlist_100";
        SqlCommand com100 = new SqlCommand(sqltlist_100, con5);
        com100.ExecuteNonQuery();
        String sqltlist_150 = "DELETE  FROM tlist_150";
        SqlCommand com150 = new SqlCommand(sqltlist_150, con5);
        com150.ExecuteNonQuery();
        String sqltlist_200 = "DELETE  FROM tlist_200";
        SqlCommand com200 = new SqlCommand(sqltlist_200, con5);
        com200.ExecuteNonQuery();
        String sqltlist_300 = "DELETE  FROM tlist_300";
        SqlCommand com300 = new SqlCommand(sqltlist_300, con5);
        com300.ExecuteNonQuery();
        String sqltlist_400 = "DELETE  FROM tlist_400";
        SqlCommand com400 = new SqlCommand(sqltlist_400, con5);
        com400.ExecuteNonQuery();
        String sqltlist_500 = "DELETE  FROM tlist_500";
        SqlCommand com500 = new SqlCommand(sqltlist_500, con5);
        com500.ExecuteNonQuery();
        con5.Close();
       // tspx = prop.differSamenessRandomNum(n, 1, n + 1);//随机产生初始路径

        //下面城市序列为Christofides算法求得的初始解
        int[] tspx = { 4, 14, 5, 9, 10, 11, 1, 12, 13, 28, 16, 15, 17, 18, 23, 22, 21, 19, 2, 20, 25, 32, 33, 24, 8, 26, 31, 30, 3, 29, 0, 7, 6, 27, 4 };

        for (int i = 0; i < n; i++)
        {
            current[i] = tspx[i] + 1;//初始城市序列给当前城市序列，由于Christofides算法中城市序列数组从0开始，而本程序从1开始，所以加1
        }


        double best_dis = 0;                      //初始解总距离
        best_dis = prop.distance(current, n, arraydis);

        double best_time = 0;                   //初始解总时间
        best_time = prop.count_time(current, n, arraytime);

        current[n] = best_dis;//初始城市总距离赋给当前解，
        current[n + 1] = best_time;//初始城市总时间赋给当前解，
        current[n + 2] = 1;//当前解禁忌状态为1
        for (int i = 0; i < n + 2; i++)
        {
            tlist[0, i] = current[i];//当前解加入禁忌表
        }
        tlist[0, n+2] = 1;//第一轮，禁忌长度为1
        tlist[0, n+3] = 0;//未进行擂台赛，默认为赢
       // Console.Write(" 初始解：\n");


        for (int i = 0; i < n + 3; i++)
        {
           // Console.Write(current[i] + " ");//输出初始解，C#中FOR语句中输出字符在一排显示不能使用Console.Writeline（），而用Console.Write（）
        }

        //Console.Write(" \n");

        /*  lin_list = prop.two_opt(current, 30, prop,arraydis,arraytime);//调用two_opt函数，构造邻域表
          //输出邻域表
          Console.Write(" 邻域表：\n");
          for (int j = 0; j < l; j++)
          {
              for (int i = 0; i < 30 + 3; i++)
              {
                  Console.Write(lin_list[j, i] + " ");
              }
              Console.Write(" \n");
              if (j == 74)
              {
                  Console.Write(" *****");
                  Console.Write(" \n");
              }
          }*/
       
        //   DateTime datetime1, datetime2, datetime3, datetime4, datetime5, datetime6, datetime7, datetime8, datetime9, datetime10, datetime11, datetime12, datetime13, datetime14, datetime15;
       // datetime11 = DateTime.Now;
        datetime1 = DateTime.Now;
       /* datetime2 = DateTime.Now;
        datetime3 = DateTime.Now;
        datetime4 = DateTime.Now;
        datetime5 = DateTime.Now;
        datetime6 = DateTime.Now;
        datetime7 = DateTime.Now;
        datetime8 = DateTime.Now;
        datetime9 = DateTime.Now;
        datetime10 = DateTime.Now;
        datetime11 = DateTime.Now;
        datetime12 = DateTime.Now;
        datetime13 = DateTime.Now;
        datetime14 = DateTime.Now;
        datetime15 = DateTime.Now;*/

        //开始迭代
        for (int z = 1; z <= foot; z++)//*************************************最外层循环次数************************************************************
        {
            //产生邻域表
            lin_list = prop.two_opt(current, n, prop, arraydis, arraytime, l);//调用two_opt函数，构造邻域表
            //邻域擂台赛产生pareto解集，构成候选表
            hou_list = prop.array_pareto(lin_list, n, l, hou_num);
            /*   //输出候选表
               Console.Write(" \n");
              Console.Write(" 候选表：\n");
              for (int j = 0; j < hou_num; j++)
              {
                  if (hou_list[j, 0] != 100)
                  {
                      for (int i = 0; i < 30 + 3; i++)
                      {

                          Console.Write(hou_list[j, i] + " ");
                       
                      }
                      Console.Write(" \n");
                  }
               
              }*/

            //候选表选种子解
            seed = prop.seeds(hou_list, n, hou_num);
            //输出种子解  
           // Console.Write(" 候选表选出种子解：\n");
            for (int i = 0; i < n + 3; i++)
            {

              //  Console.Write(seed[i] + " ");

            }
           // Console.Write("\n");
            //种子解作为当前解
            current = prop.pro_current(hou_list, tlist, seed, n, prop, tlist_num, hou_num);
            //输出当前解
          //  Console.Write(" 判断种子解能否作为当前解：\n");
          //  Console.Write(" 当前解：\n");
            for (int i = 0; i < n + 3; i++)
            {

              //  Console.Write(current[i] + " ");

            }
           // Console.Write("\n");
            //current进入禁忌表，修改禁忌状态
           // Console.Write(" 当前解进入禁忌表：\n");
            int tlist_length = prop.tlist_length(tlist, tlist_num);
            for (int i = 0; i < n + 2; i++)
            {
                tlist[tlist_length, i] = current[i];
            }
            tlist[tlist_length, n+2] = 1;//新加入禁忌表的解，禁忌状态为1
            tlist[tlist_length, n+3] = 0;//未进行擂台赛，输赢状态为0
            //更新禁忌表其他解禁忌长度,加1
            for (int j = 0; j < tlist_length; j++)
            {
                tlist[j, n+2]++;
            }
            //输出禁忌表，包含擂台赛失败的解
          //  Console.Write("一轮迭代后的 禁忌表：\n");
            int tlist_length1 = prop.tlist_length(tlist, tlist_num);
            for (int j = 0; j < tlist_length1; j++)
            {

                if (tlist[j, n+3] != 100)
                {
                    for (int i = 0; i < n + 4; i++)
                    {

                     //   Console.Write(tlist[j, i] + " ");

                    }
                 //   Console.Write(" \n");
                }
            }
          //  Console.Write(z);
          //  Console.Write("\n");
            //将禁忌表存入数据库
            if (z == 50)
            {
               datetime2 = DateTime.Now;
                //输出禁忌表，不包含擂台赛失败的解，即均为pareto解集
                // Console.Write(" 第50次迭代的禁忌表：\n");
                string sql1 = "";//用来盛放sql语句
                SqlConnection con1 = new SqlConnection();//建立连接

                con1.ConnectionString = "server=(local);uid=sa;pwd=1hu2xin3min;database=ldq";//连接数据库
              
                int t_length1 = prop.tlist_length(tlist, tlist_num);
                var j_1 = 0;
                for (int j = 0; j < t_length1; j++)
                {
                    if (tlist[j, n + 3] != 100)
                    {
                        /* for (int i = 0; i < n + 4; i++)
                         {

                             Console.Write(tlist[j, i] + " ");

                         }*/
                        con1.Open();
                        // Console.Write(" \n");
                        j_1++;
                        sql1 = "insert  into tlist_50(id,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,ab,cd,ef,gh,ij,kl,mn,op,qr,dis,time,tabu_state) values('" + j_1 + "','" + tlist[j, 0] + "','" + tlist[j, 1] + "','" + tlist[j, 2] + "','" + tlist[j, 3] + "','" + tlist[j, 4] + "','" + tlist[j, 5] + "','" + tlist[j, 6] + "','" + tlist[j, 7] + "','" + tlist[j, 8] + "','" + tlist[j, 9] + "','" + tlist[j, 10] + "','" + tlist[j, 11] + "','" + tlist[j, 12] + "','" + tlist[j, 13] + "','" + tlist[j, 14] + "','" + tlist[j, 15] + "','" + tlist[j, 16] + "','" + tlist[j, 17] + "','" + tlist[j, 18] + "','" + tlist[j, 19] + "','" + tlist[j, 20] + "','" + tlist[j, 21] + "','" + tlist[j, 22] + "','" + tlist[j, 23] + "','" + tlist[j, 24] + "','" + tlist[j, 25] + "','" + tlist[j, 26] + "','" + tlist[j, 27] + "','" + tlist[j, 28] + "','" + tlist[j, 29] + "','" + tlist[j, 30] + "','" + tlist[j, 31] + "','" + tlist[j, 32] + "','" + tlist[j, 33] + "','" + tlist[j, 34] + "','" + tlist[j, 35] + "','" + tlist[j, 36] + "','" + tlist[j, 37] + "')";//这块是用来把数据插入数据库表中的
                        SqlCommand com2 = new SqlCommand(sql1, con1);

                        com2.ExecuteNonQuery();
                        con1.Close();
                        // Console.Write(" \n");
                    }
                }
                datetime3 = DateTime.Now;
                // subtime50 = datetime3.Subtract(datetime2);
               // String text = subtime50.Seconds + "秒";
               //   MessageBox.Show(text, "本次运行时间", MessageBoxButtons.OKCancel);

            }


            else if (z == 100)
            {
                 datetime4 = DateTime.Now;
                //输出禁忌表，不包含擂台赛失败的解，即均为pareto解集
                // Console.Write(" 第50次迭代的禁忌表：\n");
                string sql1 = "";//用来盛放sql语句
                SqlConnection con1 = new SqlConnection();//建立连接

                con1.ConnectionString = "server=(local);uid=sa;pwd=1hu2xin3min;database=ldq";//连接数据库
              
                int t_length1 = prop.tlist_length(tlist, tlist_num);
                var j_1 = 0;
                for (int j = 0; j < t_length1; j++)
                {
                    if (tlist[j, n + 3] != 100)
                    {
                        /* for (int i = 0; i < n + 4; i++)
                         {

                             Console.Write(tlist[j, i] + " ");

                         }*/
                        con1.Open();
                        // Console.Write(" \n");
                        j_1++;

                        sql1 = "insert  into tlist_100(id,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,ab,cd,ef,gh,ij,kl,mn,op,qr,dis,time,tabu_state) values('" + j_1 + "','" + tlist[j, 0] + "','" + tlist[j, 1] + "','" + tlist[j, 2] + "','" + tlist[j, 3] + "','" + tlist[j, 4] + "','" + tlist[j, 5] + "','" + tlist[j, 6] + "','" + tlist[j, 7] + "','" + tlist[j, 8] + "','" + tlist[j, 9] + "','" + tlist[j, 10] + "','" + tlist[j, 11] + "','" + tlist[j, 12] + "','" + tlist[j, 13] + "','" + tlist[j, 14] + "','" + tlist[j, 15] + "','" + tlist[j, 16] + "','" + tlist[j, 17] + "','" + tlist[j, 18] + "','" + tlist[j, 19] + "','" + tlist[j, 20] + "','" + tlist[j, 21] + "','" + tlist[j, 22] + "','" + tlist[j, 23] + "','" + tlist[j, 24] + "','" + tlist[j, 25] + "','" + tlist[j, 26] + "','" + tlist[j, 27] + "','" + tlist[j, 28] + "','" + tlist[j, 29] + "','" + tlist[j, 30] + "','" + tlist[j, 31] + "','" + tlist[j, 32] + "','" + tlist[j, 33] + "','" + tlist[j, 34] + "','" + tlist[j, 35] + "','" + tlist[j, 36] + "','" + tlist[j, 37] + "')";//这块是用来把数据插入数据库表中的
                        SqlCommand com2 = new SqlCommand(sql1, con1);

                        com2.ExecuteNonQuery();
                        con1.Close();
                        // Console.Write(" \n");
                    }
                }
               datetime5 = DateTime.Now;
                //subtime100 = datetime5.Subtract(datetime4);
            }

            else if (z == 150)
            {
                datetime6 = DateTime.Now;
                //输出禁忌表，不包含擂台赛失败的解，即均为pareto解集
                // Console.Write(" 第50次迭代的禁忌表：\n");
                string sql1 = "";//用来盛放sql语句
                SqlConnection con1 = new SqlConnection();//建立连接

                con1.ConnectionString = "server=(local);uid=sa;pwd=1hu2xin3min;database=ldq";//连接数据库
             
                int t_length1 = prop.tlist_length(tlist, tlist_num);
                var j_1 = 0;
                for (int j = 0; j < t_length1; j++)
                {
                    if (tlist[j, n + 3] != 100)
                    {
                        /* for (int i = 0; i < n + 4; i++)
                         {

                             Console.Write(tlist[j, i] + " ");

                         }*/
                        con1.Open();
                        // Console.Write(" \n");
                        j_1++;

                        sql1 = "insert  into tlist_150(id,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,ab,cd,ef,gh,ij,kl,mn,op,qr,dis,time,tabu_state) values('" + j_1 + "','" + tlist[j, 0] + "','" + tlist[j, 1] + "','" + tlist[j, 2] + "','" + tlist[j, 3] + "','" + tlist[j, 4] + "','" + tlist[j, 5] + "','" + tlist[j, 6] + "','" + tlist[j, 7] + "','" + tlist[j, 8] + "','" + tlist[j, 9] + "','" + tlist[j, 10] + "','" + tlist[j, 11] + "','" + tlist[j, 12] + "','" + tlist[j, 13] + "','" + tlist[j, 14] + "','" + tlist[j, 15] + "','" + tlist[j, 16] + "','" + tlist[j, 17] + "','" + tlist[j, 18] + "','" + tlist[j, 19] + "','" + tlist[j, 20] + "','" + tlist[j, 21] + "','" + tlist[j, 22] + "','" + tlist[j, 23] + "','" + tlist[j, 24] + "','" + tlist[j, 25] + "','" + tlist[j, 26] + "','" + tlist[j, 27] + "','" + tlist[j, 28] + "','" + tlist[j, 29] + "','" + tlist[j, 30] + "','" + tlist[j, 31] + "','" + tlist[j, 32] + "','" + tlist[j, 33] + "','" + tlist[j, 34] + "','" + tlist[j, 35] + "','" + tlist[j, 36] + "','" + tlist[j, 37] + "')";//这块是用来把数据插入数据库表中的
                        SqlCommand com2 = new SqlCommand(sql1, con1);
                        com2.ExecuteNonQuery();
                        con1.Close();
                        // Console.Write(" \n");
                    }
                }
                datetime7 = DateTime.Now;
                //subtime150 = datetime7.Subtract(datetime6);
            }

            else if (z == 200)
            {
                 datetime8 = DateTime.Now;
                //输出禁忌表，不包含擂台赛失败的解，即均为pareto解集
                // Console.Write(" 第50次迭代的禁忌表：\n");
                string sql1 = "";//用来盛放sql语句
                SqlConnection con1 = new SqlConnection();//建立连接

                con1.ConnectionString = "server=(local);uid=sa;pwd=1hu2xin3min;database=ldq";//连接数据库
               
                int t_length1 = prop.tlist_length(tlist, tlist_num);
                var j_1 = 0;
                for (int j = 0; j < t_length1; j++)
                {
                    if (tlist[j, n + 3] != 100)
                    {
                        /* for (int i = 0; i < n + 4; i++)
                         {

                             Console.Write(tlist[j, i] + " ");

                         }*/
                        con1.Open();
                        // Console.Write(" \n");
                        j_1++;

                        sql1 = "insert  into tlist_200(id,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,ab,cd,ef,gh,ij,kl,mn,op,qr,dis,time,tabu_state) values('" + j_1 + "','" + tlist[j, 0] + "','" + tlist[j, 1] + "','" + tlist[j, 2] + "','" + tlist[j, 3] + "','" + tlist[j, 4] + "','" + tlist[j, 5] + "','" + tlist[j, 6] + "','" + tlist[j, 7] + "','" + tlist[j, 8] + "','" + tlist[j, 9] + "','" + tlist[j, 10] + "','" + tlist[j, 11] + "','" + tlist[j, 12] + "','" + tlist[j, 13] + "','" + tlist[j, 14] + "','" + tlist[j, 15] + "','" + tlist[j, 16] + "','" + tlist[j, 17] + "','" + tlist[j, 18] + "','" + tlist[j, 19] + "','" + tlist[j, 20] + "','" + tlist[j, 21] + "','" + tlist[j, 22] + "','" + tlist[j, 23] + "','" + tlist[j, 24] + "','" + tlist[j, 25] + "','" + tlist[j, 26] + "','" + tlist[j, 27] + "','" + tlist[j, 28] + "','" + tlist[j, 29] + "','" + tlist[j, 30] + "','" + tlist[j, 31] + "','" + tlist[j, 32] + "','" + tlist[j, 33] + "','" + tlist[j, 34] + "','" + tlist[j, 35] + "','" + tlist[j, 36] + "','" + tlist[j, 37] + "')";//这块是用来把数据插入数据库表中的
                        SqlCommand com2 = new SqlCommand(sql1, con1);

                        com2.ExecuteNonQuery();
                        con1.Close();
                        // Console.Write(" \n");
                    }
                }
                datetime9 = DateTime.Now;
                //subtime200 = datetime9.Subtract(datetime8);
            }
            else if (z == 300)
            {
                datetime10 = DateTime.Now;
                //输出禁忌表，不包含擂台赛失败的解，即均为pareto解集
                // Console.Write(" 第50次迭代的禁忌表：\n");
                string sql1 = "";//用来盛放sql语句
                SqlConnection con1 = new SqlConnection();//建立连接

                con1.ConnectionString = "server=(local);uid=sa;pwd=1hu2xin3min;database=ldq";//连接数据库
             
                int t_length1 = prop.tlist_length(tlist, tlist_num);
                var j_1 = 0;
                for (int j = 0; j < t_length1; j++)
                {
                    if (tlist[j, n + 3] != 100)
                    {
                        /* for (int i = 0; i < n + 4; i++)
                         {

                             Console.Write(tlist[j, i] + " ");

                         }*/
                        con1.Open();
                        // Console.Write(" \n");
                        j_1++;

                        sql1 = "insert  into tlist_300(id,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,ab,cd,ef,gh,ij,kl,mn,op,qr,dis,time,tabu_state) values('" + j_1 + "','" + tlist[j, 0] + "','" + tlist[j, 1] + "','" + tlist[j, 2] + "','" + tlist[j, 3] + "','" + tlist[j, 4] + "','" + tlist[j, 5] + "','" + tlist[j, 6] + "','" + tlist[j, 7] + "','" + tlist[j, 8] + "','" + tlist[j, 9] + "','" + tlist[j, 10] + "','" + tlist[j, 11] + "','" + tlist[j, 12] + "','" + tlist[j, 13] + "','" + tlist[j, 14] + "','" + tlist[j, 15] + "','" + tlist[j, 16] + "','" + tlist[j, 17] + "','" + tlist[j, 18] + "','" + tlist[j, 19] + "','" + tlist[j, 20] + "','" + tlist[j, 21] + "','" + tlist[j, 22] + "','" + tlist[j, 23] + "','" + tlist[j, 24] + "','" + tlist[j, 25] + "','" + tlist[j, 26] + "','" + tlist[j, 27] + "','" + tlist[j, 28] + "','" + tlist[j, 29] + "','" + tlist[j, 30] + "','" + tlist[j, 31] + "','" + tlist[j, 32] + "','" + tlist[j, 33] + "','" + tlist[j, 34] + "','" + tlist[j, 35] + "','" + tlist[j, 36] + "','" + tlist[j, 37] + "')";//这块是用来把数据插入数据库表中的
                        SqlCommand com2 = new SqlCommand(sql1, con1);

                        com2.ExecuteNonQuery();
                        con1.Close();
                        // Console.Write(" \n");
                    }
                }
                datetime11 = DateTime.Now;
                //subtime300 = datetime11.Subtract(datetime10);
            }
            else if (z == 400)
            {
                datetime12 = DateTime.Now;
                //输出禁忌表，不包含擂台赛失败的解，即均为pareto解集
                // Console.Write(" 第50次迭代的禁忌表：\n");
                string sql1 = "";//用来盛放sql语句
                SqlConnection con1 = new SqlConnection();//建立连接

                con1.ConnectionString = "server=(local);uid=sa;pwd=1hu2xin3min;database=ldq";//连接数据库
            
                int t_length1 = prop.tlist_length(tlist, tlist_num);
                var j_1 = 0;
                for (int j = 0; j < t_length1; j++)
                {
                    if (tlist[j, n + 3] != 100)
                    {
                        /* for (int i = 0; i < n + 4; i++)
                         {

                             Console.Write(tlist[j, i] + " ");

                         }*/
                        con1.Open();
                        // Console.Write(" \n");
                        j_1++;

                        sql1 = "insert  into tlist_400(id,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,ab,cd,ef,gh,ij,kl,mn,op,qr,dis,time,tabu_state) values('" + j_1 + "','" + tlist[j, 0] + "','" + tlist[j, 1] + "','" + tlist[j, 2] + "','" + tlist[j, 3] + "','" + tlist[j, 4] + "','" + tlist[j, 5] + "','" + tlist[j, 6] + "','" + tlist[j, 7] + "','" + tlist[j, 8] + "','" + tlist[j, 9] + "','" + tlist[j, 10] + "','" + tlist[j, 11] + "','" + tlist[j, 12] + "','" + tlist[j, 13] + "','" + tlist[j, 14] + "','" + tlist[j, 15] + "','" + tlist[j, 16] + "','" + tlist[j, 17] + "','" + tlist[j, 18] + "','" + tlist[j, 19] + "','" + tlist[j, 20] + "','" + tlist[j, 21] + "','" + tlist[j, 22] + "','" + tlist[j, 23] + "','" + tlist[j, 24] + "','" + tlist[j, 25] + "','" + tlist[j, 26] + "','" + tlist[j, 27] + "','" + tlist[j, 28] + "','" + tlist[j, 29] + "','" + tlist[j, 30] + "','" + tlist[j, 31] + "','" + tlist[j, 32] + "','" + tlist[j, 33] + "','" + tlist[j, 34] + "','" + tlist[j, 35] + "','" + tlist[j, 36] + "','" + tlist[j, 37] + "')";//这块是用来把数据插入数据库表中的
                        SqlCommand com2 = new SqlCommand(sql1, con1);

                        com2.ExecuteNonQuery();
                        con1.Close();
                        // Console.Write(" \n");
                    }
                }
                 datetime13 = DateTime.Now;
               // subtime400 = datetime13.Subtract(datetime12);
            }
            else if (z == 500)
            {
                 datetime14 = DateTime.Now;
                //输出禁忌表，不包含擂台赛失败的解，即均为pareto解集
                // Console.Write(" 第50次迭代的禁忌表：\n");
                string sql1 = "";//用来盛放sql语句
                SqlConnection con1 = new SqlConnection();//建立连接

                con1.ConnectionString = "server=(local);uid=sa;pwd=1hu2xin3min;database=ldq";//连接数据库
               
                int t_length1 = prop.tlist_length(tlist, tlist_num);
                var j_1 = 0;
                for (int j = 0; j < t_length1; j++)
                {
                    if (tlist[j, n + 3] != 100)
                    {
                        /* for (int i = 0; i < n + 4; i++)
                         {

                             Console.Write(tlist[j, i] + " ");

                         }*/
                        con1.Open();
                        // Console.Write(" \n");
                        j_1++;

                        sql1 = "insert  into tlist_500(id,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,ab,cd,ef,gh,ij,kl,mn,op,qr,dis,time,tabu_state) values('" + j_1 + "','" + tlist[j, 0] + "','" + tlist[j, 1] + "','" + tlist[j, 2] + "','" + tlist[j, 3] + "','" + tlist[j, 4] + "','" + tlist[j, 5] + "','" + tlist[j, 6] + "','" + tlist[j, 7] + "','" + tlist[j, 8] + "','" + tlist[j, 9] + "','" + tlist[j, 10] + "','" + tlist[j, 11] + "','" + tlist[j, 12] + "','" + tlist[j, 13] + "','" + tlist[j, 14] + "','" + tlist[j, 15] + "','" + tlist[j, 16] + "','" + tlist[j, 17] + "','" + tlist[j, 18] + "','" + tlist[j, 19] + "','" + tlist[j, 20] + "','" + tlist[j, 21] + "','" + tlist[j, 22] + "','" + tlist[j, 23] + "','" + tlist[j, 24] + "','" + tlist[j, 25] + "','" + tlist[j, 26] + "','" + tlist[j, 27] + "','" + tlist[j, 28] + "','" + tlist[j, 29] + "','" + tlist[j, 30] + "','" + tlist[j, 31] + "','" + tlist[j, 32] + "','" + tlist[j, 33] + "','" + tlist[j, 34] + "','" + tlist[j, 35] + "','" + tlist[j, 36] + "','" + tlist[j, 37] + "')";//这块是用来把数据插入数据库表中的
                        SqlCommand com2 = new SqlCommand(sql1, con1);

                        com2.ExecuteNonQuery();
                        con1.Close();
                        // Console.Write(" \n");
                    }
                }
                datetime15 = DateTime.Now;
                //subtime500 = datetime15.Subtract(datetime14);
            }
        }//**********************************************************************************************循环结束*************************************
       // DateTime datetime161 = DateTime.Now;
        datetime16 = DateTime.Now;
        int t_length = prop.tlist_length(tlist, tlist_num);
        /*   //输出禁忌表，包含擂台赛失败的解
           Console.Write(" 禁忌表：\n");
                       
          for (int j = 0; j < t_length; j++)
           {

               for (int i = 0; i < n + 4; i++)
               {

                   Console.Write(tlist[j, i] + " ");

               }
               Console.Write(" \n");
           }*/
       
        //输出禁忌表，不包含擂台赛失败的解，即均为pareto解集
       pareto_num = 0;
      
       // Console.Write(" 迭代结束后的禁忌表：\n");
        for (int j = 0; j < t_length; j++)
        {
            if (tlist[j, n+3] != 100)
            {
                pareto_num++;
                for (int i = 0; i < n + 4; i++)
                {

                   // Console.Write(tlist[j, i] + " ");

                }
               // Console.Write(" \n");
            }
        }
      

    }
   public TimeSpan time_interval()
    {
        TimeSpan subtime = datetime16.Subtract(datetime1); //获得datetime1和datetime2之间的间隔，具体时间可以从subtime中分离出来。
      /*  TimeSpan subtime50 =datetime3.Subtract(this.datetime2);
        TimeSpan subtime100 = this.datetime5.Subtract(this.datetime4);
        TimeSpan subtime150 = this.datetime7.Subtract(this.datetime6);
        TimeSpan subtime200 = this.datetime9.Subtract(this.datetime8);
        TimeSpan subtime300 = this.datetime11.Subtract(this.datetime10);
        TimeSpan subtime400 = this.datetime13.Subtract(this.datetime12);
        TimeSpan subtime500 = this.datetime15.Subtract(this.datetime14);
         TimeSpan sub = subtime - subtime50 - subtime100 - subtime150 - subtime200 - subtime300 - subtime400 - subtime500;*/
         return subtime;


       /*查询datatime具体用法，赋值的用法
        */
    }
   public DateTime time1()
   {
       
       return datetime1;
   }
   public DateTime time2()
   {

       return datetime16;
   }

    public int paretoNum() {
        int num = this.pareto_num;
        return num;
    }
}