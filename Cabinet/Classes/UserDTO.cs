using System.ComponentModel.DataAnnotations;

namespace Cabinet.Classes
{
    public class LoginDTO
    {

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }

    public class UserDTO : LoginDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Role { get; set; }

        public List<long>? Neighborhoods { get; set; }


    }
}
