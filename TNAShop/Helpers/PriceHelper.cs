using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TNAShop.Helpers {
    public static class PriceHelper {
        public static string NormalizePrice(string price) {
            string res = "";
            int mod = price.Length%3;
            for (int i = 0; i < price.Length; i++) {
                    res += price[i].ToString();
                if ((i+1) % 3  == mod&&i!=price.Length-1) {
                    res += ".";
                }
            }
            return res;
        }
    }
}