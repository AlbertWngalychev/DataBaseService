using DataBaseService.Models;

namespace DataBaseService.Data
{
    public interface IReviewRepo
    {
        void SaveChenges();
        void Create(Review review);
        void Update(int id, Review newReview);
        Review? GetById(int id);
        IEnumerable<Review> GetReviewsByClientId(int clientId);
    }
}
