using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace JesperCompanyAB.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [ValidateNever]
        [ForeignKey(name:"UserId")]
        public string FK_UserId { get; set; }
    }
}
