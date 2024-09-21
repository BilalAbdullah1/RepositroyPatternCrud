using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace newproj.Models
{
    public class Users
    {
        [Key]
        public int userId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
    }
}
