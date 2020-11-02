namespace SoilMatesDB
{
    public interface IRepository : ICustomerRepo, ILocationRepo, IManagerRepo, IOrdersRepo, IProductRepo, IIventoryRepo, IOrderProduct
    {
        void SaveChanges();

    }
}