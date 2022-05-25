using DataBaseService.Models;

namespace DataBaseService.Data
{

    public class CharacteristicsModificationRepo : RepoCRUDBase<CharacteristicsModification>, ICharacteristicsModificationRepo
    {
        public CharacteristicsModificationRepo(dipContext context) : base(context)
        {
        }


        public override void Update(int id, CharacteristicsModification model)
        {
            CharacteristicsModification? g = _context.CharacteristicsModifications.Where(x => x.Id == id).FirstOrDefault();
            if (g == null) throw new ArgumentOutOfRangeException(nameof(id));
            g.CharacteristicsValueId = model.CharacteristicsValueId;
            g.ModificationId = model.ModificationId;
            _context.Update(g);
        }
    }
}
