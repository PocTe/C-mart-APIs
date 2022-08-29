namespace C_mart_APIs.Model
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string lastname { get; set; }
        public string Email { get; set; }
        public Guid Id { get; internal set; }
    }
}
