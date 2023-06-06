using System.ComponentModel.DataAnnotations;

namespace e_commerce.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}