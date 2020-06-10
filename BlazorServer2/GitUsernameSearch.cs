using System.ComponentModel.DataAnnotations;

namespace BlazorServer2
{
    public class GitUsernameSearch
    {
        [Required]
        [StringLength(15, ErrorMessage = "username is too long")]
        [RegularExpression("^[A-Za-z0-9_$]+$", ErrorMessage = "Not a valid github username")]
        public string Username { get; set; }
    }
}
