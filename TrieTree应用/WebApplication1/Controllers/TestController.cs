using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
       public class Node
        {
            public Dictionary<String, Node> nexts; // 子节点
            public int end;
            public Node()
            {
                this.nexts = new Dictionary<String, Node>();
                this.end = 0;
            }
        }
        public TestController()
        {
            insert("北京");
            insert("北京市");
            insert("北京市政府");
            insert("北京市委");
            insert("北京市人力资源局");
            insert("北京市朝阳区");
            insert("北京市昌平区");
            insert("北京市昌平区回龙观镇");
            insert("北京一新");
            insert("北京科技");
            insert("北方");
            insert("北方科技");
        }
        public IActionResult Index()
        {
            return View();
        }
        Node root = new Node();

        public void insert(String word)
        {
            if (word == null)
                return;
            Node node = root;
            for (int i = 0; i < word.Length; i++)
            {
                String str = "" + word[i];
                Node sValue = null;
                if (!node.nexts.TryGetValue(str, out sValue))
                    node.nexts.Add(str, new Node());
                node = node.nexts[str];
            }
            node.end = 1;
        }

        public bool startWith(String preWord)
        {
            Node node = root;
            for (int i = 0; i < preWord.Length; i++)
            {
                String str = "" + preWord[i];
                Node sValue = null;
                if (!node.nexts.TryGetValue(str, out sValue))
                    return false;
                node = node.nexts[str];
            }
            return true;
        }
        List<String> list = new List<String>();

        public List<String> getData(String preword)
        {
            list.Clear();
            if (!startWith(preword))
                return null;
            else
            {
                StringBuilder str = new StringBuilder("");
                str.Append(preword);
                Node node = root;
                for (int i = 0; i < preword.Length; i++)
                    node = node.nexts["" + preword[i]];
                dfs(node, str);
            }
            return list;
        }

        private void dfs(Node root, StringBuilder str)
        {
            if (root.end == 1)
            {
                list.Add(str.ToString());
                if (root.nexts.Count == 0)
                    return;
            }
            Node node = root;
            foreach (String item in node.nexts.Keys)
            {
                str.Append(item);
                dfs(node.nexts[item],str);
                //int length = str.Length;
                //int start = length - 2;
                //int end = length - 1;
                str.Remove(str.Length - 1,1);
            }
        }
    }
}