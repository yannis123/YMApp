using System.ComponentModel.DataAnnotations;

namespace YMApp.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}