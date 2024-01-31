//==========================================================
// Student Number : S10262569H
// Student Name : Jovan Tan 1,3,4
// Partner Name : Tan Han Yan 2,5,6
//==========================================================

using S10262621_PRG2Assignment;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<Customer> customerList = new List<Customer>();
        List<Order> orderList = new List<Order>();
        List<Order> regularQueue = new List<Order>();
        List<Order> goldQueue = new List<Order>();
        void createCustomerObj(List<Customer> customerList)
        {
            string[] csvLines = File.ReadAllLines("customers.csv");
            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] data = csvLines[i].Split(',');
                string name = data[0];
                int memberid = int.Parse(data[1]);
                DateTime dob = DateTime.Parse(data[2]);
                Customer customer = new Customer(name, memberid, dob);
                customer.Rewards.Tier = data[3];
                customer.Rewards.Points = int.Parse(data[4]);
                customer.Rewards.PunchCard = int.Parse(data[5]);
                customerList.Add(customer);
            }
        }
        createCustomerObj(customerList);

        void createOrderObj(List<Customer> customerList)
        {
            string[] csvLines = File.ReadAllLines("orders.csv");

            for (int i = 1;i < csvLines.Length; i++)
            {
                List<Flavour> Flavours = new List<Flavour>();
                List<Topping> Toppings = new List<Topping>();
                bool dippedOrNot = false;
                string[] data = csvLines[i].Split(",");
                int orderID = int.Parse(data[0]);
                int memberID = int.Parse(data[1]);
                DateTime TimeReceived = DateTime.Parse(data[2]);
                DateTime TimeFulfilled = DateTime.Parse(data[3]);
                string option = data[4];
                int scoops = int.Parse(data[5]);
                string ifDipped = data[6];
                string waffleFlavour = data[7];
                Customer selectedCustomer = null;
                foreach (Customer customer in customerList)
                {
                    if (customer.MemberID == memberID)
                    {
                        selectedCustomer = customer;
                        break;
                    }
                }
                Order order = new Order(orderID,TimeReceived);
                order.TimeFulfilled  = TimeFulfilled;
                IceCream icecream = null;
                if(option == "Cup")
                {
                    icecream = new Cup(option,scoops,Flavours,Toppings);
                    
                }
                else if(option == "Cone")
                {
                    if(ifDipped == "TRUE")
                    {
                        dippedOrNot = true;
                    }
                    else if(ifDipped == "FALSE")
                    {
                        dippedOrNot= false;
                    }
                    icecream = new Cone(option,scoops,Flavours,Toppings,dippedOrNot);
                    
                }
                else if(option == "Waffle")
                {
                    icecream = new Waffle(option,scoops,Flavours,Toppings,waffleFlavour);
                }
                CreateFlavours(Flavours, data[8], data[9], data[10]);
                CreateToppings(Toppings, data[11], data[12], data[13], data[14]);
                order.AddIceCream(icecream);
                selectedCustomer.orderHistory.Add(order);
            }
        }
        createOrderObj(customerList);
        void CreateFlavours(List<Flavour> Flavours, string flavour1, string flavour2, string flavour3)
        {
            string[] flavoursArray = { flavour1, flavour2, flavour3 };

            foreach (string flavourType in flavoursArray)
            {
                Flavour flavour = new Flavour();

                // Check if flavourType is not empty before processing
                if (!string.IsNullOrWhiteSpace(flavourType))
                {
                    switch (flavourType)
                    {
                        case "Vanilla":
                            flavour.Type = "Vanilla";
                            flavour.Premium = false;
                            flavour.Quantity = 1;
                            break;
                        case "Chocolate":
                            flavour.Type = "Chocolate";
                            flavour.Premium = false;
                            flavour.Quantity = 1;
                            break;
                        case "Strawberry":
                            flavour.Type = "Strawberry";
                            flavour.Premium = false;
                            flavour.Quantity = 1;
                            break;
                        case "Durian":
                            flavour.Type = "Durian";
                            flavour.Premium = true;
                            flavour.Quantity = 1;
                            break;
                        case "Ube":
                            flavour.Type = "Ube";
                            flavour.Premium = true;
                            flavour.Quantity = 1;
                            break;
                        case "Sea Salt":
                            flavour.Type = "Sea Salt";
                            flavour.Premium = true;
                            flavour.Quantity = 1;
                            break;
                        default:
                            break;
                    }

                    Flavours.Add(flavour);
                }
            }
        }


        void CreateToppings(List<Topping> Toppings, string topping1, string topping2, string topping3, string topping4)
        {
            string[] toppingsArray = { topping1, topping2, topping3, topping4 };

            foreach (string toppingType in toppingsArray)
            {
                Topping topping = new Topping();

                // Check if toppingType is not empty before processing
                if (!string.IsNullOrWhiteSpace(toppingType))
                {
                    switch (toppingType)
                    {
                        case "Sprinkles":
                            topping.Type = "Sprinkles";
                            break;
                        case "Mochi":
                            topping.Type = "Mochi";
                            break;
                        case "Sago":
                            topping.Type = "Sago";
                            break;
                        case "Oreos":
                            topping.Type = "Oreos";
                            break;
                        default:
                            break;
                    }

                    Toppings.Add(topping);
                }
            }
        }
        while (true)
        {
            Console.WriteLine("[1] List all customers");
            Console.WriteLine("[2] List all current orders");
            Console.WriteLine("[3] Register a new customer");
            Console.WriteLine("[4] Create a customer's order");
            Console.WriteLine("[5] Display order details of a customer");
            Console.WriteLine("[6] Modify order details");
            Console.Write("Choose an option: (0 to exit): ");
            int option = Convert.ToInt32(Console.ReadLine());
            if (option == 0)
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else if (option == 1)
            {
                option1();
            }
            else if (option == 2)
            {
                option2(regularQueue, goldQueue);
            }
            else if (option == 3)
            {
                option3(customerList);
            }
            else if(option == 4)
            {
                option4(customerList,regularQueue,goldQueue);
            }
            else if(option == 5)
            {
                option5(customerList);
            }
            else if(option == 6)
            {
                option6(customerList);
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }


        void option1()
        {
            Console.WriteLine("List of all customers:");
            Console.WriteLine("{0,-10}{1,-11}{2,-13}{3,-21}{4,-19}{5,-11}",
                "Name", "MemberId", "DOB", "MembershipStatus", "MembershipPoints", "PunchCard");

            string[] csvLines = File.ReadAllLines("customers.csv");
            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] data = csvLines[i].Split(',');
                string name = data[0];
                int memberid = int.Parse(data[1]);
                DateTime dob = DateTime.Parse(data[2]);
                string membershipStatus = data[3];
                int membershipPoints = int.Parse(data[4]);
                int punchCard = int.Parse(data[5]);

                Console.WriteLine("{0,-10}{1,-11}{2,-13}{3,-21}{4,-19}{5,-11}",
                    name, memberid.ToString(), dob.ToString("dd/MM/yyyy"), membershipStatus, membershipPoints, punchCard);
            }
        }

        void option2(List<Order> regularQueue, List<Order> goldQueue)
        {
            Console.WriteLine("Regular Queue: ");
            foreach(Order order in regularQueue)
            {
                Console.WriteLine(order.ToString());
            }
            Console.WriteLine("Gold Queue: ");
            foreach(Order order in goldQueue)
            {
                Console.WriteLine(order.ToString());
            }
        }

        void option3(List<Customer> customerList)
        {
            try
            {
                Console.Write("Enter customer name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Customer name cannot be null or empty.");
                }

                string filePath = "customers.csv";
                Console.Write("Enter customer ID number (6 digit): ");
                int idNumber;
                if (!int.TryParse(Console.ReadLine(), out idNumber) || idNumber < 100000 || idNumber > 999999 )
                {
                    throw new ArgumentException("ID number must be a 6 digit number.");
                }
                foreach (Customer customer in customerList)
                {
                    if (customer.MemberID == idNumber)
                    {
                        throw new ArgumentException("ID entered has been used");
                    }
                }

                Console.Write("Enter customer date of birth (dd-MM-yyyy): ");
                DateTime dob;
                if (!DateTime.TryParse(Console.ReadLine(), out dob) || dob > DateTime.Today)
                {
                    throw new ArgumentException("Invalid Date of Birth");
                }

                Customer newCustomer = new Customer(name, idNumber, dob);
                customerList.Add(newCustomer);

                string newData = $"{name},{idNumber},{dob},{newCustomer.Rewards.Tier},{newCustomer.Rewards.Points},{newCustomer.Rewards.PunchCard}\n";
                AppendToCSV(filePath, newData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void AppendToCSV(string filePath, string newData)
        {
            try
            {
                // Create or open the CSV file in append mode
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    // Append the new data to the file
                    sw.Write(newData);
                }

                Console.WriteLine("Data appended to the CSV file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred when appending data: {ex.Message}");
            }
        }



        void option4(List<Customer> customerList, List<Order> regularQueue, List<Order> goldQueue)
        {
            try
            {
                option1();
                Console.Write("Enter customer ID: ");
                int customerID = Convert.ToInt32(Console.ReadLine());
                Customer selectedCustomer = null;
                foreach (Customer customer in customerList)
                {
                    if (customer.MemberID == customerID)
                    {
                        selectedCustomer = customer;
                        break;
                    }
                }

                if (selectedCustomer == null)
                {
                    Console.WriteLine("Customer not found. Please enter a valid customer ID.");
                    return;
                }
                if (selectedCustomer.currentOrder.IceCreamList == null)
                {
                    selectedCustomer.currentOrder = selectedCustomer.MakeOrder();
                }
                while (true)
                {

                    string option = "";
                    while (!(option == "cup" || option == "cone" || option == "waffle"))
                    {
                        Console.Write("Enter option (Cup/Cone/Waffle): ");
                        option = Console.ReadLine().ToLower();
                        if (!(option == "cup" || option == "cone" || option == "waffle"))
                        {
                            Console.WriteLine("Invalid option. Please enter 'Cup', 'Cone', or 'Waffle'.");
                        }
                    }
                    int scoops = 0;
                    while (scoops <= 0 || scoops > 3)
                    {
                        Console.Write("Enter number of scoops (max 3): ");
                        try
                        {
                            scoops = int.Parse(Console.ReadLine());
                            if (scoops > 3)
                            {
                                Console.WriteLine("Maximum number of scoops is 3. Please enter a valid number.");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number of scoops.");
                        }
                    }
                    List<Flavour> Flavours = new List<Flavour>();
                    List<Topping> Toppings = new List<Topping>();
                    IceCream icecream = null;
                    if (option == "cup")
                    {
                        icecream = new Cup(option, scoops, Flavours, Toppings);
                    }
                    else if (option == "cone")
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
                    else if (option == "waffle")
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
                    int maxTopping = 4;
                    int toppingCount = 0;
                    while (toppingCount < maxTopping)
                    {
                        Topping topping = new Topping();
                        Console.WriteLine("Topping(s): ");
                        Console.WriteLine("[1] Sprinkles");
                        Console.WriteLine("[2] Mochi");
                        Console.WriteLine("[3] Sago");
                        Console.WriteLine("[4] Oreos");
                        Console.Write("Choose a topping (max 4, enter 0 if done): ");
                        int chosenTopping = int.Parse(Console.ReadLine());

                        if (chosenTopping == 0)
                        {
                            break;
                        }
                        else if (chosenTopping == 1)
                        {
                            topping.Type = "Sprinkles";
                        }
                        else if (chosenTopping == 2)
                        {
                            topping.Type = "Mochi";
                        }
                        else if (chosenTopping == 3)
                        {
                            topping.Type = "Sago";
                        }
                        else if (chosenTopping == 4)
                        {
                            topping.Type = "Oreos";
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid option.");
                            maxTopping += 1;
                        }
                        Toppings.Add(topping);
                        toppingCount++;
                    }
                    Order order = selectedCustomer.currentOrder;
                    order.AddIceCream(icecream);
                    order = selectedCustomer.currentOrder;
                    if (selectedCustomer.Rewards.Tier == "Gold")
                    {
                        goldQueue.Add(order);
                    }
                    else
                    {
                        regularQueue.Add(order);
                    }
                    string response = "";
                    while (!(response == "Y" || response == "N"))
                    {
                        Console.Write("Would you like to add another ice cream to the order? (Y/N): ");
                        response = Console.ReadLine().ToUpper();
                        if (!(response == "Y" || response == "N"))
                        {
                            Console.WriteLine("Invalid response. Please enter 'Y' for Yes or 'N' for No.");
                        }
                    }

                    if (response == "N")
                    {
                        Console.WriteLine("Order has been made successfully");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        void option5(List<Customer> customerList)
        {
            try
            {
                option1();
                Console.Write("Enter customer ID: ");
                int customerID = Convert.ToInt32(Console.ReadLine());
                Customer selectedCustomer = null;
                foreach (Customer customer in customerList)
                {
                    if (customer.MemberID == customerID)
                    {
                        selectedCustomer = customer;
                        break;
                    }
                }
                if (selectedCustomer == null)
                {
                    Console.WriteLine("Customer not found. Please enter a valid customer ID.");
                    return;
                }
                if (selectedCustomer.currentOrder.IceCreamList == null)
                {
                    Console.WriteLine("Customer current order is empty");
                }
                else
                {
                    Console.WriteLine("Current Order: ");
                    Console.WriteLine(selectedCustomer.currentOrder.ToString());
                }
                Console.WriteLine("Order History: ");
                foreach (Order order in selectedCustomer.orderHistory)
                {
                    if (order.IceCreamList == null)
                    {
                        Console.WriteLine("Customer order history is empty");
                    }
                    else
                    {
                        Console.WriteLine(order.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        void option6(List<Customer> customerList)
        {
            try
            {
                option1();
                Console.Write("Enter customerID: ");
                int customerID = Convert.ToInt32(Console.ReadLine());
                Customer selectedCustomer = null;
                foreach (Customer customer in customerList)
                {
                    if (customer.MemberID == customerID)
                    {
                        selectedCustomer = customer;
                    }

                }

                if (selectedCustomer == null)
                {
                    Console.WriteLine("Customer not found. Please enter a valid customer ID.");
                    return;
                }
                if (selectedCustomer.currentOrder.IceCreamList == null)
                {
                    Console.WriteLine("Your order is empty.");
                    return;
                }
                else
                {
                    Console.WriteLine(selectedCustomer.currentOrder.ToString());
                }
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("[1] Choose an existing ice cream object to modify");
                Console.WriteLine("[2] Add an entirely new ice cream object to the order");
                Console.WriteLine("[3] Choose an existing ice cream object to delete from the order");
                Console.WriteLine("[0] Enter 0 to exit");
                Console.Write("Choose an option: ");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    Console.Write("Enter ice cream number to modify: ");
                    int icecreamindex = Convert.ToInt32(Console.ReadLine());
                    selectedCustomer.currentOrder.ModifyIceCream(icecreamindex);
                    Console.WriteLine(selectedCustomer.currentOrder.ToString());
                }
                else if (option == 2)
                {
                    try
                    {
                        while (true)
                        {
                            string optionType = "";
                            while (!(optionType == "cup" || optionType == "cone" || optionType == "waffle"))
                            {
                                Console.Write("Enter option (Cup/Cone/Waffle): ");
                                optionType = Console.ReadLine().ToLower();
                                if (!(optionType == "cup" || optionType == "cone" || optionType == "waffle"))
                                {
                                    Console.WriteLine("Invalid option. Please enter 'Cup', 'Cone', or 'Waffle'.");
                                }
                            }
                            int scoops = 0;
                            while (scoops <= 0 || scoops > 3)
                            {
                                Console.Write("Enter number of scoops (max 3): ");
                                try
                                {
                                    scoops = int.Parse(Console.ReadLine());
                                    if (scoops > 3)
                                    {
                                        Console.WriteLine("Maximum number of scoops is 3. Please enter a valid number.");
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid number of scoops.");
                                }
                            }
                            List<Flavour> Flavours = new List<Flavour>();
                            List<Topping> Toppings = new List<Topping>();
                            IceCream icecream = null;
                            if (optionType == "cup")
                            {
                                icecream = new Cup(optionType, scoops, Flavours, Toppings);
                            }
                            else if (optionType == "cone")
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
                                icecream = new Cone(optionType, scoops, Flavours, Toppings, dippedOrNot);
                            }
                            else if (optionType == "waffle")
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
                                icecream = new Waffle(optionType, scoops, Flavours, Toppings, waffleFlavour);
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
                            int maxTopping = 4;
                            int toppingCount = 0;
                            while (toppingCount < maxTopping)
                            {
                                Topping topping = new Topping();
                                Console.WriteLine("Topping(s): ");
                                Console.WriteLine("[1] Sprinkles");
                                Console.WriteLine("[2] Mochi");
                                Console.WriteLine("[3] Sago");
                                Console.WriteLine("[4] Oreos");
                                Console.Write("Choose a topping (max 4, enter 0 if done): ");
                                int chosenTopping = int.Parse(Console.ReadLine());

                                if (chosenTopping == 0)
                                {
                                    break;
                                }
                                else if (chosenTopping == 1)
                                {
                                    topping.Type = "Sprinkles";
                                }
                                else if (chosenTopping == 2)
                                {
                                    topping.Type = "Mochi";
                                }
                                else if (chosenTopping == 3)
                                {
                                    topping.Type = "Sago";
                                }
                                else if (chosenTopping == 4)
                                {
                                    topping.Type = "Oreos";
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid option.");
                                }
                                Toppings.Add(topping);
                                toppingCount++;
                            }
                            selectedCustomer.currentOrder.AddIceCream(icecream);
                            Console.WriteLine(selectedCustomer.currentOrder.ToString());
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
                else if (option == 3)
                {
                    if (selectedCustomer.currentOrder.IceCreamList.Count == 1)
                    {
                        Console.WriteLine("You cannot have zero ice creams in an order.");
                    }
                    else
                    {
                        Console.Write("Enter ice cream number to delete: ");
                        int icecreamindex = int.Parse(Console.ReadLine());
                        selectedCustomer.currentOrder.DeleteIceCream(icecreamindex);
                        Console.WriteLine(selectedCustomer.currentOrder.ToString());
                    }

                }
                else if (option == 0)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}