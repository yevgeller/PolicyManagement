using System.ComponentModel.DataAnnotations;

namespace PolicyManagement.Models
{
    public enum ConstructionType {
        [Display(Name ="Site Built Home")]
        SiteBuiltHome =1,
        [Display(Name ="Modular Home")]
        ModularHome,
        [Display(Name ="Single Wide Manufactured Home")]
        SingleWideManufacturedHome,
        [Display(Name ="Double Wide Manufactured Home")]
        DoubleWideManufacturedHome
    };

    public class RiskEntity
    {
        public int Id { get; set; }

        [Display(Name ="Type of construction")]
        [Required(AllowEmptyStrings = false)]
        [Range(1, 9, ErrorMessage = "Please select a type of construction")]
        public ConstructionType RiskConstruction { get; set; }

        [Display(Name ="Year built")]
        [Required(AllowEmptyStrings = false)]
        public int YearBuilt { get; set; }  //YearBuilt could be a string type variable. 
                                            //What if the year is not known for sure, such as old buildings? So, something like 1775-1777, 
                                            //for example. But keeping it simple for this code example.
        [Display(Name ="Risk address")]
        public Address RiskAddress { get; set; }
    }
}