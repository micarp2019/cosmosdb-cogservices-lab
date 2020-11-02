using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TwitterPhotos.Models
{

    public class Photo
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "photoId")]
        public string photoId { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public string userId { get; set; }

        [JsonProperty(PropertyName = "caption")]
        public string caption { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Tag { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

    }
}
