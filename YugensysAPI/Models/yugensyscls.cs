using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YugensysAPI.DAL;

namespace YugensysAPI.Models
{
    public class Fruit
    {
        public int id { get; set; }
        public string fruit { get; set; }
    }
    public class ResponseClass
    {
        public int status { get; set; }
        public object data { get;set; }
    }
    public class yugensyscls
    {
        private YugensysDBEntities db = new YugensysDBEntities();

        public short AddPair(string color, string fruit)
        {
            short result = 0;
            try
            {
                tbl_pair obj = new tbl_pair();
                obj.color = color;
                obj.fruit = fruit;
                db.tbl_pair.Add(obj);
                int rowaffected=db.SaveChanges();
                if (rowaffected > 0)
                {
                    result = 1;
                }
            }
            catch (Exception)
            {
                result = 3;
            }
            return result;

        }

        public short GetFruit(string color, ref List<Fruit> lst)
        {
            short result = 0;
            try
            {
                var data = db.suggested_sp(color).ToList();
                foreach(var obj in data)
                {
                    Fruit fruit = new Fruit();
                    fruit.id = obj.id;
                    fruit.fruit = obj.fruit;
                    lst.Add(fruit);
                    
                }
                if (lst.Count > 0)
                {
                    result = 1;
                }
            }
            catch(Exception)
            {
                result = 3;
            }
            return result;
        }
    }
}