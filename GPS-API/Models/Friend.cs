using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using GPS_API.Models;


namespace GPS_API.Models
{
    public class Friend
    {
        [BsonId()]
        public ObjectId _id { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("locationx")]
        public int locationx { get; set; }

        [BsonElement("locationy")]
        public int locationy { get; set; }

        public List<Friend> closerFriends { get; set; }
    }

   
}