using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entities
{
    public class Pet
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Owner { get; set; }
        public double Price { get; set; }


    }
}
