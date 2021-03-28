using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using TombolaAllTheBeans.Models;

namespace TombolaAllTheBeans.Repositories
{
    public class BeansRepository
    {
        JavaScriptSerializer _serializer = new JavaScriptSerializer();
        string filePath = "D:/Source Code/AllTheBeansSource/TombolaAllTheBeans/TombolaAllTheBeans/Data/beans.json";

        public List<Bean> GetAllBeans()
        {
            dynamic json = File.ReadAllText(filePath);
            return _serializer.Deserialize<List<Bean>>(json);
        }

        public Bean GetBean(Guid id)
        {
            var beans = this.GetAllBeans();
            var bean = beans.Where(x => x.id == id).FirstOrDefault();
            if (bean != null)
            {
                return bean;
            }
            else
            {
                throw new Exception($"Bean not found, id: {id}.");
            }
        }

        public void CreateBean(Bean bean)
        {
            bean.id = new Guid();
            var beans = this.GetAllBeans();
            beans.Add(bean);

            dynamic json = _serializer.Serialize(beans);
            File.WriteAllText(filePath, json);
        }

        public void UpdateBean(Bean bean)
        {
            var beans = this.GetAllBeans();
            var oldBean = beans.FirstOrDefault(x => x.id == bean.id);

            beans.RemoveAt(beans.IndexOf(oldBean));
            beans.Add(bean);

            dynamic json = _serializer.Serialize(beans);
            File.WriteAllText(filePath, json);
        }

        public Bean GetTodaysBean(DateTime todaysDate)
        {
            var beans = this.GetAllBeans();
            var todaysBean = beans.Where(x => x.DateDisplayed.Date == todaysDate.Date).FirstOrDefault();

            if (todaysBean != null)
            {
                return todaysBean;
            }
            else if (beans.FirstOrDefault() != null)
            {
                return beans.First();
            }
            else
            {
                return GetDefaultBean();
            }
        }

        private Bean GetDefaultBean()
        {
            return new Bean
            {
                Name = "this is a default name",
                Aroma = "this is a default aroma",
                Colour = "this is a default colour",
                Price = 999,
                ImageUrl = "https://thumbs.dreamstime.com/b/heart-made-out-coffee-beans-17667662.jpg"
            };
        }
    }
}