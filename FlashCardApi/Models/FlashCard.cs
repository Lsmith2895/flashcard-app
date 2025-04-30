namespace FlashCardApi.Models
{
    public class FlashCard
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Front { get; set; } = string.Empty; // question side

        public string Back { get; set; } = string.Empty; // answer side

        public bool IsFlipped { get; set; } = false;

        public FlashCard() { }

        public FlashCard(string front, string back)
        {
            Front = front;
            Back = back;
        }

        public void Flip()
        {
            IsFlipped = !IsFlipped;
        }

        public void ResetFlip()
        {
            IsFlipped = false;
        }
    }
}
