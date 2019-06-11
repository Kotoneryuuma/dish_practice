using System.ComponentModel.DataAnnotations;
using System;
namespace delicious.Models
{
    public class Dish
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        public int DishId { get; set; }
        // MySQL VARCHAR and TEXT types can be represeted by a string
        public string Name { get; set; }
        public string Chef { get; set; }
        public string Tastiness { get; set; }
        public string Calories{ get; set; }

        public string Description{ get; set; }

        // The MySQL DATETIME type can be represented by a DateTime
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
    }
}