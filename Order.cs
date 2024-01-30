using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10262621_PRG2Assignment
{
    class Order : Customer
    {
        public int Id { get; set; }
        public DateTime TimeReceived { get; set; }
        public DateTime? TimeFulfilled { get; set; }
        public List<IceCream> IceCreamList { get; set; }
        public Order() { }
        public Order(int id, DateTime date)
        {
            Id = id;
            TimeReceived = date;
            TimeFulfilled = null;
            IceCreamList = new List<IceCream>();
        }

        public void ModifyIceCream(int index)
        {
            while (true)
            {
                Console.Write("Enter option (Cup/Cone/Waffle): ");
                string option = Console.ReadLine();
                Console.Write("Enter number of scoops: ");
                int scoops = int.Parse(Console.ReadLine());
                List<Flavour> Flavours = new List<Flavour>();
                List<Topping> Toppings = new List<Topping>();
                IceCream icecream = null;
                if (option == "Cup")
                {
                    icecream = new Cup(option, scoops, Flavours, Toppings);
                }
                else if (option == "Cone")
                {
                    bool dippedOrNot = false;
                    while (true)
                    {
                        Console.Write("Upgrade to Chocolate Dipped Cone?(Y/N): ");
                        string ifDipped = Console.ReadLine();
                        if (ifDipped == "Y")
                        {
                            dippedOrNot = true;
                            break;
                        }
                        else if (ifDipped == "N")
                        {
                            dippedOrNot = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please choose a valid option.");
                        }
                    }
                    icecream = new Cone(option, scoops, Flavours, Toppings, dippedOrNot);
                }
                else if (option == "Waffle")
                {
                    string waffleFlavour = "";
                    while (true)
                    {
                        Console.WriteLine("Type of Waffle: ");
                        Console.WriteLine("[1] Original");
                        Console.WriteLine("[2] Red Velvet");
                        Console.WriteLine("[3] Charcoal");
                        Console.WriteLine("[4] Pandan");
                        Console.Write("Choose an option: ");
                        string waffleFlavourChosen = Console.ReadLine();
                        if (waffleFlavourChosen == "1")
                        {
                            waffleFlavour = "Original";
                            break;
                        }
                        else if (waffleFlavourChosen == "2")
                        {
                            waffleFlavour = "RedVelvet";
                            break;
                        }
                        else if (waffleFlavourChosen == "3")
                        {
                            waffleFlavour = "Charcoal";
                            break;
                        }
                        else if (waffleFlavourChosen == "4")
                        {
                            waffleFlavour = "Pandan";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid option.");
                        }
                    }
                    icecream = new Waffle(option, scoops, Flavours, Toppings, waffleFlavour);
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                    continue;
                }



                for (int i = 0; i < scoops; i++)
                {
                    while (true)
                    {
                        Flavour Flavour = new Flavour();
                        Console.WriteLine("Flavour(s): ");
                        Console.WriteLine("[1] Vanilla");
                        Console.WriteLine("[2] Chocolate");
                        Console.WriteLine("[3] Strawberry");
                        Console.WriteLine("[4] Durian");
                        Console.WriteLine("[5] Ube");
                        Console.WriteLine("[6] Sea Salt");
                        Console.Write("Choose flavour: ");
                        string flavourOption = Console.ReadLine();
                        if (flavourOption == "1")
                        {
                            Flavour.Type = "Vanilla";
                            Flavour.Premium = false;
                            Flavour.Quantity = 1;
                            Flavours.Add(Flavour);
                            break;
                        }
                        else if (flavourOption == "2")
                        {
                            Flavour.Type = "Chocolate";
                            Flavour.Premium = false;
                            Flavour.Quantity = 1;
                            Flavours.Add(Flavour);
                            break;
                        }
                        else if (flavourOption == "3")
                        {
                            Flavour.Type = "Strawberry";
                            Flavour.Premium = false;
                            Flavour.Quantity = 1;
                            Flavours.Add(Flavour);
                            break;
                        }
                        else if (flavourOption == "4")
                        {
                            Flavour.Type = "Durian";
                            Flavour.Premium = true;
                            Flavour.Quantity = 1;
                            Flavours.Add(Flavour);
                            break;
                        }
                        else if (flavourOption == "5")
                        {
                            Flavour.Type = "Ube";
                            Flavour.Premium = true;
                            Flavour.Quantity = 1;
                            Flavours.Add(Flavour);
                            break;
                        }
                        else if (flavourOption == "6")
                        {
                            Flavour.Type = "Sea Salt";
                            Flavour.Premium = true;
                            Flavour.Quantity = 1;
                            Flavours.Add(Flavour);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid option.");
                        }

                    }

                }
                while (true)
                {
                    Topping topping = new Topping();
                    Console.WriteLine("Topping(s): ");
                    Console.WriteLine("[1] Sprinkles");
                    Console.WriteLine("[2] Mochi");
                    Console.WriteLine("[3] Sago");
                    Console.WriteLine("[4] Oreos");
                    Console.Write("Choose a topping (max 4, enter 0 if done): ");
                    string chosenTopping = Console.ReadLine();

                    if (chosenTopping == "0")
                    {
                        break;
                    }
                    else if (chosenTopping == "1")
                    {
                        topping.Type = "Sprinkles";
                    }
                    else if (chosenTopping == "2")
                    {
                        topping.Type = "Mochi";
                    }
                    else if (chosenTopping == "3")
                    {
                        topping.Type = "Sago";
                    }
                    else if (chosenTopping == "4")
                    {
                        topping.Type = "Oreos";
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid option.");
                    }
                    Toppings.Add(topping);
                }
                IceCreamList[index - 1] = icecream;
                break;
            }
        }
        public void AddIceCream(IceCream icecream)
        {
            IceCreamList.Add(icecream);
        }

        public void DeleteIceCream(int index)
        {
            if (index >= 1 && index <= IceCreamList.Count)
            {
                IceCreamList.RemoveAt(index - 1);
            }
            else
            {
                Console.WriteLine("Invalid index. Please choose a valid index to delete.");
            }
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (var iceCream in IceCreamList)
            {
                total += iceCream.CalculatePrice();
            }
            return total;
        }
        public override string ToString()
        {
            string result = "";
            result += string.Format("{0,-15} {1,-22} {2,-15}\n", "Order ID", "Time Received", "Time Fulfilled");
            result += string.Format("{0,-15} {1,-22} {2,-15}\n", Id, TimeReceived, TimeFulfilled);
            result += "----------------------------------------------------------------------\n";
            foreach (IceCream icecream in IceCreamList)
            {
                result += $"Option: {icecream.Option}\n";
                result += $"Scoops: {icecream.Scoops}\n";
                result += "\nFlavours: \n";

                foreach (Flavour flavour in icecream.Flavours)
                {
                    result += flavour.ToString() + "\n";
                }

                result += "\nToppings: \n";
                foreach (Topping topping in icecream.Toppings)
                {
                    result += topping.ToString() + "\n";
                }

                // Format the result of CalculateTotal as currency
                result += $"\nTotal: {CalculateTotal().ToString("C2")}\n";

                result += "----------------------------------------------------------------------\n";
            }

            return result;
        }

    }
}
