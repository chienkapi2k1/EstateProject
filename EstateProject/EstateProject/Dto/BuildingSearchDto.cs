using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EstateProject.Dto
{
    [DataContract]
    public class BuildingSearchDto
    {
        [DataMember]
        public string name { get; set; }
      
        public string street { get; set; }

        public string ward { get; set; }

        public string district { get; set; }

        public int? numberofbasement { get; set; }

        public int? floorarea { get; set; }

        public string levels { get; set; }
        public string direction { get; set; }
        public string[] buildingTypes { get; set; }

        public int costRentFrom { get; set; }

        public int costRentTo { get; set; }

        public int areaRentFrom { get; set; }

        public int areaRentTo { get; set; }
        public int? UserId { get; set; }
    }
}