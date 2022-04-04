using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstateProject.Dto
{
    public class BuildingDto
    {
        public int id { get; set; }
    
        public string name { get; set; }

        public string street { get; set; }

        public string ward { get; set; }

        public string address { get; set; }

        public string district { get; set; }


        public string structure { get; set; }

        public int? numberofbasement { get; set; }

        public int? floorarea { get; set; }


        public string direction { get; set; }


        public string levels { get; set; }

        public int? rentprice { get; set; }


        public string rentpricedescription { get; set; }

        public string servicefee { get; set; }


        public string carfee { get; set; }


        public string motofee { get; set; }


        public string overtimefee { get; set; }


        public string waterfee { get; set; }


        public string electricityfee { get; set; }


        public string deposit { get; set; }


        public string payment { get; set; }


        public string renttime { get; set; }


        public string decorationtime { get; set; }

        public decimal? brokeragetee { get; set; }




        public string note { get; set; }


        public string linkofbuilding { get; set; }


        public string map { get; set; }



        public HttpPostedFileWrapper imageFile { get; set; }

        public string avatar { get; set; }
        public DateTime? createddate { get; set; }

        public DateTime? modifieddate { get; set; }


        public string createdby { get; set; }


        public string modifiedby { get; set; }
        public string[] buildingTypes { get; set; }
        public string rentareas { get; set; }


        public string[] buildingImages { get; set; }

        public int costRentFrom { get; set; }

        public int costRentTo { get; set; }

        public int areaRentFrom { get; set; }

        public int areaRentTo { get; set; }
        public int? UserId { get; set; }

        public int _page = 1;
        public int page
        {
            get
            {
                return _page;
            }
            set
            {
                _page = value;
            }
        }

        public int _limit = 5;
        public int limit
        {
            get
            {
                return _limit;
            }
            set
            {
                _limit = value;
            }
        }
        public int totalPage { get; set; }
        public int totalItems { get; set; }


    }
}