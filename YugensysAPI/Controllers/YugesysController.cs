using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YugensysAPI.Models;

namespace YugensysAPI.Controllers
{
    public class YugesysController : ApiController
    {
        [HttpPost]
        public ResponseClass AddPair(string color, string fruit)
        {
            ResponseClass resData = new ResponseClass();
            try
            {
                yugensyscls objYun = new yugensyscls();
                short result =objYun.AddPair(color, fruit);
                resData.status = result;
            }
            catch (Exception ex)
            {
                resData.status = 3;
            }
            return resData;
        }
        [HttpPost]
        public ResponseClass GetFruit(string color)
        {
            ResponseClass resData = new ResponseClass();
            try
            {
                List<Fruit> lst = new List<Fruit>();
                yugensyscls objYun = new yugensyscls();
                short result = objYun.GetFruit(color, ref lst);
                resData.status = result;
                resData.data = lst;
            }
            catch (Exception ex)
            {
                resData.status = 3;
            }
            return resData;
        }

    }
}
