using System;
using System.ComponentModel.DataAnnotations;

namespace BestQA.Web.Models
{
    public partial class QuestionModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Title { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Content { get; set; }
        public string  Tag { get; set; }
        public int Reward { get; set; }
    }
}
