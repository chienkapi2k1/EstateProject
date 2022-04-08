using EstateProject.Dto;
using EstateProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstateProject.Common
{
    public static class BuildingConverter
    {

        public static building converterToEntity(BuildingDto dto)
        {
            building building = new building();
            building.id = dto.id;
            building.name = dto.name;
            building.street = dto.street;
            building.ward = dto.ward;
            building.district = dto.district;
            building.structure = dto.structure;
            building.numberofbasement = dto.numberofbasement;
            building.floorarea = dto.floorarea;
            building.direction = dto.direction;
            building.levels = dto.levels;
            building.rentprice = dto.rentprice;
            building.rentpricedescription = dto.rentpricedescription;
            building.servicefee = dto.servicefee;
            building.carfee = dto.carfee;
            building.motofee = dto.motofee;
            building.waterfee = dto.waterfee;
            building.electricityfee = dto.electricityfee;
            building.deposit = dto.deposit;
            building.payment = dto.payment;
            building.renttime = dto.renttime;
            building.decorationtime = dto.decorationtime;
            building.brokeragetee = dto.brokeragetee;
            building.linkofbuilding = dto.linkofbuilding;
            building.note = dto.note;
            building.map = dto.map;
            building.user_id = dto.UserId;
            building.avatar = dto.avatar;
            return building;
        }

        public static BuildingDto converterToDto(building entity)
        {
            BuildingDto building = new BuildingDto();
            building.id = entity.id;
            building.UserId = entity.user_id;
            building.address = entity.name  + ", " + entity.ward + ", " + entity.district;
            building.name = entity.name;
            building.street = entity.street;
            building.ward = entity.ward;
            building.district = entity.district;
            building.structure = entity.structure;
            building.numberofbasement = entity.numberofbasement;
            building.floorarea = entity.floorarea;
            building.direction = entity.direction;
            building.levels = entity.levels;
            building.rentprice = entity.rentprice;
            building.rentpricedescription = entity.rentpricedescription;
            building.servicefee = entity.servicefee;
            building.carfee = entity.carfee;
            building.motofee = entity.motofee;
            building.waterfee = entity.waterfee;
            building.electricityfee = entity.electricityfee;
            building.deposit = entity.deposit;
            building.payment = entity.payment;
            building.renttime = entity.renttime;
            building.decorationtime = entity.decorationtime;
            building.brokeragetee = entity.brokeragetee;
            building.linkofbuilding = entity.linkofbuilding;
            building.note = entity.note;
            building.map = entity.map;
            building.avatar = entity.avatar;
            building.buildingImages = builidingImages(entity.building_images);
            building.rentareas = AllToString(entity.rentarea);
            if(entity.typess != null)
            {
                building.buildingTypes = entity.typess.Split(',');
            }
            

            return building;
        }



      

        private static string AllToString(ICollection<rentarea> hashset)
        {
                string rentArea = null;

                List<string> list = new List<string>();
                foreach (var item in hashset)
                {
                    list.Add(item.value.ToString());
                  
                }
            rentArea = string.Join(",", list);
            return rentArea;
        }
        private static string[] builidingImages(ICollection<building_images> hashset)
        {
            string[] images = new string[hashset.Count];
            int index = 0;
            foreach (var item in hashset)
            {
                images[index] = item.name;
                index++;
            }
            
            return images;
        }


    }
}