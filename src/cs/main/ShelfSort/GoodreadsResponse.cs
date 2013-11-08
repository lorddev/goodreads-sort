using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace ShelfSort
{
    using System.Collections.Generic;

    [Serializable]
    public class GoodreadsResponse
    {
        //[XmlElement(ElementName = "user_status")]
        //public UserStatus UserStatus { get; set; }

        [XmlElement(ElementName = "book")]
        public Book Book { get; set; }

        [XmlElement(ElementName = "review")]
        public Review Review { get; set; }
    }

    [Serializable]
    public class Review
    {
        [XmlElement("book")]
        public Book Book { get; set; }

        [XmlArray(ElementName = "user_statuses"), XmlArrayItem("user_status")]
        public List<UserStatus> UserStatuses { get; set; }

    }

    [Serializable]
    public class UserStatus
    {
        private float? _percent;

        //[XmlElement(ElementName = "header")]
        //public string Header { get; set; }

        //[XmlElement(ElementName = "book")]
        //public Book Book { get; set; }

        [XmlElement(ElementName = "percent")]
        public string Percent { get; set; }

        //public float GetPercentRead()
        //{
        //    // Prevent unnecessary duplicate regex parsing.
        //    if (_percent.HasValue)
        //    {
        //        return _percent.Value;
        //    }

        //    var reg = new Regex(@"(.\d)%");
        //    var match = reg.Match(Header);
        //    string value = match.Captures[0].Value;
        //    value = value.Replace(CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");

        //    float bigNumber = float.Parse(value);
        //    _percent = bigNumber / 100;
        //    return _percent.Value;
        //}
    }

    public class Book
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

    }
}
