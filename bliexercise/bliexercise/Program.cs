using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace bliexercise
{
    class Program
    {
        private static bool imageExist;
        public static BitmapSource _bitmapImageLoEng;

        static void Main(string[] args)
        {
            string rawPath = @"D:\Doc\blirawtobmp\1_20220908112153.raw";
            //_bitmapImageLoEng = RawToBitmapImage(rawPath);
            _bitmapImageLoEng = NewRawTBitmap(rawPath);
            Console.ReadKey();
        }
        public void Content()
        {
            //HTTP获取网页内容
            //GetWebContent();
            //string url = "https://m.xbiquge.so/book/9109/6516857.html";
            //string data = Helper.getDataFromUrl(url);
            //string content = Helper.GetMainContent(data);
            //List<string> tag = new List<string>();
            //tag = Helper.GetTags(data , "td");
            //Console.WriteLine(content);
            //Console.WriteLine(tag);
            //继承的使用
            //Rect rect = new Rect(4,5);
            //rect.GetCost();
            //Console.WriteLine("面积是：{0}", rect.GetArea());
            //Console.WriteLine("成本是：{0}", rect.GetCost());
        }
        public static BitmapSource RawToBitmapImage(string path)
        {
            FileInfo fi = new FileInfo(path);
            imageExist = fi.Exists;


            int height = 2048;
            int width = 2448;

            byte[] imageData = File.ReadAllBytes(path);

            Bitmap bmp = null;

            bmp = new Bitmap(height, width, PixelFormat.Format24bppRgb);
            for (int a = 0; a < width; a++)
            {
                for (int b = 0; b < height; b++)
                {
                    int grayScale = imageData[b * width + a];
                    Point pt = new Point(a, b);
                    bmp.SetPixel((int)pt.X, (int)pt.Y, System.Drawing.Color.FromArgb(grayScale, grayScale, grayScale));
                }
            }
            BitmapImage bi = new BitmapImage();
            bi = BitmapToBitmapImage(bmp);
            return bi;
        }
        public static BitmapSource NewRawTBitmap(string path)
        {
            var ImageData = File.ReadAllBytes(path);

            int imageWidth = 2448;
            int imageHeight = 2048;

            //数组转换为Intptr
            IntPtr pData = Marshal.AllocHGlobal(imageWidth * imageHeight);
            Marshal.Copy(ImageData, 0, pData, imageWidth * imageHeight);

            //创建灰度位图
            Bitmap bmp = new Bitmap(imageWidth, imageHeight, imageWidth, PixelFormat.Format8bppIndexed, pData);

            //修改位图的调色板
            ColorPalette palette = bmp.Palette;
            for (int i = 0; i < 256; i++)
            {
                palette.Entries[i] = Color.FromArgb(i, i, i);
            }
            bmp.Palette = palette;
            BitmapImage bi = new BitmapImage();
            bi = BitmapToBitmapImage(bmp);
            return bi;
        }
        public static BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png); // 坑点：格式选Bmp时，不带透明度
                stream.Position = 0;
                BitmapImage result = new BitmapImage();
                result.BeginInit();
                // According to MSDN, "The default OnDemand cache option retains access to the stream until the image is needed."
                // Force the bitmap to load right now so we can dispose the stream.
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                return result;
            }
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
