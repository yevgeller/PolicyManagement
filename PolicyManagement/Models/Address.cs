using System.ComponentModel.DataAnnotations;

namespace PolicyManagement.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Display(Name="Address")]
        [Required(AllowEmptyStrings = false)]
        public string AddressLine1 { get; set; } //Could probably put Address Line 2 and so on, but keeping this simple
        [Required(AllowEmptyStrings = false)]
        public string City { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string State { get; set; }

        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        public string Zip { get; set; }
    }
}

/* This is, of course, a simplified example, but if I may suggest 
 * as far as address for the insurance purposes -- just the mailing address may not work.
 * 
 * As an example, let's take the National Flood Insurance Policy. Each individual building,
 * sizes from 1m x 1m (2.5ft x 2.5 ft roughly) needs its own policy.
 * To mitigate this, there are currently databases being built that can help better identify 
 * buildings. The National Address Database is one of the examples of such efforts.
 *
 * Also, I suggest adding another way to identify a property, such as the United States National Grid.
 * That system is versatile and can identify a point on a map with a high degree of precision.
 * It should be used as a secondary means of location identification. Address should still be the primary
 * way to identify location since everyone understands it.
 */