using System;
using System.Collections.Generic; //Use this for the list



namespace Assignment3_Blas
{
        class FoodItem
        {
            //Set variables 
            public string Name; 
            public string Category; 
            public int Quantity; 
            public DateTime ExpirationDate; 
            
            //This is how we pass the info for the user input into a FoodItem object. It's used in Program.cs to make the list.
            public FoodItem(string name, string category, int quantity, DateTime expirationDate)
            {
                Name = name;
                Category = category;
                Quantity = quantity;
                ExpirationDate = expirationDate;
            }

        //See this in the printing method. It explains why we need to overwrite ToString(). 
        public override string ToString()
        {
            //This part tells it what to look like when you display the list item.
            return $"Name: {Name}, Category: {Category}, Quantity: {Quantity}, Expiration Date: {ExpirationDate:yyyy-MM-dd}";
        }
    }
    }


