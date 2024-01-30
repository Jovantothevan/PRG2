using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10262621_PRG2Assignment
{
    class Customer
    {
        public string Name { get; set; }
        public int MemberID { get; set; }
        public DateTime Dob { get; set; }
        public Order currentOrder { get; set; }
        public List<Order> orderHistory { get; set; } = new List<Order>();
        public PointCard Rewards { get; set; }

        public Customer() { }

        public Customer(string name, int memberid, DateTime date)
        {
            Name = name;
            MemberID = memberid;
            Dob = date;
            orderHistory = new List<Order>();
            Rewards = new PointCard(0,0);
            currentOrder = new Order();
        }

        public Order MakeOrder()
        {
            int orderId = orderHistory.Count + 1;
            DateTime timeReceived = DateTime.Now;
            Order order = new Order(orderId, timeReceived);
            currentOrder = order;  // Set CurrentOrder to the new order
            return order;
        }

        public bool IsBirthday()
        {
            DateTime currentDate = DateTime.Now;
            return Dob.Month == currentDate.Month && Dob.Day == currentDate.Day;
        }

        public override string ToString()
        {
            return $"Name: {Name} MemberID: {MemberID} Date of Birth: {Dob}";
        }
    }
}
