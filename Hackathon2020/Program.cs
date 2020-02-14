using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackathon2020
{
    public class Program
    {
        static void Main(string[] args)
        {
            RunGame();
        }

        private static void RunGame()
        {
            var deck = Card.GetFullDeck();
            deck = Randomize(deck);

            var player1 = new Player(deck.GetRange(0, 26));
            var player2 = new Player(deck.GetRange(26, 26));

            bool isFinished = false;
            while (!isFinished)
            {
                Console.WriteLine("Player 1 Deck: " + String.Join(',',player1.deck.ToList().Select(x => x.Rank.ToString())));
                Console.WriteLine("Player 2 Deck: " + String.Join(',', player2.deck.ToList().Select(x => x.Rank.ToString())));
                isFinished = RunOneRound(player1, player2);
            }

            if (player1.IsEmpty())
            {
                Console.WriteLine("Player 2 wins!");
            }
            else
            {
                Console.WriteLine("Player 1 wins!");
            }

        }

        public static bool RunOneRound(Player player1, Player player2)
        {
            RunWarRecursively(player1, player2, new List<Card>());

            Console.WriteLine();
            return player1.IsEmpty() || player2.IsEmpty();
        }

        private static void RunWarRecursively(Player player1, Player player2, List<Card> inPlay)
        {
            var player1Card = player1.GetNextCard();
            var player2Card = player2.GetNextCard();
            Console.WriteLine($"Player 1: {player1Card}");
            Console.WriteLine($"Player 2: {player2Card}");
            inPlay.Add(player1Card);
            inPlay.Add(player2Card);

            if (player1Card.Rank > player2Card.Rank)
            {
                Console.WriteLine($"Player 1 wins round!");
                player1.AddToHand(inPlay);
            }
            else if (player1Card.Rank < player2Card.Rank)
            {
                Console.WriteLine($"Player 2 wins round!");
                player2.AddToHand(inPlay);
            }
            else
            {
                HandleTie(player1, player2, inPlay);
            }
        }

        private static void HandleTie(Player player1, Player player2, List<Card> inPlay)
        {
            Console.WriteLine("War!");

            // handle last card war edge case
            if (player1.IsEmpty())
            {
                Console.WriteLine("Player 1 wins by default!");
                player1.AddToHand(inPlay);
                return;
            }
            if (player2.IsEmpty())
            {
                Console.WriteLine("Player 2 wins by default!");
                player2.AddToHand(inPlay);
                return;
            }

            inPlay.AddRange(player1.GetWarHand());
            inPlay.AddRange(player2.GetWarHand());
            RunWarRecursively(player1, player2, inPlay);
        }

        public static List<T> Randomize<T>(List<T> source)
        {
            Random rnd = new Random();
            return source.OrderBy<T, int>((item) => rnd.Next()).ToList();
        }
    }
}
