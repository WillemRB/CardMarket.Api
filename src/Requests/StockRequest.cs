using System.Collections.Generic;
using System.Xml.Serialization;

namespace CardMarket.Api.Requests
{
    [XmlRoot("request")]
    public class StockRequest
    {
        /// <summary>
        /// Product ID the article is derived from (for POST)
        /// </summary>
        [XmlElement("idProduct")]
        public int ProductId { get; set; }

        /// <summary>
        /// Article ID (for PUT and DELETE)
        /// </summary>
        [XmlElement("idArticle")]
        public int ArticleId { get; set; }

        /// <summary>
        /// Quantity (for POST), quantity of updated, resp. deleted articles (for PUT and DELETE)
        /// </summary>
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("idLanguage")]
        public int LanguageId { get; set; }

        /// <summary>
        /// User comments
        /// </summary>
        [XmlElement("comments")]
        public string Comments { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Condition, if applicable (optional)
        /// </summary>
        [XmlElement("condition")]
        public string Condition { get; set; }

        [XmlElement("isFoil")]
        public bool? IsFoil { get; set; } = null;

        [XmlElement("isSigned")]
        public bool? IsSigned { get; set; } = null;

        [XmlElement("isAltered")]
        public bool? IsAltered { get; set; } = null;

        [XmlElement("isPlayset")]
        public bool? IsPlayset { get; set; } = null;

        [XmlElement("isFirstEd")]
        public bool? IsFirstEdition { get; set; } = null;

        [XmlArray("article")]
        public List<StockRequestArticle> Articles { get; set; } = new List<StockRequestArticle>();
    }

    public class StockRequestArticle
    {
        [XmlElement("idArticle")]
        public string ArticleId { get; set; }

        [XmlElement("count")]
        public int Count { get; set; }
    }
}