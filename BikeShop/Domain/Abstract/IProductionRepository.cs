using System.Linq;
using Domain.Production;

namespace Domain.Abstract
{
    public interface IProductionRepository
    {
        IQueryable<Product> Products { get; }
    }
}
