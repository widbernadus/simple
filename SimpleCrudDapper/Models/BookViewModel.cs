using System.ComponentModel.DataAnnotations;

namespace SimpleCrudDapper.Models
{
    public class BookViewModel
    {
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string author { get; set; }
        [Required]
        public string year { get; set; }
        [Required]
        public string publisher { get; set; }
        public int ref_genre_id { get; set; }
    }
}
