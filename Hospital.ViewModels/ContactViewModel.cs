using Hospital.Models;

namespace Hospital.ViewModels
{
    public class ContactViewModel
    {
        public Contact Contact { get; set; }
        public List<KeyValuePair<int, string>> Hospitals { get; set; } = new();
    }
}
