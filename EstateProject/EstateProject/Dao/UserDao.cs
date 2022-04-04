using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EstateProject.Common;
using EstateProject.Models;

namespace EstateProject.Dao
{


    public class UserDao
    {
        EstateDbContext dbContext = null;
        public UserDao()
        {
            dbContext = new EstateDbContext();
        }

        public long Insert(user entity)
        {
            
            var checkusername = dbContext.user.SingleOrDefault(x => x.username == entity.username);

            if (checkusername != null)
                return 0;
            dbContext.user.Add(entity);
            dbContext.SaveChanges();
            return 1;
        }
        public void Update(user entity, string newPassword)
        {
            //dbContext.users.Update(entity);
            entity.password = Encrytor.MD5Hash(newPassword);
            dbContext.SaveChanges();
        }

        public void UpdateProfile(user entity, string fullname,string email,string phone, string path)
        {
            //dbContext.users.Update(entity);
            entity.fullname = fullname;
            entity.email = email;
            entity.phone = phone;
            if(path != "")
            {
                entity.image = path;
            }
            
          
            dbContext.SaveChanges();
        }

        public user GetById(String userName)
        {
            return dbContext.user.SingleOrDefault(x => x.username == userName);
        }
        public user FindById(int? id)
        {
            return dbContext.user.SingleOrDefault(x => x.id == id);
        }
        public List<user> findByRoleAndStatus(string role , int status)
        {
            StringBuilder sql = new StringBuilder("select * from users as u  where 1 = 1  ");

            if(role != null)
            {
                sql.Append(" and u.role ='" + role + "'");
            }
            sql.Append(" and u.status = " + status);
            var model = dbContext.user.SqlQuery(sql.ToString()).ToList();
            return model;

        }

        public int login(String userName, String passWord)
        {
            var result = dbContext.user.SingleOrDefault(x => x.username == userName );
            if (result == null)
            {
                return 0;
            }
            else
            {
               if(result.status == 0)
                {
                    return -1;
                }
                else
                {
                    if(result.password == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }

        }
        public List<user> GetUser(string search)
        {
            if(search != null)
            {
                search = search.Trim();
                return dbContext.user.Where(x => x.username.Contains(search)).ToList();
            }
            return dbContext.user.Select(x => x).ToList();
        } 

        public bool DeleteUser(int id)
        {
            var d = dbContext.user.FirstOrDefault(x => x.id == id);
            if (d != null)
            {
                dbContext.user.Remove(d);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}