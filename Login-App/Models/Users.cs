using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Login_App.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
