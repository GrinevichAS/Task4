namespace PL.Models
{
    public class ManagerModel
    {
        public string LastName { get; set; }

        public ManagerModel(string lastName)
        {
            LastName = lastName;
        }
    }
}