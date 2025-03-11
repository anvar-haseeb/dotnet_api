using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace IAAI_CAR.Models
{
    [BsonIgnoreExtraElements]
    public class TrnCarAuctionDetails
    { 
        // This attribute indicates that this property is used as the document's _id.
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        [BsonIgnoreIfDefault]
        public string? Id { get; set; }

        [BsonRequired]
        public string Make { get; set; }

        [BsonRequired]
        public string Model { get; set; }
        [BsonIgnoreIfNull]
        public int Year { get; set; } // Optional (defaults to 0 if not provided)
        [BsonIgnoreIfNull]
        public int Mileage { get; set; } // Optional (defaults to 0 if not provided)
        [BsonIgnoreIfNull]
        public string? Location { get; set; } // Optional (nullable)

        [BsonIgnoreIfNull]
        public DateTime? Auction_Date { get; set; } // Optional (nullable)

        [BsonElement("imagePath")]
        [BsonIgnoreIfNull]
        public string? ImagePath { get; set; } // Optional (nullable)

        [BsonElement("image")]
        [BsonIgnoreIfNull]
        public byte[]? Image { get; set; } // Optional (nullable)

        [BsonElement("imageType")]
        [BsonIgnoreIfNull]
        public string? ImageType { get; set; } // Optional (nullable)

        [BsonElement("imageNames")]
        [BsonIgnoreIfNull]
        public CarImageNames? ImageNames { get; set; } // Optional (nullable)
        public override string ToString()
        {
            return $"Id: {Id ?? "N/A"}, Make: {Make}, Model: {Model}, Year: {Year}, Mileage: {Mileage}, " +
                   $"Location: {Location ?? "N/A"}, Auction Date: {(Auction_Date.HasValue ? Auction_Date.Value.ToString("yyyy-MM-dd") : "N/A")}, " +
                   $"ImagePath: {ImagePath ?? "N/A"}, ImageType: {ImageType ?? "N/A"}";
        }

    }


    public class CarImageNames
    {
        [BsonIgnoreIfNull]
        public string? FrontImage { get; set; } // Optional

        [BsonIgnoreIfNull]
        public string? RearImage { get; set; } // Optional

        [BsonIgnoreIfNull]
        public string? SideImage { get; set; } // Optional

        [BsonIgnoreIfNull]
        public string? InteriorImage { get; set; } // Optional
    }
  
}
