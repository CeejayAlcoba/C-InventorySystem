using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IProductHistoryRepository ProductHistories { get; }
        IBrandRepository Brands { get; }
        ICategoryRepository Categories { get; }
        IColourRepository Colours { get; }
        ICustomerRepository Customers { get; }
        ILocationRepository Locations { get; }
        IProductRepository Products { get; }
        IPurchaseOrderItemRepository PurchaseOrderItems { get; }
        IPurchaseOrderRepository PurchaseOrders { get; }
        IPurchaseReceiptRepository PurchaseReceipts { get; }
        IPurchaseReturnRepository PurchaseReturns { get; }
        ISalesChannelRepository SalesChannels { get; }
        ISalesDeliveryRepository SalesDeliveries { get; }
        ISalesOrderRepository SalesOrders { get; }
        ISalesOrderItemRepository SalesOrderItems { get; }
        ISalesReturnRepository SalesReturns { get; }
        IShipperRepository Shippers { get; }
        ISizeRepository Sizes { get; }
        IUomRepository Uoms { get; }
        ISupplierRepository Suppliers { get; }
        int Complete();
    }
}
