using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TNAShop.Domain {
    public class ImagePaths {
        public IList<string> Images { set; get; }
        public ImagePaths() {
            Images = new List<String>();
        }
    }
}