﻿using Application.Interfaces;

namespace Application.Sales.Queries.GetSaleDetail
{
    public class GetSaleDetailQuery : IGetSaleDetailQuery
    {
        private readonly IDatabaseService database;

        public GetSaleDetailQuery(IDatabaseService database)
        {
            this.database = database;
        }

        public SaleDetailModel Execute(int saleId)
        {
            var sale = this.database.Sales
                .Where(p => p.Id == saleId)
                .Select(p => new SaleDetailModel()
                {
                    Id = p.Id,
                    Date = p.Date,
                    CustomerName = p.Customer.Name,
                    EmployeeName = p.Employee.Name,
                    ProductName = p.Product.Name,
                    UnitPrice = p.UnitPrice,
                    Quantity = p.Quantity,
                    TotalPrice = p.TotalPrice
                })
                .Single();

            return sale;
        }
    }
}
