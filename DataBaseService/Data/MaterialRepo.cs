using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class MaterialRepo : RepoCRUDBase<Material>, IMaterialRepo
    {
        public MaterialRepo(dipContext context) : base(context)
        {
        }

        public IEnumerable<Material> GetMaterialByClothesId(int id)
        {
            return _context.Materials.Where(x => x.ClothesId == id);
        }

        public override void Update(int id, Material model)
        {
            Material? old = GetById(id);
            if (old == null)
            {
                throw new ArgumentNullException(nameof(old));
            }
            old.ClothesId = model.ClothesId;
            old.ClothId = model.ClothId;
            old.Count = model.Count;

            _context.Update(old);
        }
    }
}
