using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shoppingweb.DAL;

namespace Shoppingweb.BLL
{
    public class Produces
    {
        private int id;
        private string title;
        private string price;
        private int num;
        private string image;
        private string information;
        private DateTime date;
        private string state;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Price { get => price; set => price = value; }
        public int Num { get => num; set => num = value; }
        public string Image { get => image; set => image = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Information { get => information; set => information = value; }
        public string State { get => state; set => state = value; }

        public void addProduces(Produces produces) {
            ProducesDB.addProduces(produces);
        }

        public Produces SearchProduces(int Id) {
            return ProducesDB.SearchProduces(Id);
        }
    }
}