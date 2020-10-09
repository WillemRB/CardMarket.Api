using System.Collections.Generic;
using System.Xml.Serialization;

namespace CardMarket.Api.Requests
{
    [XmlRoot("request")]
    public class DeleteStockRequest
    {
        [XmlArray("article")]
        public List<DeleteStockArticle> Articles { get; set; } = new List<DeleteStockArticle>();
    }

    public class DeleteStockArticle
    {
        [XmlElement("idArticle")]
        public string ArticleId { get; set; }

        [XmlElement("count")]
        public int Count { get; set; }
    }
}
