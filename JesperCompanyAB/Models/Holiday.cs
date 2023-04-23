using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace JesperCompanyAB.Models
{
    public class Holiday
    {
        [Key]
        public int HolidayId { get; set; }
        [StringLength(maximumLength: 50)]
        [DisplayName("Absence Reason")]
        public string HolidayType { get; set; }
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        [DataType(DataType.Date)]
        public DateTime Stop { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime MadeAt { get; set; }
        [ValidateNever]
        [ForeignKey(name: "UserId")]
        public string FK_UserId { get; set; }
    }
}
