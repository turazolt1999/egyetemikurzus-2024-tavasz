using System;
using System.Collections.Generic;

namespace Blackjack.Models
{
    public record Player
    {
        public string Name { get; }
        public List<Card> Hand { get; }
        public int Money { get; private set; }
        public int Bet { get; private set; }

        public Player(string name, int startingMoney = 100)
        {
            Name = name;
            Hand = new List<Card>();
            Money = startingMoney;
            Bet = 0;
        }

        public void AddMoney(int amount)
        {
            Money += amount;
        }

        public void PlaceBet(int amount)
        {
            if (amount > Money)
            {
                Console.WriteLine("Nincs elegend� p�nz a t�t felad�s�hoz!");
            }
            else
            {
                Bet = amount;
                Money -= amount;
            }
        }

        public void ResetHand()
        {
            Hand.Clear();
        }

    }
}