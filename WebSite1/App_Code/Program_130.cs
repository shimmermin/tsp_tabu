using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;

    public class Program_130
    {
        public static string conn = System.Configuration.ConfigurationManager.AppSettings["Connstr"];
        public static SqlConnection con = new SqlConnection(conn);//建立连接
          
        public static DateTime datetime1, datetime4, datetime5, datetime8, datetime9, datetime10, datetime11, datetime12, datetime13, datetime14, datetime15, datetime16, datetime17, datetime18, datetime19;
        public int pareto_num;
        public double[,] initial(int n)     //初始化函数，计算出距离数组
        {
            double[,] city = new double[130, 2] { 
{ 334.591,161.781},{ 397.645,262.817}, 
{ 503.874,172.874},{ 444.048,384.649}, 
{ 311.614,2.009  },{ 662.855,549.230 },
{ 40.098 ,187.238},{ 526.894,215.708 }, 
{ 209.189,691.026},{ 683.267,414.210 }, 
{ 280.749,5.921  },{ 252.750,535.743 }, 
{ 698.785,348.441},{ 678.757,410.726 }, 
{ 220.004,409.123},{ 355.153,76.391 }, 
{ 296.972,313.131},{ 504.515,240.887 }, 
{ 224.108,358.487},{ 470.680,309.626}, 
{ 554.253,279.424},{ 567.633,352.716 }, 
{ 599.053,361.095},{ 240.523,430.604 }, 
{ 32.083, 345.855},{91.054,148.721 }, 
{ 248.218,343.953},{488.891,3.612}, 
{ 206.047,437.764},{ 575.841, 141.967 },
{ 282.609,329.418},{27.658,424.768 },
{568.574, 287.098},{269.464,295.946 },
{417.800, 341.260},{32.168, 448.900},
{561.478, 357.354},{342.948, 492.332},
{399.675, 156.844},{571.737, 375.758},
{370.756, 151.906},{509.709, 435.798},
{177.021, 295.604},{526.167, 409.486},
{316.573, 65.640},{469.291, 281.990},
{572.763, 373.321},{29.518, 330.038},
{454.008, 537.218},{416.155, 227.613},
{535.251, 471.065},{265.446, 684.999},
{478.054, 509.645},{370.478, 332.539},
{598.348, 446.869},{201.152, 649.026},
{193.693, 680.232},{448.579, 532.793},
{603.285, 134.401},{543.010, 481.517},
{214.575, 43.646},{426.350, 61.729},
{89.045, 277.116},{84.492, 31.847},
{220.047, 623.078},{688.461, 0.470},
{687.286, 373.535},{75.493,312.918},
{63.417, 23.704},{97.936, 211.091},
{399.526, 170.822},{456.317, 597.194},
{319.886, 626.840},{295.925, 664.629},
{288.487, 667.728},{268.395, 52.901},
{140.471, 513.557},{689.808, 167.595},
{280.578, 458.753},{453.388, 282.908},
{213.570, 525.868},{133.695, 677.176},
{521.166, 132.862},{30.266, 450.075},
{657.020, 39.777},{6.925, 23.875},
{252.429, 535.166},{42.855, 63.823},
{145.900, 399.526},{638.489, 62.626},
{489.276, 665.313},{361.223, 564.235},
{519.948, 347.971},{129.335, 435.669},
{259.717, 454.650},{676.342, 371.098},
{84.513, 183.326},{77.716, 354.383},
{335.980, 660.632},{264.355, 377.574},
{51.683, 676.043},{692.138, 543.801},
{169.219, 547.819},{194.013, 263.479},
{415.193, 78.913},{415.043, 479.080},
{169.839, 245.610},{525.099 ,213.506},
{238.685, 33.493},{116.211, 363.574},
{16.928, 656.571},{434.344, 92.700},
{40.525, 424.683},{530.485, 183.839},
{484.360, 49.246},{263.650, 426.585},
{450.289, 126.385},{441.782, 299.772},
{24.217, 500.347},{503.789, 514.690},
{635.539, 200.981},{614.592, 418.869},
{21.716, 660.974},{143.827, 92.700},
{637.719, 54.205},{566.565, 199.955},
{196.685, 221.821},{384.927, 87.463},
{178.111, 104.691},{403.287, 205.897}
                                     };
            //城市坐标数组**************************************************************输入



            string sql = "";//用来盛放sql语句
          //  SqlConnection con = new SqlConnection();//建立连接
           // string conn = System.Configuration.ConfigurationManager.AppSettings["Connstr"];
          //  con.ConnectionString =conn;//连接数据库
           
            con.Open();         //打开连接

            String sql_1 = "DELETE  FROM city_130";
            SqlCommand com_1 = new SqlCommand(sql_1, con);
            com_1.ExecuteNonQuery();

            for (int i = 0; i < n - 1; i++)
            {
                sql = "insert  into city_130(x,y) values('" + city[i, 0] + "','" + city[i, 1] + "')";//这块是用来把数据插入数据库表中的
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


        public Double[,] RandomTime(int num, int minValue, int maxValue)//在区间[minValue,maxValue]取出num个互不相同的随机数，返回数组。
        {
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));//保证产生的数字的随机性

            Double[,] arryTime = new Double[num, num];//初始解数组

            int tmp = 0;
            for (int j = 0; j <= num - 1; j++)
            {
                for (int i = 0; i <= num - 1; i++)
                {
                    tmp = ra.Next(minValue, maxValue);

                    arryTime[j, i] = tmp * 0.1;

                }
            }
            return arryTime;//随机抽取的初始解

        }

        //随机产生初始城市序列
        public int[] RandomCity(int num, int minValue, int maxValue)//在区间[minValue,maxValue]取出num个互不相同的随机数，返回数组。
        {
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));//保证产生的数字的随机性

            int[] arrNum = new int[num];//初始解数组

            int tmp = 0;

            for (int i = 0; i <= num - 1; i++)
            {
                tmp = ra.Next(minValue, maxValue); //随机取数
                if (i != num - 1)
                {
                    arrNum[i] = getRandomNum(arrNum, tmp, minValue, maxValue, ra); //取出值赋到数组中
                }
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
        public double[,] two_opt(double[] current, int n, Program_130 prop, double[,] arraydis, double[,] arraytime, int l)   //2-opt邻域产生：输入当前城市序列，输入城市数30，输入要交换的城市编号
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

        public double[] pro_current(double[,] hou_list, double[,] tlist, double[] seed, int n, Program_130 prop, int tlist_num, int hou_num)    //种子解产生当前解//输入种子解，候选表，禁忌表
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
                        //                       Console.Write("第几次打擂失败：");
                        //                       Console.Write(d);
                        //                       Console.Write("\n");
                        for (int j = 0; j < hou_num; j++)
                        {
                            if (seed[n] == hou_list[j, n] && seed[n + 1] == hou_list[j, n + 1])
                            {
                                hou_list[j, 0] = 100;//候选表该解为无效解
                            }
                        }
                        //                       Console.Write(" 打擂失败后，重选种子解过程\n");
                        seed = prop.seeds(hou_list, n, hou_num);
                        //输出种子解  
                        //                        Console.Write(" 打擂失败后重选的种子解：\n");
                        if (seed != null)
                        {
                            //                           for (int i = 0; i < n + 3; i++)
                            //                           {
                            //
                            //                               Console.Write(seed[i] + " ");
                            //
                            //                           }
                        }
                        else
                        {
                            //                            Console.Write(" 种子解重选失败");
                        }
                        p = 0;//修改种子解在禁忌表中的记录值p，代表新的种子未经判断前不在禁忌表中。

                    }

                }
                else
                {//种子解在禁忌表中，更新候选表禁忌状态
                    //                   Console.Write("第几次在禁忌表中：");
                    d++;
                    //                    Console.Write(d);
                    //                   Console.Write("\n");
                    //种子解和候选表匹配
                    for (int j = 0; j < hou_num; j++)
                    {
                        if (seed[n] == hou_list[j, n] && seed[n + 1] == hou_list[j, n + 1])
                        {
                            hou_list[j, n + 2] = 1;//候选表该禁忌状态为1
                        }
                    }
                    //                   Console.Write(" 种子解在禁忌表中，重选种子解过程\n");
                    seed = prop.seeds(hou_list, n, hou_num);
                    //输出种子解  
                    //                   Console.Write(" 种子解在禁忌表中，重选的种子解\n");
                    if (seed != null)
                    {
                        //                       for (int i = 0; i < n + 3; i++)
                        //                        {

                        //                           Console.Write(seed[i] + " ");

                        //                       }
                    }
                    else
                    {
                        //                        Console.Write("种子解重选失败 ");
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
            //            Console.Write(" 候选表无法产生种子解，特赦禁忌表中最老的解为当前解：\n");
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


        public void tsp_130(Program_130 prop)
        {
           // Program_130 prop = new Program_130();//实例化类

            int n = 131;//城市数目:从5开始，历经31个城市，最后回到5,即一共31个城市形成环形

            int l = 8256;//邻域表解的个数

            int hou_num = 8256;//候选表解的个数,与邻域解个数相关

            int tlist_num =4001;//禁忌表解的个数，由于程序设定问题，禁忌表容量大于foot循环步数  每步一个禁忌解，加上一个初始解    

            int foot = 4000;   //终止准则foot步循环

            //  int[] tspx = new int[n];//城市序列

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

            arraytime = prop.RandomTime(n, 5, 30);//初始化产生时间矩阵

            // DateTime datatime1, datatime2, datatime3, datatime4, datatime5, datatime6, datatime7, datatime8, datatime9, datatime10, datatime11, datatime12, datatime13;
            //随机产生初始路径
            int[] tspx = prop.RandomCity(n-1, 1, n-1); 
            for (int i = 0; i <= n-2; i++)
            {
                current[i] = tspx[i] + 1;//初始城市序列给当前城市序列，由于Christofides算法中城市序列数组从0开始，而本程序从1开始，所以加1
            }
            current[n - 1] = current[0];//终点与起点相同

            //下面城市序列为Christofides算法求得的初始解，包含终点
            // int[] tspx = { 4, 14, 5, 9, 10, 11, 1, 12, 13, 28, 16, 15, 17, 18, 23, 22, 21, 19, 2, 20, 25, 32, 33, 24, 8, 26, 31, 30, 3, 29, 0, 7, 6, 27, 4 };
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
            tlist[0, n + 2] = 1;//第一轮，禁忌长度为1
            tlist[0, n + 3] = 0;//未进行擂台赛，默认为赢
            //    Console.Write(" 初始解：\n");


            //    for (int i = 0; i < n + 3; i++)
            //     {
            //         Console.Write(current[i] + " ");//输出初始解，C#中FOR语句中输出字符在一排显示不能使用Console.Writeline（），而用Console.Write（）
            //     }

            //     Console.Write(" \n");


            /*               string sql1 = "";//用来盛放sql语句
                           SqlConnection con1 = new SqlConnection();//建立连接

                           con1.ConnectionString = "server=(local);uid=sa;pwd=1hu2xin3min;database=ldq";//连接数据库
                           con1.Open();         //打开连接
                           sql1 = "DELETE  FROM lin_list";
                           SqlCommand com1 = new SqlCommand(sql1, con1);
                           com1.ExecuteNonQuery();
                           con1.Close();
                     lin_list = prop.two_opt(current, n, prop,arraydis,arraytime,l);//调用two_opt函数，构造邻域表
                     //输出邻域表
                     Console.Write(" 邻域表：\n");
                     for (int j = 0; j < l; j++)
                     {
                         for (int i = 0; i < n + 3; i++)
                         {
                             Console.Write(lin_list[j, i] + " ");
                         }
                         Console.Write(" \n");
                         con1.Open();
                         sql1 = "insert  into lin_list(a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,ab,cd,ef,gh,ij,kl,mn,op,qr,dis,time,tabu_state) values('" + lin_list[j, 0] + "','" + lin_list[j, 1] + "','" + lin_list[j, 2] + "','" + lin_list[j, 3] + "','" + lin_list[j, 4] + "','" + lin_list[j, 5] + "','" + lin_list[j, 6] + "','" + lin_list[j, 7] + "','" + lin_list[j, 8] + "','" + lin_list[j, 9] + "','" + lin_list[j, 10] + "','" + lin_list[j, 11] + "','" + lin_list[j, 12] + "','" + lin_list[j, 13] + "','" + lin_list[j, 14] + "','" + lin_list[j, 15] + "','" + lin_list[j, 16] + "','" + lin_list[j, 17] + "','" + lin_list[j, 18] + "','" + lin_list[j, 19] + "','" + lin_list[j, 20] + "','" + lin_list[j, 21] + "','" + lin_list[j, 22] + "','" + lin_list[j, 23] + "','" + lin_list[j, 24] + "','" + lin_list[j, 25] + "','" + lin_list[j, 26] + "','" + lin_list[j, 27] + "','" + lin_list[j, 28] + "','" + lin_list[j, 29] + "','" + lin_list[j, 30] + "','" + lin_list[j, 31] + "','" + lin_list[j, 32] + "','" + lin_list[j, 33] + "','" + tlist[j, 34] + "','" + tlist[j, 35] + "','" + tlist[j, 36] + "','" + tlist[j, 37] + "')";//这块是用来把数据插入数据库表中的
                         SqlCommand com2 = new SqlCommand(sql1, con1);

                          com2.ExecuteNonQuery();
                          con1.Close();

                     }

                     Console.Write(" 邻域表输出完毕\n");
                   */
            datetime1 = DateTime.Now;
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
                //            Console.Write(" 候选表选出种子解：\n");
                //             for (int i = 0; i < n + 3; i++)
                //            {
                //
                //                   Console.Write(seed[i] + " ");
                //
                //              }
                //              Console.Write("\n");
                //种子解作为当前解
                current = prop.pro_current(hou_list, tlist, seed, n, prop, tlist_num, hou_num);
                //输出当前解
                //                Console.Write(" 判断种子解能否作为当前解：\n");
                //                Console.Write(" 当前解：\n");
                //                for (int i = 0; i < n + 3; i++)
                //                {
                //
                //                    Console.Write(current[i] + " ");
                //
                //               }
                //               Console.Write("\n");
                //current进入禁忌表，修改禁忌状态
                //               Console.Write(" 当前解进入禁忌表：\n");
                int tlist_length = prop.tlist_length(tlist, tlist_num);
                for (int i = 0; i < n + 2; i++)
                {
                    tlist[tlist_length, i] = current[i];
                }
                tlist[tlist_length, n + 2] = 1;//新加入禁忌表的解，禁忌状态为1
                tlist[tlist_length, n + 3] = 0;//未进行擂台赛，输赢状态为0
                //更新禁忌表其他解禁忌长度,加1
                for (int j = 0; j < tlist_length; j++)
                {
                    tlist[j, n + 2]++;
                }
                //输出禁忌表，包含擂台赛失败的解
                //                Console.Write("一轮迭代后的 禁忌表：\n");
                int tlist_length1 = prop.tlist_length(tlist, tlist_num);
                //               for (int j = 0; j < tlist_length1; j++)
                //               {
                //
                //                   if (tlist[j, n+3] != 100)
                //                   {
                //                       for (int i = 0; i < n + 4; i++)
                //                       {

                //                           Console.Write(tlist[j, i] + " ");

                //                       }
                //                       Console.Write(" \n");
                //                   }
                //               }
                //               Console.Write(z);

                //               Console.Write("\n");
               


                if (z == 500)
                {
                    datetime4 = DateTime.Now;
                    //输出禁忌表，不包含擂台赛失败的解，即均为pareto解集
                    // Console.Write(" 第50次迭代的禁忌表：\n");
                    string sql1 = "";//用来盛放sql语句
             
                    con.Open();         //打开连接
                    sql1 = "DELETE  FROM t130_500";
                    SqlCommand com1 = new SqlCommand(sql1, con);
                    com1.ExecuteNonQuery();
                    con.Close();
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
                            con.Open();
                            // Console.Write(" \n");
                            j_1++;

                            sql1 = "insert  into t130_500(id,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,aa,bb,cc,dd,ee,ff,gg,hh,ii,jj,kk,ll,mm,nn,oo,pp,qq,rr,ss,tt,uu,vv,ww,xx,yy,zz,aaa,bbb,ccc,ddd,eee,fff,ggg,hhh,iii,jjj,kkk,lll,mmm,nnn,ooo,ppp,qqq,rrr,sss,ttt,uuu,vvv,www,xxx,yyy,zzz,aaaa,bbbb,cccc,dddd,eeee,ffff,gggg,hhhh,iiii,jjjj,kkkk,llll,mmmm,nnnn,oooo,pppp,qqqq,rrrr,ssss,tttt,uuuu,vvvv,wwww,xxxx,yyyy,zzzz,aaaaa,bbbbb,ccccc,ddddd,eeeee,fffff,ggggg,hhhhh,iiiii,jjjjj,kkkkk,lllll,mmmmm,nnnnn,ooooo,ppppp,qqqqq,rrrrr,sssss,ttttt,uuuuu,vvvvv,wwwww,xxxxx,yyyyy,zzzzz,a_1,dis,time_,tabu_state) values('"
                                  + j_1 + "','" + tlist[j, 0] + "','" + tlist[j, 1] + "','" + tlist[j, 2] + "','" + tlist[j, 3] + "','" + tlist[j, 4] + "','" + tlist[j, 5] + "','" + tlist[j, 6] + "','" + tlist[j, 7] + "','" + tlist[j, 8] + "','" + tlist[j, 9] + "','" + tlist[j, 10] + "','" + tlist[j, 11] + "','" + tlist[j, 12] + "','"
                                  + tlist[j, 13] + "','" + tlist[j, 14] + "','" + tlist[j, 15] + "','" + tlist[j, 16] + "','" + tlist[j, 17] + "','" + tlist[j, 18] + "','" + tlist[j, 19] + "','" + tlist[j, 20] + "','" + tlist[j, 21] + "','" + tlist[j, 22] + "','" + tlist[j, 23] + "','" + tlist[j, 24] + "','" + tlist[j, 25] + "','"
                                  + tlist[j, 26] + "','" + tlist[j, 27] + "','" + tlist[j, 28] + "','" + tlist[j, 29] + "','" + tlist[j, 30] + "','" + tlist[j, 31] + "','" + tlist[j, 32] + "','" + tlist[j, 33] + "','" + tlist[j, 34] + "','" + tlist[j, 35] + "','" + tlist[j, 36] + "','" + tlist[j, 37] + "','" + tlist[j, 38] + "','"
                                  + tlist[j, 39] + "','" + tlist[j, 40] + "','" + tlist[j, 41] + "','" + tlist[j, 42] + "','" + tlist[j, 43] + "','" + tlist[j, 44] + "','" + tlist[j, 45] + "','" + tlist[j, 46] + "','" + tlist[j, 47] + "','" + tlist[j, 48] + "','" + tlist[j, 49] + "','" + tlist[j, 50] + "','" + tlist[j, 51] + "','"
                                  + tlist[j, 52] + "','" + tlist[j, 53] + "','" + tlist[j, 54] + "','" + tlist[j, 55] + "','" + tlist[j, 56] + "','" + tlist[j, 57] + "','" + tlist[j, 58] + "','" + tlist[j, 59] + "','" + tlist[j, 60] + "','" + tlist[j, 61] + "','" + tlist[j, 62] + "','" + tlist[j, 63] + "','" + tlist[j, 64] + "','"
                                  + tlist[j, 65] + "','" + tlist[j, 66] + "','" + tlist[j, 67] + "','" + tlist[j, 68] + "','" + tlist[j, 69] + "','" + tlist[j, 70] + "','" + tlist[j, 71] + "','" + tlist[j, 72] + "','" + tlist[j, 73] + "','" + tlist[j, 74] + "','" + tlist[j, 75] + "','" + tlist[j, 76] + "','" + tlist[j, 77] + "','"
                                  + tlist[j, 78] + "','" + tlist[j, 79] + "','" + tlist[j, 80] + "','" + tlist[j, 81] + "','" + tlist[j, 82] + "','" + tlist[j, 83] + "','" + tlist[j, 84] + "','" + tlist[j, 85] + "','" + tlist[j, 86] + "','" + tlist[j, 87] + "','" + tlist[j, 88] + "','" + tlist[j, 89] + "','" + tlist[j, 90] + "','"
                                  + tlist[j, 91] + "','" + tlist[j, 92] + "','" + tlist[j, 93] + "','" + tlist[j, 94] + "','" + tlist[j, 95] + "','" + tlist[j, 96] + "','" + tlist[j, 97] + "','" + tlist[j, 98] + "','" + tlist[j, 99] + "','" + tlist[j, 100] + "','" + tlist[j, 101] + "','" + tlist[j, 102] + "','" + tlist[j, 103] + "','"
                                  + tlist[j, 104] + "','" + tlist[j, 105] + "','" + tlist[j, 106] + "','" + tlist[j, 107] + "','" + tlist[j, 108] + "','" + tlist[j, 109] + "','" + tlist[j, 110] + "','" + tlist[j, 111] + "','" + tlist[j, 112] + "','" + tlist[j, 113] + "','" + tlist[j, 114] + "','" + tlist[j, 115] + "','" + tlist[j, 116] + "','"
                                  + tlist[j, 117] + "','" + tlist[j, 118] + "','" + tlist[j, 119] + "','" + tlist[j, 120] + "','" + tlist[j, 121] + "','" + tlist[j, 122] + "','" + tlist[j, 123] + "','" + tlist[j, 124] + "','" + tlist[j, 125] + "','" + tlist[j, 126] + "','" + tlist[j, 127] + "','" + tlist[j, 128] + "','" + tlist[j, 129] + "','"
                             + tlist[j, 130] + "','" + tlist[j, 131] + "','" + tlist[j, 132] + "','" + tlist[j, 133] + "')";//这块是用来把数据插入数据库表中的
                            SqlCommand com2 = new SqlCommand(sql1, con);

                            com2.ExecuteNonQuery();
                            con.Close();
                            // Console.Write(" \n");
                        }
                    }
                    datetime5 = DateTime.Now;
                }

              
                if (z == 900)
                {
                    datetime8 = DateTime.Now;
                    //输出禁忌表，不包含擂台赛失败的解，即均为pareto解集
                    // Console.Write(" 第50次迭代的禁忌表：\n");
                    string sql1 = "";//用来盛放sql语句
                  //  SqlConnection con1 = new SqlConnection();//建立连接

                  //  con1.ConnectionString = "server=(local);uid=sa;pwd=1hu2xin3min;database=ldq";//连接数据库
                    con.Open();         //打开连接
                    sql1 = "DELETE  FROM  t130_900";
                    SqlCommand com1 = new SqlCommand(sql1, con);
                    com1.ExecuteNonQuery();
                    con.Close();
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
                            con.Open();
                            // Console.Write(" \n");
                            j_1++;

                            sql1 = "insert  into t130_900(id,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,aa,bb,cc,dd,ee,ff,gg,hh,ii,jj,kk,ll,mm,nn,oo,pp,qq,rr,ss,tt,uu,vv,ww,xx,yy,zz,aaa,bbb,ccc,ddd,eee,fff,ggg,hhh,iii,jjj,kkk,lll,mmm,nnn,ooo,ppp,qqq,rrr,sss,ttt,uuu,vvv,www,xxx,yyy,zzz,aaaa,bbbb,cccc,dddd,eeee,ffff,gggg,hhhh,iiii,jjjj,kkkk,llll,mmmm,nnnn,oooo,pppp,qqqq,rrrr,ssss,tttt,uuuu,vvvv,wwww,xxxx,yyyy,zzzz,aaaaa,bbbbb,ccccc,ddddd,eeeee,fffff,ggggg,hhhhh,iiiii,jjjjj,kkkkk,lllll,mmmmm,nnnnn,ooooo,ppppp,qqqqq,rrrrr,sssss,ttttt,uuuuu,vvvvv,wwwww,xxxxx,yyyyy,zzzzz,a_1,dis,time_,tabu_state) values('"
                                   + j_1 + "','" + tlist[j, 0] + "','" + tlist[j, 1] + "','" + tlist[j, 2] + "','" + tlist[j, 3] + "','" + tlist[j, 4] + "','" + tlist[j, 5] + "','" + tlist[j, 6] + "','" + tlist[j, 7] + "','" + tlist[j, 8] + "','" + tlist[j, 9] + "','" + tlist[j, 10] + "','" + tlist[j, 11] + "','" + tlist[j, 12] + "','"
                                   + tlist[j, 13] + "','" + tlist[j, 14] + "','" + tlist[j, 15] + "','" + tlist[j, 16] + "','" + tlist[j, 17] + "','" + tlist[j, 18] + "','" + tlist[j, 19] + "','" + tlist[j, 20] + "','" + tlist[j, 21] + "','" + tlist[j, 22] + "','" + tlist[j, 23] + "','" + tlist[j, 24] + "','" + tlist[j, 25] + "','"
                                   + tlist[j, 26] + "','" + tlist[j, 27] + "','" + tlist[j, 28] + "','" + tlist[j, 29] + "','" + tlist[j, 30] + "','" + tlist[j, 31] + "','" + tlist[j, 32] + "','" + tlist[j, 33] + "','" + tlist[j, 34] + "','" + tlist[j, 35] + "','" + tlist[j, 36] + "','" + tlist[j, 37] + "','" + tlist[j, 38] + "','"
                                   + tlist[j, 39] + "','" + tlist[j, 40] + "','" + tlist[j, 41] + "','" + tlist[j, 42] + "','" + tlist[j, 43] + "','" + tlist[j, 44] + "','" + tlist[j, 45] + "','" + tlist[j, 46] + "','" + tlist[j, 47] + "','" + tlist[j, 48] + "','" + tlist[j, 49] + "','" + tlist[j, 50] + "','" + tlist[j, 51] + "','"
                                   + tlist[j, 52] + "','" + tlist[j, 53] + "','" + tlist[j, 54] + "','" + tlist[j, 55] + "','" + tlist[j, 56] + "','" + tlist[j, 57] + "','" + tlist[j, 58] + "','" + tlist[j, 59] + "','" + tlist[j, 60] + "','" + tlist[j, 61] + "','" + tlist[j, 62] + "','" + tlist[j, 63] + "','" + tlist[j, 64] + "','"
                                   + tlist[j, 65] + "','" + tlist[j, 66] + "','" + tlist[j, 67] + "','" + tlist[j, 68] + "','" + tlist[j, 69] + "','" + tlist[j, 70] + "','" + tlist[j, 71] + "','" + tlist[j, 72] + "','" + tlist[j, 73] + "','" + tlist[j, 74] + "','" + tlist[j, 75] + "','" + tlist[j, 76] + "','" + tlist[j, 77] + "','"
                                   + tlist[j, 78] + "','" + tlist[j, 79] + "','" + tlist[j, 80] + "','" + tlist[j, 81] + "','" + tlist[j, 82] + "','" + tlist[j, 83] + "','" + tlist[j, 84] + "','" + tlist[j, 85] + "','" + tlist[j, 86] + "','" + tlist[j, 87] + "','" + tlist[j, 88] + "','" + tlist[j, 89] + "','" + tlist[j, 90] + "','"
                                   + tlist[j, 91] + "','" + tlist[j, 92] + "','" + tlist[j, 93] + "','" + tlist[j, 94] + "','" + tlist[j, 95] + "','" + tlist[j, 96] + "','" + tlist[j, 97] + "','" + tlist[j, 98] + "','" + tlist[j, 99] + "','" + tlist[j, 100] + "','" + tlist[j, 101] + "','" + tlist[j, 102] + "','" + tlist[j, 103] + "','"
                                   + tlist[j, 104] + "','" + tlist[j, 105] + "','" + tlist[j, 106] + "','" + tlist[j, 107] + "','" + tlist[j, 108] + "','" + tlist[j, 109] + "','" + tlist[j, 110] + "','" + tlist[j, 111] + "','" + tlist[j, 112] + "','" + tlist[j, 113] + "','" + tlist[j, 114] + "','" + tlist[j, 115] + "','" + tlist[j, 116] + "','"
                                   + tlist[j, 117] + "','" + tlist[j, 118] + "','" + tlist[j, 119] + "','" + tlist[j, 120] + "','" + tlist[j, 121] + "','" + tlist[j, 122] + "','" + tlist[j, 123] + "','" + tlist[j, 124] + "','" + tlist[j, 125] + "','" + tlist[j, 126] + "','" + tlist[j, 127] + "','" + tlist[j, 128] + "','" + tlist[j, 129] + "','"
                             + tlist[j, 130] + "','" + tlist[j, 131] + "','" + tlist[j, 132] + "','" + tlist[j, 133] + "')";
                            SqlCommand com2 = new SqlCommand(sql1, con);

                            com2.ExecuteNonQuery();
                            con.Close();
                            // Console.Write(" \n");
                        }
                    }
                    datetime9 = DateTime.Now;
                }
                if (z == 1300)
                {
                    datetime10 = DateTime.Now;
                    //输出禁忌表，不包含擂台赛失败的解，即均为pareto解集
                    // Console.Write(" 第50次迭代的禁忌表：\n");
                    string sql1 = "";//用来盛放sql语句
                   // SqlConnection con1 = new SqlConnection();//建立连接

                    //con1.ConnectionString = "server=(local);uid=sa;pwd=1hu2xin3min;database=ldq";//连接数据库
                    con.Open();         //打开连接
                    sql1 = "DELETE  FROM t130_1300";
                    SqlCommand com1 = new SqlCommand(sql1, con);
                    com1.ExecuteNonQuery();
                    con.Close();
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
                            con.Open();
                            // Console.Write(" \n");
                            j_1++;

                            sql1 = "insert  into t130_1300(id,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,aa,bb,cc,dd,ee,ff,gg,hh,ii,jj,kk,ll,mm,nn,oo,pp,qq,rr,ss,tt,uu,vv,ww,xx,yy,zz,aaa,bbb,ccc,ddd,eee,fff,ggg,hhh,iii,jjj,kkk,lll,mmm,nnn,ooo,ppp,qqq,rrr,sss,ttt,uuu,vvv,www,xxx,yyy,zzz,aaaa,bbbb,cccc,dddd,eeee,ffff,gggg,hhhh,iiii,jjjj,kkkk,llll,mmmm,nnnn,oooo,pppp,qqqq,rrrr,ssss,tttt,uuuu,vvvv,wwww,xxxx,yyyy,zzzz,aaaaa,bbbbb,ccccc,ddddd,eeeee,fffff,ggggg,hhhhh,iiiii,jjjjj,kkkkk,lllll,mmmmm,nnnnn,ooooo,ppppp,qqqqq,rrrrr,sssss,ttttt,uuuuu,vvvvv,wwwww,xxxxx,yyyyy,zzzzz,a_1,dis,time_,tabu_state) values('"
                                     + j_1 + "','" + tlist[j, 0] + "','" + tlist[j, 1] + "','" + tlist[j, 2] + "','" + tlist[j, 3] + "','" + tlist[j, 4] + "','" + tlist[j, 5] + "','" + tlist[j, 6] + "','" + tlist[j, 7] + "','" + tlist[j, 8] + "','" + tlist[j, 9] + "','" + tlist[j, 10] + "','" + tlist[j, 11] + "','" + tlist[j, 12] + "','"
                                     + tlist[j, 13] + "','" + tlist[j, 14] + "','" + tlist[j, 15] + "','" + tlist[j, 16] + "','" + tlist[j, 17] + "','" + tlist[j, 18] + "','" + tlist[j, 19] + "','" + tlist[j, 20] + "','" + tlist[j, 21] + "','" + tlist[j, 22] + "','" + tlist[j, 23] + "','" + tlist[j, 24] + "','" + tlist[j, 25] + "','"
                                     + tlist[j, 26] + "','" + tlist[j, 27] + "','" + tlist[j, 28] + "','" + tlist[j, 29] + "','" + tlist[j, 30] + "','" + tlist[j, 31] + "','" + tlist[j, 32] + "','" + tlist[j, 33] + "','" + tlist[j, 34] + "','" + tlist[j, 35] + "','" + tlist[j, 36] + "','" + tlist[j, 37] + "','" + tlist[j, 38] + "','"
                                     + tlist[j, 39] + "','" + tlist[j, 40] + "','" + tlist[j, 41] + "','" + tlist[j, 42] + "','" + tlist[j, 43] + "','" + tlist[j, 44] + "','" + tlist[j, 45] + "','" + tlist[j, 46] + "','" + tlist[j, 47] + "','" + tlist[j, 48] + "','" + tlist[j, 49] + "','" + tlist[j, 50] + "','" + tlist[j, 51] + "','"
                                     + tlist[j, 52] + "','" + tlist[j, 53] + "','" + tlist[j, 54] + "','" + tlist[j, 55] + "','" + tlist[j, 56] + "','" + tlist[j, 57] + "','" + tlist[j, 58] + "','" + tlist[j, 59] + "','" + tlist[j, 60] + "','" + tlist[j, 61] + "','" + tlist[j, 62] + "','" + tlist[j, 63] + "','" + tlist[j, 64] + "','"
                                     + tlist[j, 65] + "','" + tlist[j, 66] + "','" + tlist[j, 67] + "','" + tlist[j, 68] + "','" + tlist[j, 69] + "','" + tlist[j, 70] + "','" + tlist[j, 71] + "','" + tlist[j, 72] + "','" + tlist[j, 73] + "','" + tlist[j, 74] + "','" + tlist[j, 75] + "','" + tlist[j, 76] + "','" + tlist[j, 77] + "','"
                                     + tlist[j, 78] + "','" + tlist[j, 79] + "','" + tlist[j, 80] + "','" + tlist[j, 81] + "','" + tlist[j, 82] + "','" + tlist[j, 83] + "','" + tlist[j, 84] + "','" + tlist[j, 85] + "','" + tlist[j, 86] + "','" + tlist[j, 87] + "','" + tlist[j, 88] + "','" + tlist[j, 89] + "','" + tlist[j, 90] + "','"
                                     + tlist[j, 91] + "','" + tlist[j, 92] + "','" + tlist[j, 93] + "','" + tlist[j, 94] + "','" + tlist[j, 95] + "','" + tlist[j, 96] + "','" + tlist[j, 97] + "','" + tlist[j, 98] + "','" + tlist[j, 99] + "','" + tlist[j, 100] + "','" + tlist[j, 101] + "','" + tlist[j, 102] + "','" + tlist[j, 103] + "','"
                                     + tlist[j, 104] + "','" + tlist[j, 105] + "','" + tlist[j, 106] + "','" + tlist[j, 107] + "','" + tlist[j, 108] + "','" + tlist[j, 109] + "','" + tlist[j, 110] + "','" + tlist[j, 111] + "','" + tlist[j, 112] + "','" + tlist[j, 113] + "','" + tlist[j, 114] + "','" + tlist[j, 115] + "','" + tlist[j, 116] + "','"
                                     + tlist[j, 117] + "','" + tlist[j, 118] + "','" + tlist[j, 119] + "','" + tlist[j, 120] + "','" + tlist[j, 121] + "','" + tlist[j, 122] + "','" + tlist[j, 123] + "','" + tlist[j, 124] + "','" + tlist[j, 125] + "','" + tlist[j, 126] + "','" + tlist[j, 127] + "','" + tlist[j, 128] + "','" + tlist[j, 129] + "','"
                             + tlist[j, 130] + "','" + tlist[j, 131] + "','" + tlist[j, 132] + "','" + tlist[j, 133] + "')";//这块是用来把数据插入数据库表中的
                            SqlCommand com2 = new SqlCommand(sql1, con);

                            com2.ExecuteNonQuery();
                            con.Close();
                            // Console.Write(" \n");
                        }
                    }
                    datetime11 = DateTime.Now;
                }
                if (z == 1700)
                {
                    datetime12 = DateTime.Now;
                    //输出禁忌表，不包含擂台赛失败的解，即均为pareto解集
                    // Console.Write(" 第50次迭代的禁忌表：\n");
                    string sql1 = "";//用来盛放sql语句
                //  SqlConnection con1 = new SqlConnection();//建立连接

                 //   con1.ConnectionString = "server=(local);uid=sa;pwd=1hu2xin3min;database=ldq";//连接数据库
                    con.Open();         //打开连接
                    sql1 = "DELETE  FROM t130_1700";
                    SqlCommand com1 = new SqlCommand(sql1, con);
                    com1.ExecuteNonQuery();
                    con.Close();
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
                            con.Open();
                            // Console.Write(" \n");
                            j_1++;

                            sql1 = "insert  into t130_1700(id,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,aa,bb,cc,dd,ee,ff,gg,hh,ii,jj,kk,ll,mm,nn,oo,pp,qq,rr,ss,tt,uu,vv,ww,xx,yy,zz,aaa,bbb,ccc,ddd,eee,fff,ggg,hhh,iii,jjj,kkk,lll,mmm,nnn,ooo,ppp,qqq,rrr,sss,ttt,uuu,vvv,www,xxx,yyy,zzz,aaaa,bbbb,cccc,dddd,eeee,ffff,gggg,hhhh,iiii,jjjj,kkkk,llll,mmmm,nnnn,oooo,pppp,qqqq,rrrr,ssss,tttt,uuuu,vvvv,wwww,xxxx,yyyy,zzzz,aaaaa,bbbbb,ccccc,ddddd,eeeee,fffff,ggggg,hhhhh,iiiii,jjjjj,kkkkk,lllll,mmmmm,nnnnn,ooooo,ppppp,qqqqq,rrrrr,sssss,ttttt,uuuuu,vvvvv,wwwww,xxxxx,yyyyy,zzzzz,a_1,dis,time_,tabu_state) values('"
                                     + j_1 + "','" + tlist[j, 0] + "','" + tlist[j, 1] + "','" + tlist[j, 2] + "','" + tlist[j, 3] + "','" + tlist[j, 4] + "','" + tlist[j, 5] + "','" + tlist[j, 6] + "','" + tlist[j, 7] + "','" + tlist[j, 8] + "','" + tlist[j, 9] + "','" + tlist[j, 10] + "','" + tlist[j, 11] + "','" + tlist[j, 12] + "','"
                                     + tlist[j, 13] + "','" + tlist[j, 14] + "','" + tlist[j, 15] + "','" + tlist[j, 16] + "','" + tlist[j, 17] + "','" + tlist[j, 18] + "','" + tlist[j, 19] + "','" + tlist[j, 20] + "','" + tlist[j, 21] + "','" + tlist[j, 22] + "','" + tlist[j, 23] + "','" + tlist[j, 24] + "','" + tlist[j, 25] + "','"
                                     + tlist[j, 26] + "','" + tlist[j, 27] + "','" + tlist[j, 28] + "','" + tlist[j, 29] + "','" + tlist[j, 30] + "','" + tlist[j, 31] + "','" + tlist[j, 32] + "','" + tlist[j, 33] + "','" + tlist[j, 34] + "','" + tlist[j, 35] + "','" + tlist[j, 36] + "','" + tlist[j, 37] + "','" + tlist[j, 38] + "','"
                                     + tlist[j, 39] + "','" + tlist[j, 40] + "','" + tlist[j, 41] + "','" + tlist[j, 42] + "','" + tlist[j, 43] + "','" + tlist[j, 44] + "','" + tlist[j, 45] + "','" + tlist[j, 46] + "','" + tlist[j, 47] + "','" + tlist[j, 48] + "','" + tlist[j, 49] + "','" + tlist[j, 50] + "','" + tlist[j, 51] + "','"
                                     + tlist[j, 52] + "','" + tlist[j, 53] + "','" + tlist[j, 54] + "','" + tlist[j, 55] + "','" + tlist[j, 56] + "','" + tlist[j, 57] + "','" + tlist[j, 58] + "','" + tlist[j, 59] + "','" + tlist[j, 60] + "','" + tlist[j, 61] + "','" + tlist[j, 62] + "','" + tlist[j, 63] + "','" + tlist[j, 64] + "','"
                                     + tlist[j, 65] + "','" + tlist[j, 66] + "','" + tlist[j, 67] + "','" + tlist[j, 68] + "','" + tlist[j, 69] + "','" + tlist[j, 70] + "','" + tlist[j, 71] + "','" + tlist[j, 72] + "','" + tlist[j, 73] + "','" + tlist[j, 74] + "','" + tlist[j, 75] + "','" + tlist[j, 76] + "','" + tlist[j, 77] + "','"
                                     + tlist[j, 78] + "','" + tlist[j, 79] + "','" + tlist[j, 80] + "','" + tlist[j, 81] + "','" + tlist[j, 82] + "','" + tlist[j, 83] + "','" + tlist[j, 84] + "','" + tlist[j, 85] + "','" + tlist[j, 86] + "','" + tlist[j, 87] + "','" + tlist[j, 88] + "','" + tlist[j, 89] + "','" + tlist[j, 90] + "','"
                                     + tlist[j, 91] + "','" + tlist[j, 92] + "','" + tlist[j, 93] + "','" + tlist[j, 94] + "','" + tlist[j, 95] + "','" + tlist[j, 96] + "','" + tlist[j, 97] + "','" + tlist[j, 98] + "','" + tlist[j, 99] + "','" + tlist[j, 100] + "','" + tlist[j, 101] + "','" + tlist[j, 102] + "','" + tlist[j, 103] + "','"
                                     + tlist[j, 104] + "','" + tlist[j, 105] + "','" + tlist[j, 106] + "','" + tlist[j, 107] + "','" + tlist[j, 108] + "','" + tlist[j, 109] + "','" + tlist[j, 110] + "','" + tlist[j, 111] + "','" + tlist[j, 112] + "','" + tlist[j, 113] + "','" + tlist[j, 114] + "','" + tlist[j, 115] + "','" + tlist[j, 116] + "','"
                                     + tlist[j, 117] + "','" + tlist[j, 118] + "','" + tlist[j, 119] + "','" + tlist[j, 120] + "','" + tlist[j, 121] + "','" + tlist[j, 122] + "','" + tlist[j, 123] + "','" + tlist[j, 124] + "','" + tlist[j, 125] + "','" + tlist[j, 126] + "','" + tlist[j, 127] + "','" + tlist[j, 128] + "','" + tlist[j, 129] + "','"
                             + tlist[j, 130] + "','" + tlist[j, 131] + "','" + tlist[j, 132] + "','" + tlist[j, 133] + "')";//这块是用来把数据插入数据库表中的
                            SqlCommand com2 = new SqlCommand(sql1, con);

                            com2.ExecuteNonQuery();
                            con.Close();
                            // Console.Write(" \n");
                        }
                    }
                    datetime13= DateTime.Now;
                }
                if (z == 2100)
                {
                    datetime14 = DateTime.Now;
                    //输出禁忌表，不包含擂台赛失败的解，即均为pareto解集
                    // Console.Write(" 第50次迭代的禁忌表：\n");
                    string sql1 = "";//用来盛放sql语句
                   // SqlConnection con1 = new SqlConnection();//建立连接

                   // con1.ConnectionString = "server=(local);uid=sa;pwd=1hu2xin3min;database=ldq";//连接数据库
                    con.Open();         //打开连接
                    sql1 = "DELETE  FROM t130_2100";
                    SqlCommand com1 = new SqlCommand(sql1, con);
                    com1.ExecuteNonQuery();
                    con.Close();
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
                            con.Open();
                            // Console.Write(" \n");
                            j_1++;

                            sql1 = "insert  into t130_2100(id,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,aa,bb,cc,dd,ee,ff,gg,hh,ii,jj,kk,ll,mm,nn,oo,pp,qq,rr,ss,tt,uu,vv,ww,xx,yy,zz,aaa,bbb,ccc,ddd,eee,fff,ggg,hhh,iii,jjj,kkk,lll,mmm,nnn,ooo,ppp,qqq,rrr,sss,ttt,uuu,vvv,www,xxx,yyy,zzz,aaaa,bbbb,cccc,dddd,eeee,ffff,gggg,hhhh,iiii,jjjj,kkkk,llll,mmmm,nnnn,oooo,pppp,qqqq,rrrr,ssss,tttt,uuuu,vvvv,wwww,xxxx,yyyy,zzzz,aaaaa,bbbbb,ccccc,ddddd,eeeee,fffff,ggggg,hhhhh,iiiii,jjjjj,kkkkk,lllll,mmmmm,nnnnn,ooooo,ppppp,qqqqq,rrrrr,sssss,ttttt,uuuuu,vvvvv,wwwww,xxxxx,yyyyy,zzzzz,a_1,dis,time_,tabu_state) values('"
                                     + j_1 + "','" + tlist[j, 0] + "','" + tlist[j, 1] + "','" + tlist[j, 2] + "','" + tlist[j, 3] + "','" + tlist[j, 4] + "','" + tlist[j, 5] + "','" + tlist[j, 6] + "','" + tlist[j, 7] + "','" + tlist[j, 8] + "','" + tlist[j, 9] + "','" + tlist[j, 10] + "','" + tlist[j, 11] + "','" + tlist[j, 12] + "','"
                                     + tlist[j, 13] + "','" + tlist[j, 14] + "','" + tlist[j, 15] + "','" + tlist[j, 16] + "','" + tlist[j, 17] + "','" + tlist[j, 18] + "','" + tlist[j, 19] + "','" + tlist[j, 20] + "','" + tlist[j, 21] + "','" + tlist[j, 22] + "','" + tlist[j, 23] + "','" + tlist[j, 24] + "','" + tlist[j, 25] + "','"
                                     + tlist[j, 26] + "','" + tlist[j, 27] + "','" + tlist[j, 28] + "','" + tlist[j, 29] + "','" + tlist[j, 30] + "','" + tlist[j, 31] + "','" + tlist[j, 32] + "','" + tlist[j, 33] + "','" + tlist[j, 34] + "','" + tlist[j, 35] + "','" + tlist[j, 36] + "','" + tlist[j, 37] + "','" + tlist[j, 38] + "','"
                                     + tlist[j, 39] + "','" + tlist[j, 40] + "','" + tlist[j, 41] + "','" + tlist[j, 42] + "','" + tlist[j, 43] + "','" + tlist[j, 44] + "','" + tlist[j, 45] + "','" + tlist[j, 46] + "','" + tlist[j, 47] + "','" + tlist[j, 48] + "','" + tlist[j, 49] + "','" + tlist[j, 50] + "','" + tlist[j, 51] + "','"
                                     + tlist[j, 52] + "','" + tlist[j, 53] + "','" + tlist[j, 54] + "','" + tlist[j, 55] + "','" + tlist[j, 56] + "','" + tlist[j, 57] + "','" + tlist[j, 58] + "','" + tlist[j, 59] + "','" + tlist[j, 60] + "','" + tlist[j, 61] + "','" + tlist[j, 62] + "','" + tlist[j, 63] + "','" + tlist[j, 64] + "','"
                                     + tlist[j, 65] + "','" + tlist[j, 66] + "','" + tlist[j, 67] + "','" + tlist[j, 68] + "','" + tlist[j, 69] + "','" + tlist[j, 70] + "','" + tlist[j, 71] + "','" + tlist[j, 72] + "','" + tlist[j, 73] + "','" + tlist[j, 74] + "','" + tlist[j, 75] + "','" + tlist[j, 76] + "','" + tlist[j, 77] + "','"
                                     + tlist[j, 78] + "','" + tlist[j, 79] + "','" + tlist[j, 80] + "','" + tlist[j, 81] + "','" + tlist[j, 82] + "','" + tlist[j, 83] + "','" + tlist[j, 84] + "','" + tlist[j, 85] + "','" + tlist[j, 86] + "','" + tlist[j, 87] + "','" + tlist[j, 88] + "','" + tlist[j, 89] + "','" + tlist[j, 90] + "','"
                                     + tlist[j, 91] + "','" + tlist[j, 92] + "','" + tlist[j, 93] + "','" + tlist[j, 94] + "','" + tlist[j, 95] + "','" + tlist[j, 96] + "','" + tlist[j, 97] + "','" + tlist[j, 98] + "','" + tlist[j, 99] + "','" + tlist[j, 100] + "','" + tlist[j, 101] + "','" + tlist[j, 102] + "','" + tlist[j, 103] + "','"
                                     + tlist[j, 104] + "','" + tlist[j, 105] + "','" + tlist[j, 106] + "','" + tlist[j, 107] + "','" + tlist[j, 108] + "','" + tlist[j, 109] + "','" + tlist[j, 110] + "','" + tlist[j, 111] + "','" + tlist[j, 112] + "','" + tlist[j, 113] + "','" + tlist[j, 114] + "','" + tlist[j, 115] + "','" + tlist[j, 116] + "','"
                                     + tlist[j, 117] + "','" + tlist[j, 118] + "','" + tlist[j, 119] + "','" + tlist[j, 120] + "','" + tlist[j, 121] + "','" + tlist[j, 122] + "','" + tlist[j, 123] + "','" + tlist[j, 124] + "','" + tlist[j, 125] + "','" + tlist[j, 126] + "','" + tlist[j, 127] + "','" + tlist[j, 128] + "','" + tlist[j, 129] + "','"
                             + tlist[j, 130] + "','" + tlist[j, 131] + "','" + tlist[j, 132] + "','" + tlist[j, 133] + "')";//这块是用来把数据插入数据库表中的
                            SqlCommand com2 = new SqlCommand(sql1, con);

                            com2.ExecuteNonQuery();
                            con.Close();
                            // Console.Write(" \n");
                        }
                    }
                    datetime15 = DateTime.Now;
                }
                if (z == 3000)
                {
                    datetime16 = DateTime.Now;
                    //输出禁忌表，不包含擂台赛失败的解，即均为pareto解集
                    // Console.Write(" 第50次迭代的禁忌表：\n");
                    string sql1 = "";//用来盛放sql语句
                   // SqlConnection con1 = new SqlConnection();//建立连接

                 //   con1.ConnectionString = "server=(local);uid=sa;pwd=1hu2xin3min;database=ldq";//连接数据库
                    con.Open();         //打开连接
                    sql1 = "DELETE  FROM t130_3000";
                    SqlCommand com1 = new SqlCommand(sql1, con);
                    com1.ExecuteNonQuery();
                    con.Close();
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
                            con.Open();
                            // Console.Write(" \n");
                            j_1++;

                            sql1 = "insert  into t130_3000(id,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,aa,bb,cc,dd,ee,ff,gg,hh,ii,jj,kk,ll,mm,nn,oo,pp,qq,rr,ss,tt,uu,vv,ww,xx,yy,zz,aaa,bbb,ccc,ddd,eee,fff,ggg,hhh,iii,jjj,kkk,lll,mmm,nnn,ooo,ppp,qqq,rrr,sss,ttt,uuu,vvv,www,xxx,yyy,zzz,aaaa,bbbb,cccc,dddd,eeee,ffff,gggg,hhhh,iiii,jjjj,kkkk,llll,mmmm,nnnn,oooo,pppp,qqqq,rrrr,ssss,tttt,uuuu,vvvv,wwww,xxxx,yyyy,zzzz,aaaaa,bbbbb,ccccc,ddddd,eeeee,fffff,ggggg,hhhhh,iiiii,jjjjj,kkkkk,lllll,mmmmm,nnnnn,ooooo,ppppp,qqqqq,rrrrr,sssss,ttttt,uuuuu,vvvvv,wwwww,xxxxx,yyyyy,zzzzz,a_1,dis,time_,tabu_state) values('"
                                     + j_1 + "','" + tlist[j, 0] + "','" + tlist[j, 1] + "','" + tlist[j, 2] + "','" + tlist[j, 3] + "','" + tlist[j, 4] + "','" + tlist[j, 5] + "','" + tlist[j, 6] + "','" + tlist[j, 7] + "','" + tlist[j, 8] + "','" + tlist[j, 9] + "','" + tlist[j, 10] + "','" + tlist[j, 11] + "','" + tlist[j, 12] + "','"
                                     + tlist[j, 13] + "','" + tlist[j, 14] + "','" + tlist[j, 15] + "','" + tlist[j, 16] + "','" + tlist[j, 17] + "','" + tlist[j, 18] + "','" + tlist[j, 19] + "','" + tlist[j, 20] + "','" + tlist[j, 21] + "','" + tlist[j, 22] + "','" + tlist[j, 23] + "','" + tlist[j, 24] + "','" + tlist[j, 25] + "','"
                                     + tlist[j, 26] + "','" + tlist[j, 27] + "','" + tlist[j, 28] + "','" + tlist[j, 29] + "','" + tlist[j, 30] + "','" + tlist[j, 31] + "','" + tlist[j, 32] + "','" + tlist[j, 33] + "','" + tlist[j, 34] + "','" + tlist[j, 35] + "','" + tlist[j, 36] + "','" + tlist[j, 37] + "','" + tlist[j, 38] + "','"
                                     + tlist[j, 39] + "','" + tlist[j, 40] + "','" + tlist[j, 41] + "','" + tlist[j, 42] + "','" + tlist[j, 43] + "','" + tlist[j, 44] + "','" + tlist[j, 45] + "','" + tlist[j, 46] + "','" + tlist[j, 47] + "','" + tlist[j, 48] + "','" + tlist[j, 49] + "','" + tlist[j, 50] + "','" + tlist[j, 51] + "','"
                                     + tlist[j, 52] + "','" + tlist[j, 53] + "','" + tlist[j, 54] + "','" + tlist[j, 55] + "','" + tlist[j, 56] + "','" + tlist[j, 57] + "','" + tlist[j, 58] + "','" + tlist[j, 59] + "','" + tlist[j, 60] + "','" + tlist[j, 61] + "','" + tlist[j, 62] + "','" + tlist[j, 63] + "','" + tlist[j, 64] + "','"
                                     + tlist[j, 65] + "','" + tlist[j, 66] + "','" + tlist[j, 67] + "','" + tlist[j, 68] + "','" + tlist[j, 69] + "','" + tlist[j, 70] + "','" + tlist[j, 71] + "','" + tlist[j, 72] + "','" + tlist[j, 73] + "','" + tlist[j, 74] + "','" + tlist[j, 75] + "','" + tlist[j, 76] + "','" + tlist[j, 77] + "','"
                                     + tlist[j, 78] + "','" + tlist[j, 79] + "','" + tlist[j, 80] + "','" + tlist[j, 81] + "','" + tlist[j, 82] + "','" + tlist[j, 83] + "','" + tlist[j, 84] + "','" + tlist[j, 85] + "','" + tlist[j, 86] + "','" + tlist[j, 87] + "','" + tlist[j, 88] + "','" + tlist[j, 89] + "','" + tlist[j, 90] + "','"
                                     + tlist[j, 91] + "','" + tlist[j, 92] + "','" + tlist[j, 93] + "','" + tlist[j, 94] + "','" + tlist[j, 95] + "','" + tlist[j, 96] + "','" + tlist[j, 97] + "','" + tlist[j, 98] + "','" + tlist[j, 99] + "','" + tlist[j, 100] + "','" + tlist[j, 101] + "','" + tlist[j, 102] + "','" + tlist[j, 103] + "','"
                                     + tlist[j, 104] + "','" + tlist[j, 105] + "','" + tlist[j, 106] + "','" + tlist[j, 107] + "','" + tlist[j, 108] + "','" + tlist[j, 109] + "','" + tlist[j, 110] + "','" + tlist[j, 111] + "','" + tlist[j, 112] + "','" + tlist[j, 113] + "','" + tlist[j, 114] + "','" + tlist[j, 115] + "','" + tlist[j, 116] + "','"
                                     + tlist[j, 117] + "','" + tlist[j, 118] + "','" + tlist[j, 119] + "','" + tlist[j, 120] + "','" + tlist[j, 121] + "','" + tlist[j, 122] + "','" + tlist[j, 123] + "','" + tlist[j, 124] + "','" + tlist[j, 125] + "','" + tlist[j, 126] + "','" + tlist[j, 127] + "','" + tlist[j, 128] + "','" + tlist[j, 129] + "','"
                             + tlist[j, 130] + "','" + tlist[j, 131] + "','" + tlist[j, 132] + "','" + tlist[j, 133] + "')";//这块是用来把数据插入数据库表中的
                            SqlCommand com2 = new SqlCommand(sql1, con);

                            com2.ExecuteNonQuery();
                            con.Close();
                            // Console.Write(" \n");
                        }
                    }
                    datetime17 = DateTime.Now;
                }
                if (z == 4000)
                {
                    datetime18 = DateTime.Now;
                    //输出禁忌表，不包含擂台赛失败的解，即均为pareto解集
                    // Console.Write(" 第50次迭代的禁忌表：\n");
                    string sql1 = "";//用来盛放sql语句
                //    SqlConnection con1 = new SqlConnection();//建立连接

                  //  con1.ConnectionString = "server=(local);uid=sa;pwd=1hu2xin3min;database=ldq";//连接数据库
                    con.Open();         //打开连接
                    sql1 = "DELETE  FROM t130_4000";
                    SqlCommand com1 = new SqlCommand(sql1, con);
                    com1.ExecuteNonQuery();
                    con.Close();
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
                            con.Open();
                            // Console.Write(" \n");
                            j_1++;

                            sql1 = "insert  into t130_4000(id,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,aa,bb,cc,dd,ee,ff,gg,hh,ii,jj,kk,ll,mm,nn,oo,pp,qq,rr,ss,tt,uu,vv,ww,xx,yy,zz,aaa,bbb,ccc,ddd,eee,fff,ggg,hhh,iii,jjj,kkk,lll,mmm,nnn,ooo,ppp,qqq,rrr,sss,ttt,uuu,vvv,www,xxx,yyy,zzz,aaaa,bbbb,cccc,dddd,eeee,ffff,gggg,hhhh,iiii,jjjj,kkkk,llll,mmmm,nnnn,oooo,pppp,qqqq,rrrr,ssss,tttt,uuuu,vvvv,wwww,xxxx,yyyy,zzzz,aaaaa,bbbbb,ccccc,ddddd,eeeee,fffff,ggggg,hhhhh,iiiii,jjjjj,kkkkk,lllll,mmmmm,nnnnn,ooooo,ppppp,qqqqq,rrrrr,sssss,ttttt,uuuuu,vvvvv,wwwww,xxxxx,yyyyy,zzzzz,a_1,dis,time_,tabu_state) values('"
                                     + j_1 + "','" + tlist[j, 0] + "','" + tlist[j, 1] + "','" + tlist[j, 2] + "','" + tlist[j, 3] + "','" + tlist[j, 4] + "','" + tlist[j, 5] + "','" + tlist[j, 6] + "','" + tlist[j, 7] + "','" + tlist[j, 8] + "','" + tlist[j, 9] + "','" + tlist[j, 10] + "','" + tlist[j, 11] + "','" + tlist[j, 12] + "','"
                                     + tlist[j, 13] + "','" + tlist[j, 14] + "','" + tlist[j, 15] + "','" + tlist[j, 16] + "','" + tlist[j, 17] + "','" + tlist[j, 18] + "','" + tlist[j, 19] + "','" + tlist[j, 20] + "','" + tlist[j, 21] + "','" + tlist[j, 22] + "','" + tlist[j, 23] + "','" + tlist[j, 24] + "','" + tlist[j, 25] + "','"
                                     + tlist[j, 26] + "','" + tlist[j, 27] + "','" + tlist[j, 28] + "','" + tlist[j, 29] + "','" + tlist[j, 30] + "','" + tlist[j, 31] + "','" + tlist[j, 32] + "','" + tlist[j, 33] + "','" + tlist[j, 34] + "','" + tlist[j, 35] + "','" + tlist[j, 36] + "','" + tlist[j, 37] + "','" + tlist[j, 38] + "','"
                                     + tlist[j, 39] + "','" + tlist[j, 40] + "','" + tlist[j, 41] + "','" + tlist[j, 42] + "','" + tlist[j, 43] + "','" + tlist[j, 44] + "','" + tlist[j, 45] + "','" + tlist[j, 46] + "','" + tlist[j, 47] + "','" + tlist[j, 48] + "','" + tlist[j, 49] + "','" + tlist[j, 50] + "','" + tlist[j, 51] + "','"
                                     + tlist[j, 52] + "','" + tlist[j, 53] + "','" + tlist[j, 54] + "','" + tlist[j, 55] + "','" + tlist[j, 56] + "','" + tlist[j, 57] + "','" + tlist[j, 58] + "','" + tlist[j, 59] + "','" + tlist[j, 60] + "','" + tlist[j, 61] + "','" + tlist[j, 62] + "','" + tlist[j, 63] + "','" + tlist[j, 64] + "','"
                                     + tlist[j, 65] + "','" + tlist[j, 66] + "','" + tlist[j, 67] + "','" + tlist[j, 68] + "','" + tlist[j, 69] + "','" + tlist[j, 70] + "','" + tlist[j, 71] + "','" + tlist[j, 72] + "','" + tlist[j, 73] + "','" + tlist[j, 74] + "','" + tlist[j, 75] + "','" + tlist[j, 76] + "','" + tlist[j, 77] + "','"
                                     + tlist[j, 78] + "','" + tlist[j, 79] + "','" + tlist[j, 80] + "','" + tlist[j, 81] + "','" + tlist[j, 82] + "','" + tlist[j, 83] + "','" + tlist[j, 84] + "','" + tlist[j, 85] + "','" + tlist[j, 86] + "','" + tlist[j, 87] + "','" + tlist[j, 88] + "','" + tlist[j, 89] + "','" + tlist[j, 90] + "','"
                                     + tlist[j, 91] + "','" + tlist[j, 92] + "','" + tlist[j, 93] + "','" + tlist[j, 94] + "','" + tlist[j, 95] + "','" + tlist[j, 96] + "','" + tlist[j, 97] + "','" + tlist[j, 98] + "','" + tlist[j, 99] + "','" + tlist[j, 100] + "','" + tlist[j, 101] + "','" + tlist[j, 102] + "','" + tlist[j, 103] + "','"
                                     + tlist[j, 104] + "','" + tlist[j, 105] + "','" + tlist[j, 106] + "','" + tlist[j, 107] + "','" + tlist[j, 108] + "','" + tlist[j, 109] + "','" + tlist[j, 110] + "','" + tlist[j, 111] + "','" + tlist[j, 112] + "','" + tlist[j, 113] + "','" + tlist[j, 114] + "','" + tlist[j, 115] + "','" + tlist[j, 116] + "','"
                                     + tlist[j, 117] + "','" + tlist[j, 118] + "','" + tlist[j, 119] + "','" + tlist[j, 120] + "','" + tlist[j, 121] + "','" + tlist[j, 122] + "','" + tlist[j, 123] + "','" + tlist[j, 124] + "','" + tlist[j, 125] + "','" + tlist[j, 126] + "','" + tlist[j, 127] + "','" + tlist[j, 128] + "','" + tlist[j, 129] + "','"
                             + tlist[j, 130] + "','" + tlist[j, 131] + "','" + tlist[j, 132] + "','" + tlist[j, 133] + "')";//这块是用来把数据插入数据库表中的
                            SqlCommand com2 = new SqlCommand(sql1, con);

                            com2.ExecuteNonQuery();
                            con.Close();
                            // Console.Write(" \n");
                        }
                    }
                    datetime19 = DateTime.Now;
                }
            }//**********************************************************************************************循环结束*************************************

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
            //           Console.Write(" 迭代结束后的禁忌表：\n");
            pareto_num = 0;
            for (int j = 0; j < t_length; j++)
            {
                if (tlist[j, n + 3] != 100)
                {
                    pareto_num++;
                 /*   for (int i = 0; i < n + 4; i++)
                    {

                        Console.Write(tlist[j, i] + " ");
                        
                    }
                    Console.Write(" \n");*/
                }
            }

           //获得datetime1和datetime2之间的间隔，具体时间可以从subtime中分离出来。
         /*   TimeSpan subtime = datetime15.Subtract(datetime1);
           
            TimeSpan subtime500 = datetime5.Subtract(datetime4);
           
            TimeSpan subtime900 = datetime9.Subtract(datetime8);
            TimeSpan subtime1300 = datetime11.Subtract(datetime10);
            TimeSpan subtime1700= datetime13.Subtract(datetime12);
            TimeSpan subtime2100 = datetime15.Subtract(datetime14);
            TimeSpan subtime3000 = datetime17.Subtract(datetime16);
            TimeSpan subtime4000 = datetime19.Subtract(datetime18);
            TimeSpan subtime1 = subtime  - subtime500  - subtime900 - subtime1300 - subtime1700 - subtime2100 - subtime3000 - subtime4000;

            Console.Write(" 执行程序用时： " + subtime1 + " s ");
            Console.Write(" \n");
            Console.Write(" 共求出解的数量： " + tabu_num + " 个 ");

            Console.ReadLine();*/

        }
        public void insert_info()
        {
            //获得datetime1和datetime2之间的间隔，具体时间可以从subtime中分离出来。
            TimeSpan subtime = datetime15.Subtract(datetime1);

            TimeSpan subtime500 = datetime5.Subtract(datetime4);

            TimeSpan subtime900 = datetime9.Subtract(datetime8);
            TimeSpan subtime1300 = datetime11.Subtract(datetime10);
            TimeSpan subtime1700 = datetime13.Subtract(datetime12);
            TimeSpan subtime2100 = datetime15.Subtract(datetime14);
            TimeSpan subtime3000 = datetime17.Subtract(datetime16);
            TimeSpan subtime4000 = datetime19.Subtract(datetime18);
            TimeSpan subtime1 = subtime - subtime500 - subtime900 - subtime1300 - subtime1700 - subtime2100 - subtime3000 - subtime4000;
          
            Double subtime1_=subtime1.TotalSeconds;
            Double pareto_num_ = (Double)pareto_num;
            string sql1 = "";//用来盛放sql语句
         
            con.Open();         //打开连接
            sql1 = "DELETE  FROM info";
            SqlCommand com1 = new SqlCommand(sql1, con);
            com1.ExecuteNonQuery();

            sql1 = "insert  into info(diedai,time,pareto_num)values(4000 ,'" + subtime1_ + "','" + pareto_num_ + "')";
            SqlCommand com2 = new SqlCommand(sql1, con);
            com2.ExecuteNonQuery();
            con.Close();

            /*查询datatime具体用法，赋值的用法
             */
        }
      

    }

