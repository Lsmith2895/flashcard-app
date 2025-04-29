using FlashCardApi.Models;

namespace FlashCardApi.Services
{
    public interface IFlashDeckService
    {
        FlashCard GetCurrentCard();
        void FlipCurrentCard();
        void SubmitAnswer(bool isCorrect);
        void MoveToNextCard();
        bool IsDeckEmpty();
    }
}
