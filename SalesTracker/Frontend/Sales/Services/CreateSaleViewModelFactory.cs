using Application.Customers.Queries.GetCustomerList;
using Application.Employees.Queries.GetEmployeesList;
using Application.Products.Queries.GetProductsList;
using Application.Sales.Commands.CreateSale;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Sales.Models;

namespace Presentation.Sales.Services
{
    public class CreateSaleViewModelFactory : ICreateSaleViewModelFactory
    {
        private readonly IGetCustomersListQuery customersQuery;
        private readonly IGetEmployeesListQuery employeesQuery;
        private readonly IGetProductsListQuery productsQuery;

        public CreateSaleViewModelFactory(
            IGetCustomersListQuery customersQuery,
            IGetEmployeesListQuery employeesQuery,
            IGetProductsListQuery productsQuery)
        {
            this.customersQuery = customersQuery;
            this.employeesQuery = employeesQuery;
            this.productsQuery = productsQuery;
        }

        public CreateSaleViewModel Create()
        {
            var employees = this.employeesQuery.Execute();

            var customers = this.customersQuery.Execute();

            var products = this.productsQuery.Execute();

            var viewModel = new CreateSaleViewModel();

            viewModel.Employees = employees
                .Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToList();

            viewModel.Customers = customers
                .Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToList();

            viewModel.Products = products
                .Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = p.Name + " ($" + p.UnitPrice + ")"
                })
                .ToList();

            viewModel.Sale = new CreateSaleModel();

            return viewModel;
        }
    }
}
