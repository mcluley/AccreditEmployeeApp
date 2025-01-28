using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeShared.Models
{
    public class Status
    {
        [Key]
        [DisplayName("Status ID")]
        public int StatusID { get; set; }

        [RegularExpression(@"^([a-zA-Z \.\&\'\-]+)$", ErrorMessage = "{0} must be characters only")]
        [StringLength(15, ErrorMessage = "{0} cannot be longer than 15 characters.")]
        [DisplayName("Status Description")]
        public string StatusDescription { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}
