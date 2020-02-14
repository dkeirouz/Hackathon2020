using System;
using System.Collections;
using System.Collections.Generic;

namespace Hackathon2020
{
    public class Player
    {
        public Queue<Card> deck;

        public Player(IEnumerable<Card> startingDeck)
        {
            deck = new Queue<Card>(startingDeck);
        }

        public Card GetNextCard()
        {
            if (deck.Count == 0)
            {
                throw new Exception("Empty hand");
            }

            return deck.Dequeue();
        }

        public void AddToHand(List<Card> pile)
        {
            foreach (var card in pile)
            {
                deck.Enqueue(card);
            }
        }

        public bool IsEmpty()
        {
            return deck.Count == 0;
        }


        public IEnumerable<Card> GetWarHand()
        {
            int maxWarHand = 3;
            var warHand = new List<Card>();
            while(deck.Count > 1 && warHand.Count < maxWarHand)
            {
                warHand.Add(deck.Dequeue());
            }
            return warHand;
        }
    }
}