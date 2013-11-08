using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LordDesign.Utilities;
using System.Globalization;
using Newtonsoft.Json;

namespace ShelfSort
{    
    [Serializable]
    public class ShelfItem
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "isbn")]
        public string Isbn { get; set; }

        [JsonProperty(PropertyName = "isbn13")]
        public string Isbn13 { get; set; }

        [JsonProperty(PropertyName = "shelf")]
        public string Shelf { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public string UpdatedAt { get; set; }
    }
}
