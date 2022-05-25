using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class ModifRepo : RepoCRUDBase<Mdification>, IModifRepo
    {
        public ModifRepo(dipContext context) : base(context)
        {
        }

        public IEnumerable<CharacteristicsModification> GetCharacteristicsIdsByModificationsId(int id)
        {
            return _context.CharacteristicsModifications.Where(x => x.ModificationId == id);
        }

        public override void Update(int id, Mdification model)
        {
            Mdification temp = GetById(id);

            temp.Name = model.Name;
            temp.ClothesId = model.ClothesId;
            temp.PriceFactor = model.PriceFactor;
            temp.Count = model.Count;

            _context.Mdifications.Update(temp);
        }
    }
}
