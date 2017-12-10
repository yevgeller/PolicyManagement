using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PolicyManagement.Models
{
    public class Policy : IValidatableObject
    {
        public int Id { get; set; } //PolicyNumber will most likely be unique, but I'm playing it safe because I don't have anyone to ask about the business rules

        [Display(Name="Policy number")]
        [Required(AllowEmptyStrings = false)]
        public string PolicyNumber { get; set; } //just so that the policy number is not limited to numeric

        [Display(Name ="Effective date")]
        [Required(AllowEmptyStrings = false)]
        public DateTime EffectiveDate { get; set; }

        [Display(Name ="Expires on")]
        [Required(AllowEmptyStrings = false)]
        public DateTime ExpirationDate { get; set; }

        [Required(AllowEmptyStrings = false)]
        public Customer InsuredCustomer { get; set; }

        [Required(AllowEmptyStrings = false)]
        public RiskEntity InsuredRiskEntity { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(EffectiveDate > ExpirationDate)
            {
                yield return new ValidationResult("Policy Effective Date must be before the End Date.");
            }
        }
    }
}