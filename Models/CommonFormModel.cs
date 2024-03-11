namespace ocian_net.Models
{
    public class CommonFormModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public CommonFormModel(string name, string email, string phone, string subject, string message)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Subject = subject;
            Message = message;
        }
    }
}