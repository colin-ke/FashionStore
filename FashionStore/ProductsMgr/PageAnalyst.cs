using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Util;

namespace ProductsMgr
{
    public class PageAnalyst
    {
        private string URL;
        private string HOMEPATH;

        private string dangdangId;
        private string myId;
        private string page = null;
        private List<string> bigImgs = null;
        private List<string> size = null;
        private Dictionary<string, string> colors = null;
        private string[] titles = null;
        private decimal price;

        private bool done = false;

        public Action<string> GettingPageData;
        public Action<string> Analysing;
        public Func<string,Products,int> Analysed;
        public Action<string> SavingPictures;
        public Action<string> Finish;

        public PageAnalyst(string url,string homePath)
        {
            URL = url;
            HOMEPATH = homePath;
        }

        public void Start(string ddId)
        {
            dangdangId = ddId;
            myId = "";
            GetPageData();
            Analysis();
            if (string.IsNullOrEmpty(myId))
                myId = dangdangId;
            SavePics(myId);

        }

        private void GetPageData()
        {
            GettingPageData(dangdangId);
            string theUrl = URL + dangdangId;
            WebRequest request = WebRequest.Create(theUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("gbk"));
            page = reader.ReadToEnd();

            stream.Close();
            response.Close();
        }

        private void Analysis()
        {
            Analysing(dangdangId);
            if (null == page)
                return;

            bigImgs = new List<string>();
            size = new List<string>();
            colors = new Dictionary<string, string>();
            titles = new string[2];

            Lexer lexer = new Lexer(page);
            Parser parser = new Parser(lexer);

            TagNameFilter linkFilter = new TagNameFilter("a");
            AndFilter priceFilter = new AndFilter(new TagNameFilter("span"), new HasAttributeFilter("id", "salePriceTag"));
            TagNameFilter titleFilter = new TagNameFilter("h1");
            TagNameFilter imgFilter = new TagNameFilter("img");
            OrFilter orFilter = new OrFilter(new OrFilter(imgFilter, new OrFilter(titleFilter, linkFilter)), priceFilter);

            NodeList filteredNodes = parser.Parse(orFilter);//这个破方法效率好低！！！

            Regex bigImgRegx = new Regex(".*x.jpg");
            Regex clrRegx = new Regex("cl_.*");
            Regex szRegx = new Regex("sl_.*");
            foreach (INode node in filteredNodes.ToNodeArray())
            {
                ITag tag = node as ITag;
                string tagName = tag.TagName;
                switch (tagName)
                {
                    case "IMG":
                        if (bigImgRegx.IsMatch(tag.GetAttribute("src")))
                        {
                            string str = tag.GetAttribute("src");
                            str = str.Replace("x.jpg", "h.jpg");
                            bigImgs.Add(str);
                        }
                        break;
                    case "H1":
                        titles[0] = tag.FirstChild.GetText();
                        titles[1] = " ";
                        for (int i = 0; i < tag.Children.Count; i++)
                        {
                            ITag t = tag.Children[i] as ITag;
                            if (null != t)
                            {
                                if (t.GetAttribute("class") == "subtitle")
                                    titles[1] = t.FirstChild.GetText();
                            }
                        }
                        break;
                    case "SPAN":
                        string strPrice = tag.FirstChild.GetText();
                        int start = 0;
                        for (int i = 0; i < strPrice.Length; i++)
                        {
                            if (Char.IsDigit(strPrice[i]))
                            {
                                start = i;
                                break;
                            }
                        }
                        strPrice = strPrice.Substring(start, strPrice.Length - start);
                        decimal.TryParse(strPrice, out price);
                        break;
                    case "A":
                        string id = tag.GetAttribute("id");
                        if (null == id)
                            break;
                        if (clrRegx.IsMatch(id.ToLower()))
                        {
                            string colorName = tag.GetAttribute("title");
                            string picPath = ((ITag)tag.FirstChild).GetAttribute("src");
                            colors.Add(colorName, picPath);
                        }
                        else if (szRegx.IsMatch(tag.GetAttribute("id").ToLower()))
                        {
                            size.Add(tag.GetAttribute("title"));
                        }
                        break;
                }
            }

            List<Pictures> picList = new List<Pictures>();
            List<Sizes> sizeList = new List<Sizes>();
            List<Colors> clrList = new List<Colors>();
            
            picList.AddRange(colors.Values.Select<string, Pictures>(url => new Pictures() { PicName = "clr_" + url.Split('/').Last(), IsShow = false }).ToArray());
            sizeList.AddRange(size.Select<string,Sizes>(str=>new Sizes(){Name=str}));
            clrList.AddRange(colors.Keys.Select<string, Colors>(str => new Colors() { Name = str }));
            for (int i = 0; i < picList.Count; i++)
                clrList[i].Pictures = picList[i];
            picList.AddRange(bigImgs.Select<string, Pictures>(url => new Pictures() { PicName = url.Split('/').Last(), IsShow = true }).ToArray());


            Products pdt = new Products();
            pdt.Title = titles[0];
            pdt.SubTitle = titles[1];
            pdt.Price = price;
            pdt.BrandId = 1;
            pdt.Date = DateTime.Now;
            pdt.Count = 100;
            pdt.Pictures = picList;
            pdt.Sizes = sizeList;
            pdt.Colors = clrList;
            

            int insertedId = Analysed(dangdangId,pdt);
            if (insertedId <= 0)
                myId = dangdangId;
            else
                myId = insertedId.ToString();
            //downloadAndSaveFile("c:\\test.jpg", bigImgs[0]);
            //SavePics("410050160");
        }

        private void SavePics(string id)
        {
            SavingPictures(dangdangId);
            string homePath = HOMEPATH;
            string dirPath = homePath + id + "\\";
            if (!Directory.Exists(homePath + id))
                Directory.CreateDirectory(homePath + id);
            foreach (string url in bigImgs)
            {
                string[] tem = url.Split('/');
                string name = tem[tem.Length - 1];
                Download(dirPath + name, url);
            }
            foreach (string url in colors.Values)
            {
                string[] tem = url.Split('/');
                string name = tem[tem.Length - 1];
                Download(dirPath + "clr_" + name, url);
            }
            Finish(dangdangId);
        }

        private void Download(string savingPath, string url)
        {
            WebRequest request = WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            FileStream fStream;
            if (!File.Exists(savingPath))
                fStream = File.Create(savingPath);
            else
                fStream = File.OpenWrite(savingPath);
            fStream.Flush();

            BinaryReader sReader = new BinaryReader(stream);
            BinaryWriter sWriter = new BinaryWriter(fStream);

            byte[] buffer = new byte[1024];
            int len;
            while (true)
            {
                buffer = new byte[1024];
                len = sReader.Read(buffer, 0, 1024);
                if (len <= 0)
                    break;
                sWriter.Write(buffer, 0, len);
            }
            sReader.Close();
            sWriter.Close();
            stream.Close();
            fStream.Close();
            response.Close();
        }

        

    }
}
