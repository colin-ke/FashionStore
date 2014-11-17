using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Domain;
using Domain.Abstract;
using Domain.Concrete;

namespace Web.Controllers
{
    public class ListController : Controller
    {
        //
        // GET: /List/

        private Domain.Abstract.IFiltCatagories filtCata;
        private Domain.Abstract.IAttrs attrs;
        private const int pageSize = 16;
        //private Domain.Abstract.INavCatagories navCata;

        public ListController(IFiltCatagories filtCata,INavCatagories nav,IAttrs attrs)
        {
            this.filtCata = filtCata;
            this.attrs = attrs;
            //this.navCata = nav;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FiltList(int catagories, int page =1)
        {
            
            Domain.FiltCatagories cata = filtCata.Catagories.Where<Domain.FiltCatagories>(x => x.ID == catagories).Single<Domain.FiltCatagories>();
            if (cata == null)
                Response.RedirectToRoute("Default");
            if (cata.ParentID == null)
            {
                foreach (FiltCatagories sub in cata.SubFiltCatas)
                {
                    cata.Products = cata.Products.Concat<Products>(sub.Products).ToList<Products>();
                }
            }
            
            return View(cata);
        }

        public PartialViewResult PdtsList(FiltCatagories cata, int page = 1)
        {
            SelectedAttr selectedAttr = new SelectedAttr();
            if (Request.QueryString["attr"] != null)
                selectedAttr.SetDic(Request.QueryString["attr"]);
            if (Request.QueryString["brand"] != null)
            {
                int tem;
                if (int.TryParse(Request.QueryString["brand"], out tem))
                {
                    selectedAttr.BrandId = tem;
                    cata.Products = cata.Products.Where<Products>(pdt => pdt.BrandId == tem).ToList<Products>();
                    Brand selectedBrand = cata.Products.Select<Products, Brand>(pdt => pdt.Brand).Where<Brand>(brd => brd.ID == tem).FirstOrDefault();
                    if (null != selectedBrand)
                        selectedAttr.BrandName = selectedBrand.Name;
                }
            }
            
            foreach (int id in selectedAttr.AttrDic.Values)
            {
                cata.Products = cata.Products.Where<Products>(pdt => pdt.AttrContents.Any<AttrContents>(x => x.ID == id)).ToList<Products>();
            }

            PagingInfo pagingInfo = new PagingInfo()
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = cata.Products.Count()
            };
            cata.Products = cata.Products.Skip((page - 1) * pageSize).Take(pageSize).ToList<Products>();

            ViewBag.pagingInfo = pagingInfo;
            ViewBag.attrs = selectedAttr;
            ViewBag.attrRepository = attrs;

            SortingTypes? sType = null;
            if (Request.QueryString["sort"] != null)
            {
                switch (Request.QueryString["sort"])
                {
                    case "sc":
                        sType = SortingTypes.SaleCount;
                        cata.Products = cata.Products.OrderByDescending(pdt => pdt.SaleCount).ToList();
                        break;
                    case "pc":
                        sType = SortingTypes.Price;
                        cata.Products = cata.Products.OrderBy(pdt => pdt.Price).ToList();
                        break;
                    case "date":
                        sType = SortingTypes.Date;
                        cata.Products = cata.Products.OrderByDescending(pdt => pdt.Date).ToList();
                        break;
                }
            }
            ViewBag.sortType = sType;

            return PartialView(cata);
        }

        public ActionResult SearchSubmit(FormCollection collection)
        {
            int cataId = Convert.ToInt32(collection["cataId"]);
            string keyWord = collection["keyWord"];
            return Redirect(string.Format("/list/search/{0}?cata={1}", keyWord, cataId));
        }


        public ActionResult Search(string keyWord)
        {
            int cataId = Convert.ToInt32(Request.QueryString["cata"]);
            //string keyWord = Request.QueryString["key"];
            List<SearchedCatagories> searchedCata = new List<SearchedCatagories>();

            foreach (var cata in filtCata.Catagories.Where<FiltCatagories>(item=>item.ParentID == null))
            {
                SearchedCatagories tem = new SearchedCatagories(cata, keyWord);
                if (tem.Count > 0)
                    searchedCata.Add(tem);
            }

            ViewBag.cataId = cataId;
            ViewBag.key = keyWord;
            return View("SearchResult", searchedCata);
        }

    }
}
