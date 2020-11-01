namespace SoilMatesDB
{
    public interface IRepository : ICustomerRepo, ILocationRepo, IManagerRepo, IOrdersRepo, IProductRepo, IIventoryRepo
    {
        void SaveChanges();

    }
}