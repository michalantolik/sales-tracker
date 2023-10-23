using Application.Interfaces;

namespace Application.Customers.Queries.GetCustomerList
{
    public class GetCustomersListQuery : IGetCustomersListQuery
    {
        private readonly IDatabaseService database;

        public GetCustomersListQuery(IDatabaseService database)
        {
            this.database = database;
        }

        public List<CustomerModel> Execute()
        {
            var customers = this.database.Customers
                .Select(p => new CustomerModel()
                {
                    Id = p.Id,
                    Name = p.Name
                });

            return customers.ToList();
        }
    }
}
