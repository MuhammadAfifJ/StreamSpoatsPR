using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamSpoatsPR.Client.Static
{
    public class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string BrandEndpoint = $"{Prefix}/brand";
        public static readonly string TypeEndpoint = $"{Prefix}/type";
        public static readonly string SportEndpoint = $"{Prefix}/sport";
        public static readonly string SerialEndpoint = $"{Prefix}/serial";
        public static readonly string ProductNameEndpoint = $"{Prefix}/prodname";
        public static readonly string ReviewEndpoint = $"{Prefix}/review";
        public static readonly string PurchaseEndpoint = $"{Prefix}/purchase";
        public static readonly string ProductEndpoint = $"{Prefix}/product";
        public static readonly string LikeEndpoint = $"{Prefix}/like";
        public static readonly string ProductByUserEndpoint = $"{Prefix}/product/GetProductByUserAsync";
    }
}
