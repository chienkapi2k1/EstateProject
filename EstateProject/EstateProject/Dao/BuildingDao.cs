
using EstateProject.Common;
using EstateProject.Dto;
using EstateProject.Models;

using PagedList;
using System;
using System.Collections.Generic;

using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EstateProject.Dao
{
    public class BuildingDao
    {
        EstateDbContext dbContext = null;
        public BuildingDao()
        {
            dbContext = new EstateDbContext();
        }


        public List<BuildingDto> findAll(BuildingDto dto)
        {
            
            List<BuildingDto> temp = new List<BuildingDto>();
            BuildingSearchDto buildingSearch = initBuildingSearch(dto);
            StringBuilder sql = new StringBuilder("select * from building as b  where 1 = 1  ");
           
            createWhereClausePart1(buildingSearch, sql);
            createWhereClausePart2(buildingSearch, sql);
        
            var model = dbContext.building.SqlQuery(sql.ToString()).OrderByDescending(x => x.id)
                   .Skip((dto.page - 1) * dto.limit).Take(dto.limit).ToList();

            foreach (var item in model)
            {
                BuildingDto building = BuildingConverter.converterToDto(item);
                temp.Add(building);
            }
            return temp;
        }

        private void createWhereClausePart1(BuildingSearchDto buildingSearch, StringBuilder sql)
        {
            if (buildingSearch.UserId != 0 && buildingSearch.UserId != null)
            {
                sql.Append("and user_id =" + buildingSearch.UserId);
            }

            FieldInfo[] properties = buildingSearch.GetType().GetFields(BindingFlags.Public |
                                              BindingFlags.NonPublic |
                                              BindingFlags.Instance);

            foreach (FieldInfo item in properties)
            {
              
                string[] str = item.Name.Split('<','>');
                string name = str[1];
                object objectvalue = item.GetValue(buildingSearch);
                   if (!name.Equals("buildingTypes") && !name.Equals("UserId") && !name.StartsWith("areaRent") && !name.StartsWith("costRent")){
                        if (item.FieldType.Equals(typeof(string))) {
                            string value = (string) objectvalue;
                            if (!string.IsNullOrEmpty(value)) {
                                sql.Append(" AND b." + name + " LIKE '%" + objectvalue + "%' \n");
                            }
                        } else if (item.FieldType.Equals(typeof(int)) || item.FieldType.Equals(typeof(double))) {
                            if (!objectvalue.Equals(0)) {
                                sql.Append(" AND b." + name + " = " + objectvalue + " \n");
                            }
                        }
                }
            }
        }

        private void createWhereClausePart2(BuildingSearchDto buildingSearch, StringBuilder sql)
        {
            

            if (buildingSearch.costRentFrom != 0 || buildingSearch.costRentTo != 0)
            {
                sql.Append(BuildBetweenQuery("b.rentprice", buildingSearch.costRentFrom, buildingSearch.costRentTo));
                sql.Append("\n");
            }
            if (buildingSearch.areaRentFrom != 0 || buildingSearch.areaRentTo != 0)
            {
                sql.Append(" AND EXISTS (SELECT * FROM rentarea ra WHERE ra.buildingid = b.id ");
                sql.Append(BuildBetweenQuery("ra.value", buildingSearch.areaRentFrom, buildingSearch.areaRentTo));
                sql.Append(")\n");
            }
            if(buildingSearch.buildingTypes != null && buildingSearch.buildingTypes.Length > 0)
            {
                sql.Append(" and ( ");
                List<string> list = new List<string>();
                foreach( var item in buildingSearch.buildingTypes)
                {
                    list.Add("b.typess like '%" + item + "%' ");
                }
                String typesSQL = String.Join(" or ", list);
                sql.Append(typesSQL);
                sql.Append(")");
            }
        }

        private BuildingSearchDto initBuildingSearch(BuildingDto building)
        {
            BuildingSearchDto builder = new BuildingSearchDto();

            builder.areaRentFrom = building.areaRentFrom;
            builder.areaRentTo = building.areaRentTo;

            builder.costRentFrom = building.costRentFrom;
            builder.costRentTo = building.costRentTo;

            builder.numberofbasement = building.numberofbasement;
            builder.floorarea = building.floorarea;

            builder.UserId = building.UserId;
            builder.street = building.street;

            builder.ward = building.ward;
            builder.district = building.district;

            builder.direction = building.direction;
            builder.name = building.name;

            builder.levels = building.levels;
            builder.buildingTypes = building.buildingTypes;

            return builder;

        }

        public int countBySearch(BuildingDto dto)
        {

           
            BuildingSearchDto buildingSearch = initBuildingSearch(dto);
            StringBuilder sql = new StringBuilder("select * from building as b  where 1 = 1  ");

            createWhereClausePart1(buildingSearch, sql);
            createWhereClausePart2(buildingSearch, sql);
            var model = dbContext.building.SqlQuery(sql.ToString()).ToList();
           
            return model.Count();
        }
        private string BuildBetweenQuery(string column, object from , object to)
        {
            if (from == null && to == null) return "";
            else
            {
                if (from == null) from = 0;
                if (to == null)
                {
                    if (from.GetType().Equals(typeof(Int32)))
                    {
                        to = Int32.MaxValue;
                    }
                    else if(from.GetType().Equals(typeof(Double)))
                    {
                        to = Double.MaxValue;
                    }
                }
                return " AND "+column+ " BETWEEN  " + from + " AND  " + to + "";
            }

        }

       

        public long save( BuildingDto buildingDto)
        {
            building building = BuildingConverter.converterToEntity(buildingDto);
           

            if(buildingDto.buildingImages != null)
            {
                building.typess = string.Join(", ", buildingDto.buildingTypes);
            }

            List<rentarea> rentareas = new List<rentarea>();
            if (!string.IsNullOrEmpty(buildingDto.rentareas))
            {
             
                foreach (var item in buildingDto.rentareas.Split(',')) {
                    rentarea area = new rentarea();
                    if (int.Parse(item.Trim()) > 0)
                    {
                        area.value = int.Parse(item.Trim());

                    }
                    area.building = building;
                    /* add to list */
                    rentareas.Add(area);
                }
                building.rentarea = rentareas;
            }

            List<building_images> _Images = new List<building_images>();
            if (buildingDto.buildingImages != null)
            {
                foreach(var image in buildingDto.buildingImages)
                {
                    building_images images = new building_images();

                    images.name = image;
                    images.building = building;
                    /* add to list */
                    _Images.Add(images);
                }

                building.building_images = _Images;
            }


            dbContext.building.Add(building);
            dbContext.SaveChanges();

            return buildingDto.id;
        }

       
        public long Update(int id, BuildingDto buildingDto)
        {
          

            var building = BuildingConverter.converterToEntity(buildingDto);
         
            

            var rentAreas = dbContext.rentarea.Where(n => n.buildingid == id);
            if (rentAreas != null)
            {
                foreach (var a in rentAreas)
                {
                    dbContext.Entry(a).State = EntityState.Deleted;
                }

            }
            

            if (buildingDto.buildingTypes != null)
            {
                building.typess = string.Join(", ", buildingDto.buildingTypes);
            }


            if (!string.IsNullOrEmpty(buildingDto.rentareas))
            {

                foreach (var item in buildingDto.rentareas.Split(','))
                {
                    rentarea area = new rentarea();
                    if (int.Parse(item.Trim()) > 0)
                    {
                        area.value = int.Parse(item.Trim());
                    }
                    area.buildingid = id;
                    dbContext.rentarea.Add(area);
                }

            }

            var buildingImages = dbContext.building_images.Where(n => n.building_id == id);
            
            if (buildingDto.buildingImages != null)
            {
                if (buildingImages != null)
                {
                    foreach (var item in buildingImages)
                    {
                        dbContext.Entry(item).State = EntityState.Deleted;
                    }

                }
                foreach (var image in buildingDto.buildingImages)
                {
                    building_images images = new building_images();
                    images.name = image;
                    images.building_id = id;
                    dbContext.building_images.Add(images);
                }


            }
            else
            {
                if (buildingImages != null)
                {
                    foreach (var item in buildingImages)
                    {
                        dbContext.Entry(item).State = EntityState.Deleted;
                    }

                }
            }

            

            dbContext.Entry(building).State = EntityState.Modified;
            dbContext.SaveChanges();

            return building.id;


        }

        public building findById(int? buildingId)
        {    
            return dbContext.building.Find(buildingId);
        }


        public void delete(List<int> ids)
        {
            foreach (int item in ids)
            {
                var rentAreas = dbContext.rentarea.Where(n => n.buildingid == item);
                if (rentAreas != null)
                {
                    foreach (var a in rentAreas)
                    {
                        dbContext.Entry(a).State = EntityState.Deleted;
                    }

                }
                var entity = dbContext.building.Find(item);
                dbContext.building.Remove(entity);
                dbContext.SaveChanges();
            
            }
        }


      

      
    }
}