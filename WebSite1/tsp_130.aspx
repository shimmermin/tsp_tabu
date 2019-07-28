<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tsp_130.aspx.cs" Inherits="tsp_130" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
      <script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
   
    <script type="text/javascript" src="Scripts/jquery.js"></script>
   <script type="text/javascript" src="echarts/echarts.js"></script>
    <script type="text/javascript" src="echarts/echarts-all.js"></script>
    <script type="text/javascript" src="http://echarts.baidu.com/doc/example/timelineOption.js"></script> 
  
</head>

<body>
    <form id="form1" runat="server">
    <div  id="body" style=" height: 1000px;width:1100px; background-color:		#2F4F4F" >
    
    <div  id="chart"  style=" height: 850px;width:1100px;" >

        </div>
    <div  id="text" style=" height: 100px;width:1300px;">
       
        &nbsp; 
        <asp:button ID="Button1" runat="server" text="开始" 
            onclick="Unnamed1_Click" Height="44px"  Font-Size="X-Large"
        Width="99px" ForeColor="	#FFFFFF"  BackColor="		#2F4F4F"/>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="cishu" runat="server" Text="迭代次数：" Font-Size="X-Large" ForeColor="	#FFFFFF"></asp:Label>
       
&nbsp;
     
      
        <asp:Label ID="Label1" runat="server" Text="" Font-Size="X-Large" ForeColor="	#FFFFFF"></asp:Label>
        &nbsp;<asp:Label ID="Label6" runat="server" Text="次" Font-Size="Larger" 
            ForeColor="	#FFFFFF"></asp:Label>
    &nbsp;&nbsp; &nbsp;
       
        <asp:Label ID="shijian" runat="server" Text="运行时间：" Font-Size="X-Large" ForeColor="	#FFFFFF"></asp:Label>
        &nbsp;
       
        <asp:Label ID="Label2" runat="server" Text="" Font-Size="X-Large" ForeColor="	#FFFFFF"></asp:Label>
        &nbsp;<asp:Label ID="Label5" runat="server" Text="秒" Font-Size="X-Large" 
            ForeColor="	#FFFFFF"></asp:Label>
    &nbsp;&nbsp; &nbsp;
        <asp:Label ID="num" runat="server" Text="Pareto解的数量：" Font-Size="X-Large" ForeColor="	#FFFFFF"></asp:Label>
        &nbsp;
        <asp:Label ID="Label3" runat="server" Text="" Font-Size="X-Large" ForeColor="	#FFFFFF"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="个" Font-Size="X-Large" ForeColor="	#FFFFFF"></asp:Label>
    </div>
        &nbsp;&nbsp;
        </div>
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   </form>
  <script type="text/javascript" >

      var myChart1;

     

      // 路径配置
      require.config({
          paths: {
              echarts: 'echarts' //echarts路径
          }
      });

      // 使用
      require(
            [
                'echarts', //echarts路径
                'echarts/chart/scatter'// 使用柱状图就加载bar模块，按需加载

            ], DrawEChart
            );

      function DrawEChart(ec) {
          // 基于准备好的dom，初始化echarts图表
          myChart1 = ec.init(document.getElementById('chart')); //ec是function里的参数，main是定义的dom

          option = {
              backgroundColor: '		#2F4F4F',
              title: {
                  x: 30,
                  text: 'Pareto前沿图',
                  textStyle: {
                      fontSize: 30,
                      color: '		#FFFFFF'
                  }
              },

              legend: {
                  y: 10,
                  data: ['500次', '900次', '1300次', '1700次', '2100次', '3000次', '4000次'],
                  textStyle: {
                      color: '	#FFFFFF',
                      fontSize: 20
                  }
              },
              xAxis: {
                  type: 'value',
                  name: '总距离/km',
                  axisLabel: {
                      show: true,
                      textStyle: {
                          color: '	#FFFFFF',
                          fontSize: 30
                      }
                  },
                  axisLine: {
                      lineStyle: {
                          type: 'solid',
                          color: '	#FFFFFF', //左边线的颜色
                          width: '2'//坐标线的宽度
                      }
                  },
                  max: 14000,
                  min: 6000,
                  interval: 2000
              },
              yAxis: {
                  type: 'value',
                  name: '总时间/s',
                  axisLabel: {

                      textStyle: {
                          color: '	#FFFFFF',
                          fontSize: 30
                      }
                  },
                  axisLine: {
                      lineStyle: {
                          type: 'solid',
                          color: '	#FFFFFF',
                          width: '2'
                      }
                  },
                  max: 240,
                  min: 120,
                  interval: 20
              },
              series: [
              {
                  name: '500次',
                  nameTextStyle: {
                      color: '	#FFFFFF',
                      fontSize: 20
                  },
                  symbolSize: 10,
                  itemStyle: {
                      normal: {
                          color: '	#808000',
                          label: {
                              show: true,
                              position: 'top'
                          }
                      }
                  },
                  data: [[0, 0],
                         [0, 0]
                          ],
                  type: 'scatter'
              },
               {
                   name: '900次',
                   nameTextStyle: {
                       color: '	#FFFFFF',
                       fontSize: 20
                   },
                   symbolSize: 10,
                   itemStyle: {
                       normal: {
                           color: '	#3CB371',
                           label: {
                               show: true,
                               position: 'top'
                           }
                       }
                   },
                   data: [[0, 0],
                         [0, 0]
                          ],
                   type: 'scatter'
               },
                {
                    name: '1300次',
                    nameTextStyle: {
                        color: '	#FFFFFF',
                        fontSize: 20
                    },
                    symbolSize: 10,
                    itemStyle: {
                        normal: {
                            color: '#90EE90',
                            label: {
                                show: false,
                                position: 'top'
                            }
                        }
                    },
                    data: [[0, 0],
                         [0, 0]
                          ],
                    type: 'scatter'
                },
                 {
                     name: '1700次',
                     nameTextStyle: {
                         color: '	#FFFFFF',
                         fontSize: 20
                     },
                     symbolSize: 10,
                     itemStyle: {
                         normal: {
                             color: '	#F4A460',
                             label: {
                                 show: false,
                                 position: 'top'
                             }
                         }
                     },
                     data: [[0, 0],
                         [0, 0]
                          ],
                     type: 'scatter'
                 },
                  {
                      name: '2100次',

                      nameTextStyle: {
                          color: '	#FFFFFF',
                          fontSize: 20
                      },
                      symbolSize: 10,
                      itemStyle: {
                          normal: {
                              color: '	#ADFF2F',
                              label: {
                                  show: false,
                                  position: 'top'
                              }
                          }
                      },
                      data: [[0, 0],
                         [0, 0]
                          ],
                      type: 'scatter'
                  },
                   {
                       name: '3000次',

                       nameTextStyle: {
                           color: '	#FFFFFF',
                           fontSize: 20
                       },
                       symbolSize: 10,
                       itemStyle: {
                           normal: {
                               color: '#FF0000',
                               label: {
                                   show: false,
                                   position: 'top'
                               }
                           }
                       },
                       data: [[0, 0],
                         [0, 0]
                          ],
                       type: 'scatter'
                   },
                    {
                        name: '4000次',
                        icon: 'circle',
                        nameTextStyle: {
                            color: '	#FFFFFF',
                            fontSize: 20
                        },
                        symbolSize: 10,
                        itemStyle: {
                            normal: {
                                color: '	#FFFFFF',
                                label: {
                                    show: false,
                                    position: 'top'
                                }
                            }
                        },
                        data: [[0, 0],
                         [0, 0]
                          ],
                        type: 'scatter'
                    }
              ]
          };

          myChart1.setOption(option);



         var inter1 = window.setInterval(function () {

              //通过AJAX获取数据
              $.ajax({
                  type: "POST",
                  async: false, //同步执行 若是true，则可以不用用户操作即执行下一步
                  url: "Foot_130_500.ashx",
                  data: {},
                  dataType: 'json', //返回数据形式为json
                  success: function (result) {
                    //  alert(1);
                      if (result != null) {
                          //alert(result);
                          //   var data = JSON.stringify(result); //当一般处理程序传过来object时使用，否则直接处理result
                          var arr = []; //格式如：[[2020.6,20.3],[1154.3,26.3]];
                          for (var i = 0; i < result.length; i++) {
                              var dis = result[i].dis;
                              var time = result[i].time; 
                              // [总距离，总时间]
                              arr.push([dis, time]);
                          }

                          var moption1 = myChart1.getOption();
                          //   alert(moption1.series[0]['data']); //此句可以成功运行
                          moption1.series[0]['data'] = arr;
                          //   alert(moption1.series[0]['data']); //此句可以成功运行
                          myChart1.setOption(moption1);
                          //   alert(moption1.series[0]['data']); //此句可以成功运行
                          // myChart1.setOption(moption1);

                          clearInterval(inter1); //结束间歇性访问
                      }
                  }
              });
          }, 5000);
          
              //36000
              //900步迭代


              var inter2 = window.setInterval(function () {

                  //通过AJAX获取数据
                  $.ajax({
                      type: "POST",
                      async: false, //同步执行 若是true，则可以不用用户操作即执行下一步
                      url: "Foot_130_900.ashx",
                      data: {},
                      dataType: 'json', //返回数据形式为json
                      success: function (result) {
                          if (result != null) {
                              //alert(result);
                              //   var data = JSON.stringify(result); //当一般处理程序传过来object时使用，否则直接处理result
                              var arr = []; //格式如：[[2020.6,20.3],[1154.3,26.3]];
                              for (var i = 0; i < result.length; i++) {
                                  var dis = result[i].dis;
                                  var time = result[i].time; 
                                  // [总距离，总时间]
                                  arr.push([dis, time]);
                              }

                              var moption1 = myChart1.getOption();
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              moption1.series[1]['data'] = arr;
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              myChart1.setOption(moption1);
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              // myChart1.setOption(moption1);

                              clearInterval(inter2); //结束间歇性访问
                          }
                      }
                  });
              }, 10000);
              //61000





              //1300步迭代


              var inter3 = window.setInterval(function () {

                  //通过AJAX获取数据
                  $.ajax({
                      type: "POST",
                      async: false, //同步执行 若是true，则可以不用用户操作即执行下一步
                      url: "Foot_130_1300.ashx",
                      data: {},
                      dataType: 'json', //返回数据形式为json
                      success: function (result) {
                          if (result != null) {
                              // alert(result);
                              //   var data = JSON.stringify(result); //当一般处理程序传过来object时使用，否则直接处理result
                              var arr = []; //格式如：[[2020.6,20.3],[1154.3,26.3]];
                              for (var i = 0; i < result.length; i++) {
                                  var dis = result[i].dis;
                                  var time = result[i].time; 
                                  // [总距离，总时间]
                                  arr.push([dis, time]);
                              }

                              var moption1 = myChart1.getOption();
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              moption1.series[2]['data'] = arr;
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              myChart1.setOption(moption1);
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              // myChart1.setOption(moption1);

                              clearInterval(inter3); //结束间歇性访问
                          }
                      }
                  });
              }, 15000);
              //86000




              //1700步迭代



              var inter4 = window.setInterval(function () {

                  //通过AJAX获取数据
                  $.ajax({
                      type: "POST",
                      async: false, //同步执行 若是true，则可以不用用户操作即执行下一步
                      url: "Foot_130_1700.ashx",
                      data: {},
                      dataType: 'json', //返回数据形式为json
                      success: function (result) {
                          if (result != null) {
                              // alert(result);
                              //   var data = JSON.stringify(result); //当一般处理程序传过来object时使用，否则直接处理result
                              var arr = []; //格式如：[[2020.6,20.3],[1154.3,26.3]];
                              for (var i = 0; i < result.length; i++) {
                                  var dis = result[i].dis;
                                  var time = result[i].time; 
                                  // [总距离，总时间]
                                  arr.push([dis, time]);
                              }

                              var moption1 = myChart1.getOption();
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              moption1.series[3]['data'] = arr;
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              myChart1.setOption(moption1);
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              // myChart1.setOption(moption1);

                              clearInterval(inter4); //结束间歇性访问
                          }
                      }
                  });
              }, 20000);
              //111000




              //2100步迭代

              var inter5 = window.setInterval(function () {

                  //通过AJAX获取数据
                  $.ajax({
                      type: "POST",
                      async: false, //同步执行 若是true，则可以不用用户操作即执行下一步
                      url: "Foot_130_2100.ashx",
                      data: {},
                      dataType: 'json', //返回数据形式为json
                      success: function (result) {
                          if (result != null) {
                              // alert(result);
                              //   var data = JSON.stringify(result); //当一般处理程序传过来object时使用，否则直接处理result
                              var arr = []; //格式如：[[2020.6,20.3],[1154.3,26.3]];
                              for (var i = 0; i < result.length; i++) {
                                  var dis = result[i].dis;
                                  var time = result[i].time; 
                                  // [总距离，总时间]
                                  arr.push([dis, time]);
                              }

                              var moption1 = myChart1.getOption();
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              moption1.series[4]['data'] = arr;
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              myChart1.setOption(moption1);
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              // myChart1.setOption(moption1);

                              clearInterval(inter5); //结束间歇性访问
                          }
                      }
                  });
              }, 25000);
              //136000




              //3000步迭代


              var inter6 = window.setInterval(function () {

                  //通过AJAX获取数据
                  $.ajax({
                      type: "POST",
                      async: false, //同步执行 若是true，则可以不用用户操作即执行下一步
                      url: "Foot_130_3000.ashx",
                      data: {},
                      dataType: 'json', //返回数据形式为json
                      success: function (result) {
                          if (result != null) {
                              //alert(result);
                              //   var data = JSON.stringify(result); //当一般处理程序传过来object时使用，否则直接处理result
                              var arr = []; //格式如：[[2020.6,20.3],[1154.3,26.3]];
                              for (var i = 0; i < result.length; i++) {
                                  var dis = result[i].dis;
                                  var time = result[i].time; 
                                  // [总距离，总时间]
                                  arr.push([dis, time]);
                              }

                              var moption1 = myChart1.getOption();
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              moption1.series[5]['data'] = arr;
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              myChart1.setOption(moption1);
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              // myChart1.setOption(moption1);

                              clearInterval(inter6); //结束间歇性访问
                          }
                      }
                  });
              }, 33000);
              //166000

              //4000步迭代

              var inter7 = window.setInterval(function () {

                  //通过AJAX获取数据
                  $.ajax({
                      type: "POST",
                      async: false, //同步执行 若是true，则可以不用用户操作即执行下一步
                      url: "Foot_130_4000.ashx",
                      data: {},
                      dataType: 'json', //返回数据形式为json
                      success: function (result) {
                          if (result != null) {
                              //alert(result);
                              //   var data = JSON.stringify(result); //当一般处理程序传过来object时使用，否则直接处理result
                              var arr = []; //格式如：[[2020.6,20.3],[1154.3,26.3]];
                              for (var i = 0; i < result.length; i++) {
                                  var dis = result[i].dis;
                                  var time = result[i].time; 
                                  // [总距离，总时间]
                                  arr.push([dis, time]);
                              }

                              var moption1 = myChart1.getOption();
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              moption1.series[6]['data'] = arr;
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              myChart1.setOption(moption1);
                              //   alert(moption1.series[0]['data']); //此句可以成功运行
                              // myChart1.setOption(moption1);

                              clearInterval(inter7); //结束间歇性访问
                          }
                      }
                  });
              }, 41000);
              //196000    
         
              var inter8 = window.setInterval(function () {

                  //通过AJAX获取数据
                  $.ajax({
                      type: "POST",
                      async: false, //同步执行 若是true，则可以不用用户操作即执行下一步
                      url: "info.ashx",
                      data: {},
                      dataType: 'json', //返回数据形式为json
                      success: function (result) {
                        
                      if (result != null) {
                             //alert(result);
                              //   var data = JSON.stringify(result); //当一般处理程序传过来object时使用，否则直接处理result   
                             var diedai = result.diedai;
                             var time = result.time;
                              // [总距离，总时间]
                            var pareto_num = result.pareto_num;
                            document.getElementById('Label1').innerHTML = diedai.toString();
                             document.getElementById('Label2').innerHTML = time.toString();
                             document.getElementById('Label3').innerHTML = pareto_num.toString();
                              clearInterval(inter8); //结束间歇性访问
                         }
                      }
                  });
              },42000);
              //196000



          }

    
 

 </script>      
    
</body>
</html>
