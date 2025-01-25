using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Mission3Assignment
{
    internal class FoodItem
    //The FoodItem class is used to encapsulate each detail about a particular food item
    {

        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }

        //Food Item Constructor with the attributes that it must contain
        public FoodItem(string name, string category, int quantity, DateTime expirationDate)
        {
            //Initialization
            //Each detail of the food item is recognized 
            //Error handling for the user to enter a quantity that is positive
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be positive.");
            }

            Name = name;
            Category = category;
            Quantity = quantity;
            ExpirationDate = expirationDate;

        }

        public override string ToString()
        {
            //This is the concatenated string that will be returned 
            //The quantity and experiation attributes are the ones that need to be converted to strings
            //This output is what the user will see in a series of lines divided by pipes
            return $"{Name} | {Category}  | Quantity: {Quantity}  | Expiration: {ExpirationDate.ToShortDateString()}";
        }
    }
}