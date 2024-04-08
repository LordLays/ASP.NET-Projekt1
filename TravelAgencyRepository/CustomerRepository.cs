using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class CustomerRepository : ITravelAgencyRepository<Customer>
    {
        private readonly TravelAgencyContext _context;
        public CustomerRepository(TravelAgencyContext context)
        {
            _context = context;
        }
        public void AddItem(Customer item)
        {
            _context.Customers.Add(item);
            _context.SaveChanges();
        }
        public void DeleteItem(int id)
        {
            var customer = GetById(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
        public Customer GetById(int id)
        {
            return _context.Customers.Find(id);
        }
        public IQueryable<Customer> GetAll()
        {
            return _context.Customers;
        }
        public void UpdateItem(Customer item)
        {
            _context.Customers.Update(item);
            _context.SaveChanges();
        }
    }
}
