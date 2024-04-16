using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class CustomerService
    {
        private readonly ITravelAgencyRepository<Customer> CustomerRepository;
        public List<Customer> GetByName(string name)
        {
            return CustomerRepository.GetAll().Where(c => c.Name == name).ToList();
        }
        public List<Customer> GetBySurname(string surname)
        {
            return CustomerRepository.GetAll().Where(c => c.Surname == surname).ToList();
        }
        public void AddCustomer(Customer customer)
        {
            CustomerRepository.AddItem(customer);
        }
        public void UpdateCustomer(Customer customer)
        {
            CustomerRepository.UpdateItem(customer);
        }
        public void DeleteCustomer(int id)
        {
            CustomerRepository.DeleteItem(id);
        }
    }
}
