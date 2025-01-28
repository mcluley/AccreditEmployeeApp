using System.ComponentModel.DataAnnotations;

namespace EmployeeMVC.Enums
{
    public class EmployeeAppEnums
    {
        public enum Message
        {
            [Display(Name = "Success Message")]
            SuccessMessage = 1,

            [Display(Name = "Info Message")]
            InfoMessage = 2,

            [Display(Name = "Warning Message")]
            WarningMessage = 3,

            [Display(Name = "Error Message")]
            ErrorMessage = 4
        }
    }
}