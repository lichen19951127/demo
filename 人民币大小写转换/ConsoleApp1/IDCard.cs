using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /// <summary>
    /// 身份证
    /// </summary>
    [Serializable]
    public class IDCard
    {
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCardNum { get; set; }
        /// <summary>
        /// 行政区
        /// </summary>
        public string Canton { get; private set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime Birthday { get; private set; }
        /// <summary>
        /// 性别(0-女；1-男)
        /// </summary>
        public int Gander { get; private set; }
        /// <summary>
        /// 是否为合法身份证号
        /// </summary>
        public bool IsIDCard { get; private set; }

        public IDCard() { }

        public IDCard(string IDnumber)
        {
            this.IDCardNum = IDnumber;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static IDCard Parse(string number)
        {
            IDCard idCard = new IDCard(number);

            const int s5bits = 15;
            const int s8bits = 18;

            #region 15位
            if (number.Length == s5bits)  //15位的处理
            {
                //检查输入是否为数字
                for (int i = 0; i < number.Length; i++)
                {
                    if ((number[i] < '0') || (number[i] > '9'))
                    {
                        throw new FormatException("身份证号错误");
                    }
                }

                //出生日期
                string birthday = "19" + number.Substring(6, 6);
                string year = birthday.Substring(0, 4);
                string month = birthday.Substring(4, 2);
                string day = birthday.Substring(6, 2);
                birthday = string.Format("{0}-{1}-{2}", year, month, day);

                DateTime date = new DateTime();
                if (DateTime.TryParse(birthday, out date))
                {
                    idCard.Birthday = date;
                }
                else
                {
                    throw new InvalidCastException("身份证号出生日期错误");
                }

                //性别
                if ((number[s5bits - 1] == '0') || (number[s5bits - 1] % 2 == 0))
                {
                    idCard.Gander = 0; // 女
                }
                else
                {
                    idCard.Gander = 1; // 男
                }

                idCard.IsIDCard = true;
                return idCard;
            }
            #endregion

            #region 18位
            else if (number.Length == s8bits)  //18位的处理
            {
                // 检查前17位是否为数字
                for (int i = 0; i < number.Length - 1; i++)
                {
                    if ((number[i] < '0') || (number[i] > '9'))
                    {
                        throw new FormatException("身份证号错误");
                    }
                }

                char end = number[s8bits - 1];  //最后一位

                //最后1位是x转成大写X
                if (end == 'x')
                {
                    end = 'X';
                    number = number.Substring(0, s8bits - 1) + end;
                }

                if (!(end == 'X' || (end >= '0' && end <= '9')))
                {
                    throw new FormatException("身份证号错误");
                }

                /// 校验
                int num = 0;
                char proof;
                for (int i = 17; i > 0; i--)
                {
                    num = num + (int)(Math.Pow(2, i) % 11) * (number[17 - i] - 48);
                }
                num %= 11;
                switch (num)
                {
                    case 0:
                        proof = '1';
                        break;
                    case 1:
                        proof = '0';
                        break;
                    case 2:
                        proof = 'X';
                        break;
                    default:
                        proof = (char)(12 - num + 48);
                        break;
                }

                if (end != proof)  //最后一位与校验码不符
                {
                    throw new FormatException("身份证号错误");
                }

                //出生日期
                string birthday = number.Substring(6, 8);
                string year = birthday.Substring(0, 4);
                string month = birthday.Substring(4, 2);
                string day = birthday.Substring(6, 2);
                birthday = string.Format("{0}-{1}-{2}", year, month, day);

                DateTime date = new DateTime();
                if (DateTime.TryParse(birthday, out date))
                {
                    idCard.Birthday = date;
                }
                else
                {
                    throw new InvalidCastException("身份证号出生日期错误");
                }

                //行政区
                idCard.Canton = number.Substring(0, 6);

                //性别
                if ((number[16] == '0') || (number[16] % 2 == 0))
                {
                    idCard.Gander = 0;  //女
                }
                else
                {
                    idCard.Gander = 1;  //男
                }

                idCard.IsIDCard = true;
                return idCard;
            }
            #endregion
            else
            {
                throw new FormatException("无效的身份证号码位数：" + number.Length);
            }
        }

        public static bool TryParse(string number, out IDCard card)
        {
            IDCard idCard = null;
            bool isIdCard = true;
            try
            {
                Parse(number);
            }
            catch (Exception)
            {
                isIdCard = false;
            }
            card = idCard;
            return isIdCard;
        }
    }
}
