using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //数字转人民币大写
            //decimal a = 100;
            //var a1=  NumberToRMBHelper.CmycurD(a);
            //decimal b =Convert.ToDecimal(0.01);
            //var b1 = NumberToRMBHelper.CmycurD(b);
            //decimal c = Convert.ToDecimal(101.1);
            //var c1 = NumberToRMBHelper.CmycurD(c);
            //decimal d = Convert.ToDecimal(1230.01);
            //var d1 = NumberToRMBHelper.CmycurD(d);

            //拼音
            // var str = "张三";
            //var str1= PinYinHelper.ConvertToAllSpell(str);
            // var str2 = PinYinHelper.GetFirstSpell(str);

            //身份证
            //朱泽洋 51170219740419175X
            //罗嘉懿 511702198504283656
            //蒋开霁 511702197901178476
            var number1 = "51170219740419175X";
            var number2 = "511702198504283656";
            var number3 = "511702197901178476";
           var a1= IDCard.TryParse(number1,out IDCard idCard1);
            var a2 = IDCard.TryParse(number1, out IDCard idCard2);
            var a3 = IDCard.TryParse(number1, out IDCard idCard3);
        }
    }
}
