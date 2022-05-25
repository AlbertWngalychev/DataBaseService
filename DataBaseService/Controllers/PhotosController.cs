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
    public class PhotosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IPhotoRepo _repo;

        public PhotosController(
            IMapper mapper,
            ILoggerManager logger,
            IPhotoRepo repo)
        {
            _mapper = mapper;
            _logger = logger;
            _repo = repo;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<PhotoReadDto> Get(int id)
        {
            if (id <= 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById:{id} Bad Request");
                return BadRequest();
            }

            Photo? t = _repo.GetById(id);

            if (t == null)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById:{id} Not found");
                return NotFound();
            }

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById:{id} OK");
            return Ok(_mapper.Map<PhotoReadDto>(t));
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Post(PhotoCreateDto dto)
        {
            var p = _mapper.Map<Photo>(dto);
            try
            {
                _repo.Create(p);
                _repo.SaveChanges();

                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Create {p.Path}  Ok");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.Create {p.Path}. {ex.Message}");
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id, PhotoCreateDto dto)
        {
            if (_repo.GetById(id) == null)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.UpdateById:{id} not found");
                return NotFound();
            }

            Photo p = _mapper.Map<Photo>(dto);
            try
            {
                _repo.Update(id, p);
                _repo.SaveChanges();

                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.UpdateById:{id} Ok");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.UpdateById:{id}. {ex.Message}");
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.DeleteById:{id} Bad Request");
                return BadRequest();
            }
            try
            {
                _repo.DeleteById(id);
                _repo.SaveChanges();


                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.DeleteById:{id} OK");
                return Ok();
            }
            catch (ArgumentNullException)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.DeleteById:{id} Not Found");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.DeleteById:{id} {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet("clotehs/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<PhotoReadDto>> GetAllByModifId(int id)
        {
            if (id < 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetAllByModifId:{id} Bad Request");
                return BadRequest();
            }
            var listModels = _repo.GetAllByModifId(id).ToList();
            if (listModels.Count == 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetAllByModifId:{id} Not Found");
                return NotFound();
            }

            List<PhotoReadDto> list = new();
            foreach (var item in listModels)
                list.Add(_mapper.Map<PhotoReadDto>(item));

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetAllByModifId:{id} Ok");
            return Ok(list);
        }


    }
}