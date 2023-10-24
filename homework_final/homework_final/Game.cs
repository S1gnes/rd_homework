using System;
using System.Collections.Generic;
using System.Linq;

namespace homework_final
{
    public enum CurrentState
    {
        WaitingForDealer,
        WaitingForUserFirstCard,
        WaitingForUserCard,
        Ended
    }

    public class Game
    {
        private List<int> PlayerCards = new List<int>();
        private int DealerCard = 0;

        private int PlayerScore = 0;
        private int DealerScore = 0;

        public CurrentState state = CurrentState.WaitingForDealer;

        public void SetDealerCard(int card)
        {
            DealerCard = card;
            state = CurrentState.WaitingForUserFirstCard;
        }

        public void AddPlayerCard(int card)
        {
            if (PlayerCards.Count == 0)
            {
                state = CurrentState.WaitingForUserCard;
            }

            PlayerCards.Add(card);
        }

        public int GetPlayerScore()
        {
            return CalculateBlackjackScore(PlayerCards.ToArray());
        }

        public int GetDealerScore()
        {
            return DealerCard;
        }

        public string DetermineBestMove()
        {
            int playerScore = GetPlayerScore();
            int dealerScore = GetDealerScore();

            if (playerScore > 21)
            {
                return "Loose :(";
            }
            else if (playerScore == 21)
            {
                return "Blackjack!";
            }
            else if (playerScore >= 17)
            {
                return "Stop";
            }
            else if (playerScore >= 12 && playerScore <= 16)
            {
                if (dealerScore >= 7)
                {
                    return "Stop";
                }
                else
                {
                    return "Take";
                }
            }
            else if (playerScore >= 9 && playerScore <= 11)
            {
                return "DoubleDown";
            }
            else
            {
                return "Take";
            }
        }

        private int CalculateBlackjackScore(int[] cards)
        {
            int score = 0;
            int aceCount = 0;

            foreach (var card in cards)
            {
                if (card == 1)
                {
                    score += 11;
                    aceCount++;
                }
                else if (card >= 10 && card <= 13)
                {
                    score += 10;
                }
                else
                {
                    score += card;
                }
            }

            while (score > 21 && aceCount > 0)
            {
                score -= 10;
                aceCount--;
            }

            return score;
        }
    }
}