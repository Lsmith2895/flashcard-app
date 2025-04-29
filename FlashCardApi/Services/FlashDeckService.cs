using FlashCardApi.Models;

namespace FlashCardApi.Services
{
    public class FlashDeckService : IFlashDeckService
    {
        private readonly Queue<FlashCard> _cards = new();
        private FlashCard? _currentCard;

        public FlashDeckService()
        {
            // Initialize deck with some sample cards
            _cards.Enqueue(new FlashCard("What is the capital of France?", "Paris"));
            _cards.Enqueue(new FlashCard("What is 2 + 2?", "4"));
            _cards.Enqueue(new FlashCard("What color is the sky?", "Blue"));
            
            MoveToNextCard(); // Load the first card
        }

        public FlashCard GetCurrentCard()
        {
            if (_currentCard == null)
            {
                throw new InvalidOperationException("No cards available.");
            }

            return _currentCard;
        }

        public void FlipCurrentCard()
        {
            if (_currentCard == null)
            {
                throw new InvalidOperationException("No current card to flip.");
            }

            _currentCard.Flip();
        }

        public void SubmitAnswer(bool isCorrect)
        {
            if (!isCorrect && _currentCard != null)
            {
                // If wrong, re-add the card to the end of the queue
                _currentCard.ResetFlip(); // Reset flip so it's front side when user sees it again
                _cards.Enqueue(_currentCard);
            }
        }

        public void MoveToNextCard()
        {
            if (_cards.Any())
            {
                _currentCard = _cards.Dequeue();
                _currentCard.ResetFlip();
            }
            else
            {
                _currentCard = null;
            }
        }

        public bool IsDeckEmpty()
        {
            return _currentCard == null && !_cards.Any();
        }
    }
}
