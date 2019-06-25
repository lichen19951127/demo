using System;
using System.Collections.Generic;
using System.Text;

namespace Lucky
{
    class UserHelper
    {
        //名额设置的默认值
        public static int one = 3;
        public static int two = 10;
        public static int three = 20;
        public static int four = 50;
        public static int five = 80;
        public static int te = 1;
        public static int allset = 0;            //设置抽奖的总名额  

        public static string setwin = "";
        public static string[] setwin1=new string[10];
        public static string[] setwin2 = new string[20];
        public static string[] setwin3 = new string[50];
        public static string[] setwin4 = new string[100];
        public static string[] setwin5 = new string[100];

        public static string[] sname;                     //名字数组(所有成员)
        public static string[] wintemp = new string[500]; //保存一等奖的下标(防止重复中奖)

        public static string[] yiwinner = new string[10];  //一等奖获得者
        public static string[] erwinner = new string[20];  //二等奖获得者
        public static string[] sanwinner = new string[50]; //三等奖获得者
        public static string[] siwinner = new string[100]; //三等奖获得者
        public static string[] wuwinner = new string[100]; //三等奖获得者
        public static string[] twinner = new string[1]; //三等奖获得者

    }
}
