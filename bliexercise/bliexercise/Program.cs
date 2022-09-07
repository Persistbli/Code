using Grpc.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace bliexercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //HTTP获取网页内容
            //GetWebContent();
            string url = "https://m.xbiquge.so/book/9109/6516857.html";
            string data = Helper.getDataFromUrl(url);
            string content = Helper.GetMainContent(data);
            List<string> tag = new List<string>();
            tag = Helper.GetTags(data , "td");
            Console.WriteLine(content);
            //Console.WriteLine(tag);
            //继承的使用
            //Rect rect = new Rect(4,5);
            //rect.GetCost();
            //Console.WriteLine("面积是：{0}", rect.GetArea());
            //Console.WriteLine("成本是：{0}", rect.GetCost());
            Console.ReadKey();
        }

        class Shape
        {
            public int weight { get; set; }
            public int height { get; set; }
            public Shape(int h,int w)
            {
                weight = w;
                height = h;
            }
            public void SetWeight(int w)
            {
                weight = w;
            }
            public void SetHeight(int h)
            {
                height = h;
            }

            public int GetArea()
            {
                Console.WriteLine("面积是：{0}", height*weight);
                return weight * height;
            }
        }
        interface CountCost
        {
            int GetCost();
        }

        class Rect : Shape, CountCost
        {
            public Rect(int w, int h): base(w , h)
            {
            }
            public int GetCost()
            {
                Console.WriteLine("成本为：{0}", GetArea()*50);
                return GetArea() * 50;
            }
        }


        //interface test
        public void InterfaceTest()
        {
            try
            {
                //Channel channel = new Channel($"{SCUManager.SCUHost}:{SCUManager.GrpcPort}", ChannelCredentials.Insecure);
                //var client = new RemoteControl.RemoteControlClient(channel);
                //return client;
                int[] nums = { 1, 2, 3, 4 };
                int[] b = RunningSum(nums);

                string Title = "《活着》";
                string Author = "余华";
                int year = 2001;
                InterfaceTraing ex = new InterfaceTraing(Title, Author, year);
                Console.WriteLine(ex.ColumnValues[0]);
                Console.WriteLine(ex.ColumnValues[1]);
                Console.WriteLine(ex.ColumnValues[2]);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //动态求和
        //输入：nums = [1,1,1,1,1]
        //输出：[1,2,3,4,5]
        //解释：动态和计算过程为[1, 1 + 1, 1 + 1 + 1, 1 + 1 + 1 + 1, 1 + 1 + 1 + 1 + 1] 。
        public static int[] RunningSum(int[] nums)
        {
            int[] a = new int[4];
            for (int i = 0; i < nums.Length; i++)
            {
                a[i] = nums.Take(i+1).ToArray().Sum();
            }
            return a;
        }
        //回文数
        public static bool IsPalidrome(int x)
        {
            string s = x.ToString();
            int i = 0;

            if (s[i] == s[s.Length - i])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void GetWebContent()
        {
            try
            {
                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                Byte[] webData = client.DownloadData("https://m.xbiquge.so/book/9109/6516857.html");
                string pageHtml = Encoding.Default.GetString(webData);
                Console.WriteLine(pageHtml);
                using (StreamWriter sw = new StreamWriter("d:\\Doc\\ouput.html"))//将获取的内容写入文本
                {
                    sw.Write(pageHtml);
                }
                Console.ReadKey();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
