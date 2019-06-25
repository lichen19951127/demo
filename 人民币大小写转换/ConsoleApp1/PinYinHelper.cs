using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    using Microsoft.International.Converters.PinYinConverter;
    using NPinyin;
    //NPinyin.Core
    public static class PinYinHelper
    {
        /// <summary>
        /// lou  2019年5月27日10:17:48 Encoding编码
        /// </summary>
        private static readonly Encoding Gb2312 = Encoding.GetEncoding("GB2312");

        /// <summary>
        ///lou 2019年5月27日10:25:00 汉字转全拼
        /// </summary>
        /// <param name="strChinese">汉字</param>
        /// <returns></returns>
        public static string ConvertToAllSpell(string strChinese, IDictionary<char, string> pinyinDic = null)
        {
            try
            {
                if (strChinese.Length != 0)
                {
                    StringBuilder fullSpell = new StringBuilder();
                    for (int i = 0; i < strChinese.Length; i++)
                    {
                        var chr = strChinese[i];
                        string pinyin = string.Empty;
                        if (pinyin.Length == 0)
                        {
                            pinyin = GetSpell(chr);
                        }
                        fullSpell.Append(pinyin);
                    }

                    return fullSpell.ToString().ToLower();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("全拼转化出错！" + e.Message);
            }
            return string.Empty;
        }

        /// <summary>
        /// lou 2019年5月27日10:19:57 汉字转首字母
        /// </summary>
        /// <param name="strChinese">汉字</param>
        /// <returns></returns>
        public static string GetFirstSpell(string strChinese)
        {
            try
            {
                if (strChinese.Length != 0)
                {
                    StringBuilder fullSpell = new StringBuilder();
                    for (int i = 0; i < strChinese.Length; i++)
                    {
                        var chr = strChinese[i];
                        fullSpell.Append(GetSpell(chr)[0]);
                    }
                    return fullSpell.ToString().ToUpper();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("首字母转化出错！" + e.Message);
            }
            return string.Empty;
        }

        /// <summary>
        /// lou 2019年5月27日10:20:22 获取字符拼音
        /// </summary>
        /// <param name="chr">字符</param>
        /// <returns></returns>
        private static string GetSpell(char chr)
        {
            var coverchr = Pinyin.GetPinyin(chr);
            bool isChineses = ChineseChar.IsValidChar(coverchr[0]);
            if (isChineses)
            {
                ChineseChar chineseChar = new ChineseChar(coverchr[0]);
                foreach (string value in chineseChar.Pinyins)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        return value.Remove(value.Length - 1, 1);
                    }
                }
            }
            return coverchr;
        }
    }
}
