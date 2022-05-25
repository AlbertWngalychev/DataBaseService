using DataBaseService.Models;

namespace DataBaseService.Data
{
    public interface IPriceRepo : ICRUD<Price>, ISaveChanges
    {
        IEnumerable<Price> GetPrices();

        IEnumerable<Price> GetPricesByClothesId(int id);

    }
}
