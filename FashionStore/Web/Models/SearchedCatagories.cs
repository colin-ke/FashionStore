using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Web.Models
{
    public class SearchedCatagories
    {
        public FiltCatagories Catagories { get; set; }
        public string KeyWord { get; set; }
        public bool Selected { get; set; }

        private List<SearchedCatagories> _subCatagories;
        public List<SearchedCatagories> SubCatagories
        {
            get
            {
                if (null == _subCatagories)
                {
                    _subCatagories = new List<SearchedCatagories>();
                    foreach (var sub in Catagories.SubFiltCatas)
                    {
                        SearchedCatagories newSub = new SearchedCatagories(sub, KeyWord);
                        if (newSub.Count > 0)
                            _subCatagories.Add(newSub);
                    }
                }
                return _subCatagories;
            }
        }

        //该类别搜索到的商品列表（）
        private List<Products> _products;
        public List<Products> Products
        {
            get
            {
                if (_products == null)
                {
                    _products = Catagories.Products.Where<Products>(pdt=>pdt.Title.Contains(KeyWord)).ToList<Products>();
                    foreach (var sub in SubCatagories)
                    {
                        _products.AddRange(sub.Products);
                    }
                    //_products.AddRange(_subCatagories.Select<SearchedCatagories, IEnumerable<Products>>(cata => cata.Products.Where<Products>(pdt=>pdt.Title.Contains(KeyWord))));
                }
                return _products;
            }
            private set{}
        }

        //该类别搜索到的商品总数（包括子类别）
        private int _count = -1;
        public int Count
        {
            get
            {
                if (-1 == _count)
                {
                    _count = Products.Count;
                    //res += SubCatagories.Select<SearchedCatagories, int>(cata => cata.Count).Sum();
                }
                return _count;
            }
            private set { }
        }
        
        //构造函数
        public SearchedCatagories(FiltCatagories cata,string keyWord)
        {
            Catagories = cata;
            KeyWord = keyWord;
            Selected = false;
        }

        public SearchedCatagories(FiltCatagories cata, string keyWord,bool selected)
        {
            Catagories = cata;
            KeyWord = keyWord;
            Selected = selected;
        }

        public bool IsBelong(int cataId)
        {
            bool res = false;
            res = res || Catagories.ID == cataId || SubCatagories.Any<SearchedCatagories>(cata => cata.Catagories.ID == cataId);
            return res;
        }

        //public int ID { get; set; }
        //public string Name { get; set; }
        //private int _count = 0;
        //private List<SearchedCatagories> _subCatagories;

        //public List<SearchedCatagories> SubCatagories
        //{
        //    get { if (null == _subCatagories) _subCatagories = new List<SearchedCatagories>(); return _subCatagories; }
        //    set { _subCatagories = value; }
        //}

        //public int Count
        //{
        //    get
        //    {
        //        int res = _count;
        //        if (SubCatagories != null && SubCatagories.Count != 0)
        //            foreach (var cata in SubCatagories)
        //                res += cata.Count;
        //        return res;
        //    }
        //    set
        //    {
        //        _count = value;
        //    }
        //}
    }
}