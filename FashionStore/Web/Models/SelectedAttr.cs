using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Web.Models
{
    /// <summary>
    /// 记录用户已选筛选条件的属性
    /// </summary>
    public class SelectedAttr
    {
        public Dictionary<int, int> AttrDic { get; set; }//attrTitleID,attrContentID 键值对
        public int? BrandId { get; set; }//品牌Id
        public string BrandName { get; set; }

        public SelectedAttr()
        {
            BrandId = null;
            AttrDic = new Dictionary<int, int>();
        }

        private string DicToString(Dictionary<int,int> dic)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int key in dic.Keys)
            {
                sb.Append("-" + key.ToString() + ":" + dic[key].ToString());
            }
            if(sb.Length>0)
                sb.Remove(0, 1);
            return sb.ToString();
        }

        public override string ToString()
        {
            return DicToString(AttrDic);
        }

        public string ToStringAttrOnly()
        {
            StringBuilder sb = new StringBuilder();
            foreach (int key in AttrDic.Keys)
            {
                sb.Append("-" + key.ToString() + ":" + AttrDic[key].ToString());
            }
            if(sb.Length>0)
                sb.Remove(0, 1);
            return sb.ToString();
        }

        public string ToStringAdded(Domain.AttrContents content)
        {
            Dictionary<int,int> temDic = new Dictionary<int,int>(AttrDic);
            if (temDic.Keys.Contains<int>(content.AttrTitles.ID))
                temDic[content.AttrTitles.ID] = content.ID;
            else
                temDic.Add(content.AttrTitles.ID, content.ID);
            return DicToString(temDic);
        }

        public string ToStringRemoved(int titleId)
        {
            Dictionary<int, int> temDic = new Dictionary<int, int>(AttrDic);
            if (temDic.Keys.Contains<int>(titleId))
                temDic.Remove(titleId);
            return DicToString(temDic);
        }

        public void SetDic(string str)
        {
            foreach (string attr in str.Split('-'))
            {
                string[] tem = attr.Split(':');
                int title, content;
                if (int.TryParse(tem[0], out title) && int.TryParse(tem[1], out content))
                    AttrDic.Add(title, content);
            }
        }
    }
}