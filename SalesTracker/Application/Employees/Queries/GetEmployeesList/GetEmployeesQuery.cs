using Application.Interfaces;

namespace Application.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQuery : IGetEmployeesListQuery
    {
        private readonly IDatabaseService database;

        public GetEmployeesListQuery(IDatabaseService database)
        {
            this.database = database;
        }

        public List<EmployeeModel> Execute()
        {
            var employees = this.database.Employees
                .Select(p => new EmployeeModel
                {
                    Id = p.Id,
                    Name = p.Name
                });

            return employees.ToList();
        }
    }
}
