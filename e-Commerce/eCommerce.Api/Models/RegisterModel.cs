using System.ComponentModel.DataAnnotations;
public class RegisterModel
{
    // Make Name property optional since it doesn't exist in the database
    //[Required]
    public string? Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    public string Role { get; set; }
}
