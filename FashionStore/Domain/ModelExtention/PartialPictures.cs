using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public partial class Pictures
    {
        public string GetPicFullPath()
        {
            return "/content/pic/pdt/" + ProductID + "/" + PicName;
        }
    }
}
