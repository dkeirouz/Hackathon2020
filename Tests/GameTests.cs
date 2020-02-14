using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon2020
{
    public class GameTests
    {
        [Test]
        public void TestGame_WarShouldRepeat()
        {
            var deck =
            new List<Card>{
                new Card(8, Suit.Clubs),
                new Card(2, Suit.Clubs),
                new Card(3, Suit.Clubs),
                new Card(4, Suit.Clubs),
                new Card(5, Suit.Clubs),
                new Card(6, Suit.Clubs),
            };

            var player1 = new Player(deck);
            deck.Add(new Card(7, Suit.Clubs));
            var player2 = new Player(deck);

            Program.RunOneRound(player1, player2);
        }
    }
}
