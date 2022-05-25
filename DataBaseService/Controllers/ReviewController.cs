using AutoMapper;
using DataBaseService.Data;
using DataBaseService.Dtos;
using DataBaseService.Logger;
using DataBaseService.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepo _repo;
        private readonly ILoggerManager _logger;

        public ReviewController(
            ILoggerManager logger,
            IReviewRepo repo,
            IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<ReviewReadDto> GetById(int id)
        {
            if (id < 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById {id} < 0");
                return BadRequest();
            }
            Review? reviewModel = _repo.GetById(id);
            if (reviewModel == null)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById {id} NotFound");
                return NotFound();
            }
            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById {id} Ok");
            return Ok(_mapper.Map<ReviewReadDto>(reviewModel));
        }

        [HttpGet("client/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<ReviewReadDto>> GetByClientId(int id)
        {
            List<Review> models = _repo.GetReviewsByClientId(id).ToList();
            if (models.Count <= 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetByClientId not fount id:{id}");
                return NotFound();
            }


            List<ReviewReadDto> dtos = new List<ReviewReadDto>();
            foreach (Review model in models)
                dtos.Add(_mapper.Map<ReviewReadDto>(model));



            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetByClientId {id} OK");
            return Ok(dtos);


        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Create(ReviewCreateDto review)
        {
            try
            {
                _repo.Create(_mapper.Map<Review>(review));
                _repo.SaveChenges();

                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Create for client:{review.ClientId}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.Create for client:{review.ClientId}. {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPut("id")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Update(int id, ReviewCreateDto review)
        {

            if (_repo.GetById(id) == null)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Update id:{id} not found");
                return NotFound();
            }

            Review newReview = _mapper.Map<Review>(review);
            try
            {
                _repo.Update(id, newReview);
                _repo.SaveChenges();

                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Update id:{id}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.Update id:{id}. {ex.Message}");
                return BadRequest();
            }
        }
    }
}
