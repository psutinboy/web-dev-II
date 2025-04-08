public class UserDto
{
    public int? Id { get; set; }
    // Name property doesn't exist in the database table
    // public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Role { get; set; }
}