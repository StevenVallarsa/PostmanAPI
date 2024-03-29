﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        CowboysEntities db = new CowboysEntities();

        // GET api/values
        public IEnumerable<Cowboy> Get()
        {
            return db.Cowboys.ToList();
        }

        // GET api/values/5
        public Cowboy Get(int id)
        {
            Cowboy cowboys = db.Cowboys.Find(id);
            return cowboys;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public string Put(int id, string property, string value)
        {
            Cowboy c = db.Cowboys.Find(id);
            if (c != null)
            {
                switch (property.ToLower())
                {
                    case "loses":
                        c.Loses = int.Parse(value);
                        break;
                }
                db.Cowboys.AddOrUpdate(c);
                db.SaveChanges();
            }
            else
            {
                return $"No record found at {id} please try another index. Db not updated.";
            }

            return $"Record at id {id} Successfully updated";
        }


        // DELETE api/values/5
        public string Delete(int id)
        {
            Cowboy c = db.Cowboys.Find(id);

            if (c != null)
            {
                return $"Nothing found at {id}. DB not updated.";
            }
            else
            {
                db.Cowboys.Remove(c);
                db.SaveChanges();
                return $"That cowboy at {id} is now pushing up daisies. Cowboy removed from DB.";
            }
        }
    }
}
