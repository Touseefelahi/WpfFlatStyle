namespace FlatStyle.Sample
{
    public class Dataset
    {
        public Dataset(string firstName, string lastName, string email, string gender, string ip)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
            Ip = ip;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Ip { get; set; }
    }
}