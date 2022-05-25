using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class PhotoRepo : RepoCRUDBase<Photo>, IPhotoRepo
    {
        public PhotoRepo(dipContext context) : base(context)
        {
        }

        public IEnumerable<Photo> GetAllByModifId(int id)
        {
            return _context.Photos.Where(x => x.ModificationId == id);
        }

        public override void Update(int id, Photo model)
        {
            Photo? old = GetById(id);
            if (old == null)
            {
                throw new ArgumentNullException(nameof(old));
            }
            old.Priopity = model.Priopity;
            old.Path = model.Path;
            old.ModificationId = model.ModificationId;

            _context.Update(old);
        }
    }
}
