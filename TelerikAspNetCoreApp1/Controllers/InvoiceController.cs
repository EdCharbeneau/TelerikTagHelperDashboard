using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace TelerikAspNetCoreApp1.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly NorthwindDBContext db;

        public InvoiceController(NorthwindDBContext context)
        {
            db = context;
        }
        public ActionResult Invoices_Read([DataSourceRequest]DataSourceRequest request,
            string salesPerson,
            DateTime statsFrom,
            DateTime statsTo)
        {
            var invoices = db.Invoices.Where(inv => inv.Salesperson == salesPerson)
                .Where(inv => inv.OrderDate >= statsFrom && inv.OrderDate <= statsTo);
            DataSourceResult result = invoices.ToDataSourceResult(request, invoice => new
            {
                invoice.OrderID,
                invoice.CustomerName,
                invoice.OrderDate,
                invoice.ProductName,
                invoice.UnitPrice,
                invoice.Quantity,
                invoice.Salesperson
            });

            return Json(result);
        }
    }
}