namespace SoilMatesDB
{
    /// <summary>
    /// Interface facad for repository interfaces for all models
    /// </summary>
    public interface IRepository : ICustomerRepo, ILocationRepo, IManagerRepo, IOrdersRepo, IProductRepo, IIventoryRepo, IOrderProduct
    {

    }
}