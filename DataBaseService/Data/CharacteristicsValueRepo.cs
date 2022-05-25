
using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class CharacteristicsValueRepo : RepoCRUDBase<ChatacteristicsValue>, ICharacteristicsValueRepo
    {
        public CharacteristicsValueRepo(dipContext context) : base(context)
        {
        }

        public override void Update(int id, ChatacteristicsValue model)
        {
            ChatacteristicsValue? temp = GetById(id);
            if (temp == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            temp.ValueId = model.Id;
            temp.CharacteristicsId = model.CharacteristicsId;

            _context.ChatacteristicsValues.Update(temp);
        }
    }
}
