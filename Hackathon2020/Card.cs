using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackathon2020
{
    public class Card
    {
        public static List<int> Ranks = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

        public static List<Suit> Suits => Enum.GetValues(typeof(Suit)).Cast<Suit>().ToList();

        public int Rank { get; }
        public Suit Suit { get; }

        public Card(int rank, Suit suit)
        {
            if (rank < 2 || rank > 14)
            {
                throw new Exception("Rank out of range");
            }

            Rank = rank;
            Suit = suit;
        }

        public static List<Card> GetFullDeck()
        {
            var deck = new List<Card>();

            foreach (var suit in Suits)
            {
                foreach (int rank in Ranks)
                {
                    deck.Add(new Card(rank, suit));
                }
            }

            return deck;
        }

        public override string ToString()
        {
            return $"{GetRankString()} of {Suit.ToString()}";
        }

        public string GetRankString()
        {
            if (Rank < 11)
            {
                return Rank.ToString();
            }

            switch (Rank)
            {
                case 11: return "J";
                case 12: return "Q";
                case 13: return "K";
                default: return "A";
            }
        }
    }
}