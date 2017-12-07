using System.ComponentModel.DataAnnotations;

namespace PolicyManagement.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name ="Customer's first name")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="First name may not be blank")]
        public string FirstName { get; set; } //I decided to split these into first and last name

        [Display(Name ="Last name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name may not be blank")]
        public string LastName { get; set; }

        [Display(Name ="Customer")]
        public string CustomerName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        [Display(Name ="Customer address")]
        public Address CustomerAddress { get; set; }
    }
}