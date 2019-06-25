using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace TrieTreeDemo
{
    public class TrieFactory
    {
        
        static TrieFactory()
        {
            
        }
        public static TrieTree Create(List<string> list)
        {
            TrieTree tt = TrieTree.GetInstance();
            foreach (string wd in list)
            {
                tt.AddWord(wd);
            }
            return tt;
        }
    }
}
