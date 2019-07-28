<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tsp.aspx.cs" Inherits="tsp" %>

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
       
        &nbsp; <asp:button runat="server" text="开始" 
            onclick="Unnamed1_Click" Height="40px"  Font-Size="X-Large"
        Width="78px" ForeColor="	#FFFFFF"  BackColor="	#2F4F4F"/>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="cishu" runat="server" Text="" Font-Size="X-Large" ForeColor="	#FFFFFF"></asp:Label>
       
&nbsp;
     
      
        <asp:Label ID="Label1" runat="server" Text="" Font-Size="X-Large" ForeColor="	#FFFFFF"></asp:Label>
        &nbsp; &nbsp; &nbsp;
       
        <asp:Label ID="shijian" runat="server" Text="" Font-Size="X-Large" ForeColor="	#FFFFFF"></asp:Label>
        &nbsp;
       
        <asp:Label ID="Label2" runat="server" Text="" Font-Size="X-Large" ForeColor="	#FFFFFF"></asp:Label>
        &nbsp; &nbsp; &nbsp;
        <asp:Label ID="num" runat="server" Text="" Font-Size="X-Large" ForeColor="	#FFFFFF"></asp:Label>
        &nbsp;
        <asp:Label ID="Label3" runat="server" Text="" Font-Size="X-Large" ForeColor="	#FFFFFF"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="" Font-Size="X-Large" ForeColor="	#FFFFFF"></asp:Label>
    </div>
    </div>
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   </form>
  <script type="text/javascript" >

      var myChart1;

      var isRequst1 = true;
     
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
              backgroundColor: '	#2F4F4F',
              title: {
                 x:40,
                 text: 'Pareto前沿图',
                 textStyle: {
                    fontSize: 30,
                    color: '		#FFFFFF'
                }
                      },

            legend: {
                          y: 10,
                          data: [ '50次','100次', '150次', '200次','300次','400次', '500次' ],
                          textStyle: {
                              color: '		#FFFFFF',
                              fontSize: 20
                          }
                      },
              xAxis: {
                  type: 'value',
                  name: '总距离/km',
                  axisLabel: {
                            show: true,
                            textStyle: {
                                color: '		#FFFFFF',
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
                  max: 29000,
                  min: 15000,
                  interval: 3000
              },
              yAxis: {
                  type: 'value',
                  name: '总时间/s',
                   axisLabel : {
                           
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
                  max:34,
                  min:19,
                  interval:3
              },
              series: [
              {
                  name: '50次',
                  nameTextStyle: {
                      color: '	#FFFFFF',
                      fontSize: 20
                  },
                  symbolSize: 10,
                  itemStyle: {
                      normal: {
                          color: '	#808000 ',                                               
                          label: {
                              show: true,
                              position: 'top'                            
                          }
                      }
                  },
                  data: [[0, 0],
                         [0,0]
                          ],  
                  type: 'scatter'
              },
               {
                   name: '100次',
                   nameTextStyle: {
                       color: '	#FFFFFF',
                       fontSize: 20
                   },
                   symbolSize: 10,
                   itemStyle: {
                       normal: {
                           color: '#3CB371',
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
                    name: '150次',
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
                     name: '200次',
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
                      name: '300次',
                    
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
                       name: '400次',
                     
                       nameTextStyle: {
                           color: '	#FFFFFF',
                           fontSize: 20
                       },
                       symbolSize: 10,
                       itemStyle: {
                           normal: {
                               color: '		#FF0000',
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
                        name: '500次',
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


          if (isRequst1) {
              isRequst1 = false;
              var inter1 = window.setInterval(function () {

                  //通过AJAX获取数据
                  $.ajax({
                      type: "POST",
                      async: false, //同步执行 若是true，则可以不用用户操作即执行下一步
                      url: "Foot_50.ashx",
                      data: {},
                      dataType: 'json', //返回数据形式为json
                      success: function (result) {
                          if (result != null) {
                              //  alert(result);
                              //   var data = JSON.stringify(result); //当一般处理程序传过来object时使用，否则直接处理result
                              var arr = []; //格式如：[[2020.6,20.3],[1154.3,26.3]];
                              for (var i = 0; i < result.length; i++) {
                                  var dis = result[i].dis;
                                  var time = result[i].time; ;
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
              }, 500);
          }

              //100步迭代


              var inter2 = window.setInterval(function () {

                  //通过AJAX获取数据
                  $.ajax({
                      type: "POST",
                      async: false, //同步执行 若是true，则可以不用用户操作即执行下一步
                      url: "Foot_100.ashx",
                      data: {},
                      dataType: 'json', //返回数据形式为json
                      success: function (result) {
                          if (result != null) {
                              //alert(result);
                              //   var data = JSON.stringify(result); //当一般处理程序传过来object时使用，否则直接处理result
                              var arr = []; //格式如：[[2020.6,20.3],[1154.3,26.3]];
                              for (var i = 0; i < result.length; i++) {
                                  var dis = result[i].dis;
                                  var time = result[i].time; ;
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
              }, 700);






              //150步迭代


              var inter3 = window.setInterval(function () {

                  //通过AJAX获取数据
                  $.ajax({
                      type: "POST",
                      async: false, //同步执行 若是true，则可以不用用户操作即执行下一步
                      url: "Foot_150.ashx",
                      data: {},
                      dataType: 'json', //返回数据形式为json
                      success: function (result) {
                          if (result != null) {
                              // alert(result);
                              //   var data = JSON.stringify(result); //当一般处理程序传过来object时使用，否则直接处理result
                              var arr = []; //格式如：[[2020.6,20.3],[1154.3,26.3]];
                              for (var i = 0; i < result.length; i++) {
                                  var dis = result[i].dis;
                                  var time = result[i].time; ;
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
              }, 900);





              //200步迭代



              var inter4 = window.setInterval(function () {

                  //通过AJAX获取数据
                  $.ajax({
                      type: "POST",
                      async: false, //同步执行 若是true，则可以不用用户操作即执行下一步
                      url: "Foot_200.ashx",
                      data: {},
                      dataType: 'json', //返回数据形式为json
                      success: function (result) {
                          if (result != null) {
                              // alert(result);
                              //   var data = JSON.stringify(result); //当一般处理程序传过来object时使用，否则直接处理result
                              var arr = []; //格式如：[[2020.6,20.3],[1154.3,26.3]];
                              for (var i = 0; i < result.length; i++) {
                                  var dis = result[i].dis;
                                  var time = result[i].time; ;
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
              }, 1100);





              //300步迭代

              var inter5 = window.setInterval(function () {

                  //通过AJAX获取数据
                  $.ajax({
                      type: "POST",
                      async: false, //同步执行 若是true，则可以不用用户操作即执行下一步
                      url: "Foot_300.ashx",
                      data: {},
                      dataType: 'json', //返回数据形式为json
                      success: function (result) {
                          if (result != null) {
                              // alert(result);
                              //   var data = JSON.stringify(result); //当一般处理程序传过来object时使用，否则直接处理result
                              var arr = []; //格式如：[[2020.6,20.3],[1154.3,26.3]];
                              for (var i = 0; i < result.length; i++) {
                                  var dis = result[i].dis;
                                  var time = result[i].time; ;
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
              }, 1400);





              //400步迭代


              var inter6 = window.setInterval(function () {

                  //通过AJAX获取数据
                  $.ajax({
                      type: "POST",
                      async: false, //同步执行 若是true，则可以不用用户操作即执行下一步
                      url: "Foot_400.ashx",
                      data: {},
                      dataType: 'json', //返回数据形式为json
                      success: function (result) {
                          if (result != null) {
                              //alert(result);
                              //   var data = JSON.stringify(result); //当一般处理程序传过来object时使用，否则直接处理result
                              var arr = []; //格式如：[[2020.6,20.3],[1154.3,26.3]];
                              for (var i = 0; i < result.length; i++) {
                                  var dis = result[i].dis;
                                  var time = result[i].time; ;
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
              }, 1800);


              //500步迭代

              var inter7 = window.setInterval(function () {

                  //通过AJAX获取数据
                  $.ajax({
                      type: "POST",
                      async: false, //同步执行 若是true，则可以不用用户操作即执行下一步
                      url: "Foot_500.ashx",
                      data: {},
                      dataType: 'json', //返回数据形式为json
                      success: function (result) {
                          if (result != null) {
                              //alert(result);
                              //   var data = JSON.stringify(result); //当一般处理程序传过来object时使用，否则直接处理result
                              var arr = []; //格式如：[[2020.6,20.3],[1154.3,26.3]];
                              for (var i = 0; i < result.length; i++) {
                                  var dis = result[i].dis;
                                  var time = result[i].time; ;
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
              }, 2000);
        

          
   }


 

 </script>      
    </body>
</html>
 


   
 
   
 

 
 
 




 

    

 

           

       