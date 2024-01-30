using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10262621_PRG2Assignment
{
    class Cup:IceCream
    {
        public Cup() { }
        public Cup(string option, int scoops, List<Flavour> flavours, List<Topping> toppings) : base(option, scoops, flavours, toppings)
        {

        }
        public override double CalculatePrice()
        {
            
            double price = 0;

            if (Scoops == 1)
            {
                price += 4;

            }
            else if(Scoops == 2)
            {
                price += 5.5;
            }
            else
            {
                price += 6.5;
            }
            foreach (Flavour flavour in Flavours)
            {
                if (flavour.Premium)
                {
                    price += 2 * flavour.Quantity;
                }
            }
            foreach (Topping topping in Toppings)
            {
                price += 1;
            }

            return price;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
