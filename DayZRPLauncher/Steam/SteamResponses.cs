namespace DayZRPLauncher.Steam {
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class WorkshopCollectionItem {
        [JsonPropertyName("publishedfileid")]
        public string? PublishedFileId { get; set; }

        [JsonPropertyName("sortorder")]
        public int? SortOrder { get; set; }

        [JsonPropertyName("filetype")]
        public int? FileType { get; set; }
    }

    public class CollectionDetail {
        [JsonPropertyName("children")]
        public List<WorkshopCollectionItem>? Children { get; set; }
    }

    public class Response {
        [JsonPropertyName("collectiondetails")]
        public List<CollectionDetail>? CollectionDetails { get; set; }
    }

    public class Root {
        [JsonPropertyName("response")]
        public Response? Response { get; set; }
    }
}
