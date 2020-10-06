using System;
using System.Collections.Generic;
using Jil;

namespace CardMarket.Api.Entities
{
    public class StockResponse
    {
        [JilDirective(Name = "article")]
        public List<Article> Articles { get; set; }
    }

    public class Article
    {
        [JilDirective(Name = "idArticle")]
        public int Id { get; set; }

        [JilDirective(Name = "idProduct")]
        public int ProductId { get; set; }

        [JilDirective(Name = "language")]
        public ArticleLanguage Language { get; set; }

        [JilDirective(Name = "comments")]
        public string Comment { get; set; }

        [JilDirective(Name = "price")]
        public decimal Price { get; set; }

        [JilDirective(Name = "priceEUR")]
        public decimal PriceEuro { get; set; }

        [JilDirective(Name = "priceGBP")]
        public decimal PriceGBP { get; set; }

        [JilDirective(Name = "count")]
        public int Count { get; set; }

        [JilDirective(Name = "inShoppingCart")]
        public bool InShoppingCart { get; set; }

        [JilDirective(Name = "product")]
        public ArticleProduct Product { get; set; }

        [JilDirective(Name = "condition")]
        public string Condition { get; set; }

        [JilDirective(Name = "isFoil")]
        public bool IsFoil { get; set; }

        [JilDirective(Name = "isSigned")]
        public bool IsSigned { get; set; }

        [JilDirective(Name = "isAltered")]
        public bool IsAltered { get; set; }

        [JilDirective(Name = "isPlayset")]
        public bool IsPlayset { get; set; }

        [JilDirective(Name = "isFirstEd")]
        public bool IsFirstEdition { get; set; }

        [JilDirective(Name = "seller")]
        public User Seller { get; set; }

        [JilDirective(Name = "lastEdited")]
        public DateTime LastEdited { get; set; }
    }

    public class ArticleLanguage
    {
        [JilDirective(Name = "idLanguage")]
        public int Id { get; set; }

        [JilDirective(Name = "languageName")]
        public string Name { get; set; }
    }

    public class ArticleProduct
    {
        [JilDirective(Name = "enName")]
        public string Name { get; set; }

        [JilDirective(Name = "locName")]
        public string LocalizedName { get; set; }

        [JilDirective(Name = "image")]
        public string Image { get; set; }

        [JilDirective(Name = "expansion")]
        public string Expansion { get; set; }

        [JilDirective(Name = "nr")]
        public string Number { get; set; }

        [JilDirective(Name = "expIcon")]
        public int ExpansionIcon { get; set; }

        [JilDirective(Name = "rarity")]
        public string Rarity { get; set; }
    }
}
