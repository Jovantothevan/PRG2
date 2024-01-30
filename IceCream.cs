using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10262621_PRG2Assignment
{
    abstract class IceCream
    {
        public string Option {  get; set; }
        public int Scoops { get; set; }
        public List<Flavour> Flavours { get; set; } = new List<Flavour>();
        public List<Topping> Toppings { get; set; } = new List<Topping>();

        public IceCream() { }
        public IceCream(string option, int scoops, List<Flavour> flavours, List<Topping> toppings)
        {
            Option = option;
            Scoops = scoops;
            Flavours = flavours;
            Toppings = toppings;
        }

        public abstract double CalculatePrice();

        public override string ToString()
        {
            StringBuilder table = new StringBuilder();

            table.AppendLine("----------------------------------");
            table.AppendLine($"Option : {Option,-15}");
            table.AppendLine("----------------------------------");
            table.AppendLine($"Scoops: {Scoops,-15}");
            table.AppendLine("----------------------------------");
            table.AppendLine("Flavours: ");
            if (Flavours.Count > 0)
            {
                table.AppendLine(string.Format("{0,-15}\t{1,-15}\t{2,-15}", "Type", "Premium", "Quantity"));
                foreach (var flavour in Flavours)
                {
                    table.AppendLine($"{flavour,-35}");
                }
                table.AppendLine("-----------------------------------");
            }

            if (Toppings.Count > 0)
            {
                table.AppendLine("Toppings:");
                table.AppendLine("-----------------------------------");

                foreach (var topping in Toppings)
                {
                    table.AppendLine($"{topping,-35}");
                }

                table.AppendLine("-----------------------------------");
            }

            return table.ToString();
        }
    }
}
