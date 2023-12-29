namespace AoC2023.Day04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class Day4
    {
        private string ReadInputFromFile()
        {
            string expectedInputFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "Day04", "input.txt");
            if (!File.Exists(expectedInputFile))
            {
                throw new Exception("Could not find input file.");
            }

            using (var reader = new StreamReader(expectedInputFile))
            {
                return reader.ReadToEnd();
            }
        }

        public int SumValueOfCards(string? overrideInput)
        {
            if (overrideInput == null) { overrideInput = this.ReadInputFromFile(); }
            var values = GetCardValues(overrideInput);
            return values.Sum();
        }

        public int CountAllScratchCards(string? overrideInput)
        {
            var cards = new List<Card>();
            for (int i = 1; i <= 223; i++)
            {
                cards.Add(new Card { CardId = i });
            }

            if (overrideInput == null) { overrideInput = this.ReadInputFromFile(); }

            var resultCards = this.GetCardsWithCopiesForWinners(overrideInput, cards);

            return resultCards.Sum(c => c.Copies);
        }

        public IEnumerable<int> GetCardValues(string input)
        {
            var result = new List<int>();

            var cards = input.Replace("  ", " ").Split(Environment.NewLine);
            foreach (var card in cards)
            {
                string cardIdString = card.Split(':')[0].Split(' ')[1];
                string winningNumbersString = card.Split(':')[1].Split('|')[0];
                string cardNumbersString = card.Split('|')[1];

                var winningNumbers = winningNumbersString.Trim().Split(' ').Select(s => int.Parse(s));
                var cardNumbers = cardNumbersString.Trim().Split(' ').Select(s => int.Parse(s));
                int cardValue = 0;
                int matches = 0;
                foreach (var number in cardNumbers)
                {
                    if (winningNumbers.Contains(number))
                    {
                        matches++;
                        cardValue = cardValue == 0 ? 1 : cardValue * 2;
                    }
                }

                if (cardValue > 0)
                {
                    result.Add(cardValue);
                }
            }

            return result;
        }

        public IEnumerable<Card> GetCardsWithCopiesForWinners(string input, IEnumerable<Card> cards)
        {
            var result = new List<Card>();
            var cardsStrings = input.Replace("  ", " ").Split(Environment.NewLine);
            foreach (var cardString in cardsStrings)
            {
                string cardIdString = cardString.Split(':')[0].Split(' ').Last();
                var card = cards.Single(c => c.CardId == int.Parse(cardIdString));
                card.Copies++;

                string winningNumbersString = cardString.Split(':')[1].Split('|')[0];
                string cardNumbersString = cardString.Split('|')[1];

                var winningNumbers = winningNumbersString.Trim().Split(' ').Select(s => int.Parse(s));
                var cardNumbers = cardNumbersString.Trim().Split(' ').Select(s => int.Parse(s));
                int cardValue = 0;
                int matches = 0;
                foreach (var number in cardNumbers)
                {
                    if (winningNumbers.Contains(number))
                    {
                        matches++;
                        cardValue = cardValue == 0 ? 1 : cardValue * 2;
                    }
                }

                card.CardPoints = cardValue;

                if (matches > 0)
                {
                    for (int i = card.CardId + 1 ; i <= card.CardId + matches; i++)
                    {
                        var nextCard = cards.Single(c => c.CardId == i);
                        nextCard.Copies += card.Copies;
                    }
                }

                result.Add(card);
            }

            return result;
        }
    }

    public class Card
    {
        public int CardId { get; set; }
        public int CardPoints { get; set; }
        public int Copies { get; set; }
    }
}
