using System;
using System.Collections.Generic;
using System.Text;

namespace MakeupList
{
    public partial class Product
    {
        public long Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public PriceSign? PriceSign { get; set; }
        public Currency? Currency { get; set; }
        public Uri ImageLink { get; set; }
        public Uri ProductLink { get; set; }
        public Uri WebsiteLink { get; set; }
        public string Description { get; set; }
        public double? Rating { get; set; }
        public string Category { get; set; }
        public ProductType ProductType { get; set; }
        public string[] TagList { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public Uri ProductApiUrl { get; set; }
        public string ApiFeaturedImage { get; set; }
        public ProductColor[] ProductColors { get; set; }
    }

    public partial class ProductColor
    {
        public string HexValue { get; set; }
        public string ColourName { get; set; }
    }

    //public enum string { BbCc, Concealer, Contour, Cream, Empty, Gel, Highlighter, LipGloss, LipStain, Lipstick, Liquid, Mineral, Palette, Pencil, Powder };

    public enum Currency { Cad, Gbp, Usd };

    public enum PriceSign { Empty, PriceSign };

    public enum ProductType { Blush, Bronzer, Eyebrow, Eyeliner, Eyeshadow, Foundation, LipLiner, Lipstick, Mascara, NailPolish };

}
