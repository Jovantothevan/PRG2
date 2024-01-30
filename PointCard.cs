using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10262621_PRG2Assignment
{
    class PointCard
    {
        public int Points {  get; set; }
        public int PunchCard {  get; set; }
        public string Tier {  get; set; }
        public PointCard() { }
        public PointCard(int p, int pc)
        {
            Points = p;
            PunchCard = pc;
            if (p >= 100)
            {
                Tier = "Gold";
            }
            else if (p >= 50)
            {
                Tier = "Silver";
            }
            else
            {
                Tier = "Ordinary";
            }
        }

        public void AddPoints(int points)
        {
            Points += points;

            if (Points >= 100 && Tier != "Gold")
            {
                Tier = "Gold";
            }
            else if (Points >= 50 && Tier != "Silver")
            {
                Tier = "Silver";
            }
            else
            {
                Tier = "Ordinary";
            }
        }

        public void RedeemPoints(int points)
        {
            if ((Tier == "Silver" || Tier == "Gold") && points > 0)
            {
                Points -= points;

                if (Points < 0)
                {
                    Points = 0;
                }
            }
            else
            {
                Console.WriteLine("Only Silver and Gold members can redeem their points");
            }
        }
        public void Punch()
        {
            if(PunchCard == 10)
            {
                PunchCard = 0;
            }
            else
            {
                PunchCard++;
            }
        }

        public override string ToString()
        {
            return $"Points: {Points} PunchCard: {PunchCard} Tier: {Tier}";
        }
    }
}
