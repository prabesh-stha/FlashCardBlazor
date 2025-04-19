using System.ComponentModel.DataAnnotations;

namespace FlashCardBlazor.Data
{
    public class FlashcardModel
    {
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }
        public FlashcardModel()
        {
            Question = string.Empty;
            Answer = string.Empty;
        }
    }
}
