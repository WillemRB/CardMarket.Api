using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CardMarket.Api.Entities
{
    public class StockResponse
    {
        [JsonPropertyName("article")]
        public List<Article> Articles { get; set; }
    }

    public class Article
    {
        [JsonPropertyName("idArticle")]
        public int Id { get; set; }

        [JsonPropertyName("idProduct")]
        public int ProductId { get; set; }

        [JsonPropertyName("language")]
        public ArticleLanguage Language { get; set; }

        [JsonPropertyName("comments")]
        public string Comment { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("priceEUR")]
        public decimal PriceEuro { get; set; }

        [JsonPropertyName("priceGBP")]
        public decimal PriceGBP { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("inShoppingCart")]
        public bool InShoppingCart { get; set; }

        [JsonPropertyName("product")]
        public ArticleProduct Product { get; set; }

        [JsonPropertyName("condition")]
        public string Condition { get; set; }

        [JsonPropertyName("isFoil")]
        public bool IsFoil { get; set; }

        [JsonPropertyName("isSigned")]
        public bool IsSigned { get; set; }

        [JsonPropertyName("isAltered")]
        public bool IsAltered { get; set; }

        [JsonPropertyName("isPlayset")]
        public bool IsPlayset { get; set; }

        [JsonPropertyName("isFirstEd")]
        public bool IsFirstEdition { get; set; }

        [JsonPropertyName("seller")]
        public User Seller { get; set; }

        [JsonPropertyName("lastEdited")]
        public DateTime LastEdited { get; set; }
    }

    public class ArticleLanguage
    {
        [JsonPropertyName("idLanguage")]
        public int Id { get; set; }

        [JsonPropertyName("languageName")]
        public string Name { get; set; }
    }

    public class ArticleProduct
    {
        [JsonPropertyName("enName")]
        public string Name { get; set; }

        [JsonPropertyName("locName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("expansion")]
        public string Expansion { get; set; }

        [JsonPropertyName("nr")]
        public string Number { get; set; }

        [JsonPropertyName("expIcon")]
        public int ExpansionIcon { get; set; }

        [JsonPropertyName("rarity")]
        public string Rarity { get; set; }
    }
}
