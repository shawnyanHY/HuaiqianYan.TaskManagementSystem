using System;
using System.ComponentModel.DataAnnotations;


namespace ApplicationCore.Models
{
    public class UserRequestModel
    {
        [Required(ErrorMessage = "Email cannot be empty.")]
        [EmailAddress(ErrorMessage = "Email should be in right format")]
        public string Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters and maximum of 10 characters long", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage =
            "Password Should have minimum 8 with at least one upper, lower, number and special character.")]
        public string Password { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        public string MobileNo { get; set; }
    }

    public class UserUpdateRequestModel
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters and maximum of 10 characters long", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$")]
        public string Password { get; set; }

        public string FullName { get; set; }

        public string MobileNo { get; set; }
    }

    public class TaskRequestModel
    {
        public int? UserId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public char? Priority { get; set; }

        public string Remarks { get; set; }
    }

    public class TaskUpdateRequestModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public char? Priority { get; set; }

        public string Remarks { get; set; }
    }

    public class TaskHistoryRequestModel
    {
        public int? UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? Completed { get; set; }

        public string Remarks { get; set; }
    }

    public class TaskHistoryUpdateRequestModel
    {
        public int TaskId{ get; set; }
        public int? UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? Completed { get; set; }

        public string Remarks { get; set; }
    }
}
