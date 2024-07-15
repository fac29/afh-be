namespace afh_api.DTOs
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }

    public class AddUserDto 
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? HashedPassword { get; set; }
    }
}
