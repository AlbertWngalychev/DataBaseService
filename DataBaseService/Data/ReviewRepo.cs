using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly dipContext _context;

        public ReviewRepo(dipContext context)
        {
            _context = context;
        }
        public void Create(Review review)
        {
            throw new NotImplementedException();
        }

        public Review? GetById(int id)
        {
            return _context.Reviews.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Review> GetReviewsByClientId(int clientId)
        {
            return _context.Reviews.Where(x => x.ClientId == clientId);
        }

        public void SaveChenges()
        {
            _context.SaveChanges();
        }

        public void Update(int id, Review newReview)
        {
            Review? old = GetById(id);
            if (old == null)
            {
                throw new ArgumentNullException(nameof(old));
            }
            old.Mark = newReview.Mark;
            old.Text = newReview.Text;
            old.Limitations = newReview.Limitations;
            old.Advantages = newReview.Advantages;
            _context.Update(old);
        }
    }
}
