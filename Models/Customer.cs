using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace WebApplication1.Models
{
    public class Customer
    {
        public uint IDCustomer { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
