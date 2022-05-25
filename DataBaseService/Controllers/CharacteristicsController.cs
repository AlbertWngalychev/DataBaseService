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
    public class CharacteristicsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly ICharacteristicsRepo _repo;

        public CharacteristicsController(
            IMapper mapper,
            ILoggerManager logger,
            ICharacteristicsRepo repo)
        {
            _mapper = mapper;
            _logger = logger;
            _repo = repo;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<SimpleElementReadDto> Get(int id)
        {
            if (id <= 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById:{id} Bad Request");
                return BadRequest();
            }

            Chatacteristic? t = _repo.GetById(id);

            if (t == null)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById:{id} Not found");
                return NotFound();
            }

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById:{id} OK");
            return Ok(_mapper.Map<SimpleElementReadDto>(t));
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Post(string name)
        {
            try
            {
                _repo.Create(new() { Name = name });
                _repo.SaveChanges();

                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Create {name}  Ok");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.Create {name}. {ex.Message}");
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id, string name)
        {
            if (_repo.GetById(id) == null)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.UpdateById:{id} not found");
                return NotFound();
            }


            try
            {
                _repo.Update(id, new() { Name = name });
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

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<SimpleElementReadDto>> GetAll()
        {
            var listModels = _repo.GetCharacteristics().ToList();
            if (listModels.Count == 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetCharacteristics  Not Found");
                return NotFound();
            }

            List<SimpleElementReadDto> list = new();
            foreach (var item in listModels)
                list.Add(_mapper.Map<SimpleElementReadDto>(item));

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetCharacteristics  Ok");
            return Ok(list);
        }


    }
}