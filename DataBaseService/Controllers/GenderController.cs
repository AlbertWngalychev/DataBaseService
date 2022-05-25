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
    public class GenderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IGenderRepo _repo;

        public GenderController(
            IMapper mapper,
            ILoggerManager logger,
            IGenderRepo repo)
        {
            _mapper = mapper;
            _logger = logger;
            _repo = repo;
        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<SimpleElementReadDto>> Get()
        {
            List<Gender> gendersModel = _repo.GetAll().ToList();
            if (gendersModel.Count == 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetAll  Not found");
                return NotFound(new List<TypeReadDto>());
            }

            var dtos = new List<SimpleElementReadDto>();
            foreach (var type in gendersModel)
                dtos.Add(_mapper.Map<SimpleElementReadDto>(type));

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetAll OK");
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult<SimpleElementReadDto> Details(int id)
        {
            if (id < 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.DetailsId:{id} < 0 BadRequest");
                return BadRequest();
            }

            Gender? temp = _repo.GetById(id);
            if (temp == null)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.DetailsId:{id} Not found");
                return NotFound();
            }

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.DetailsId:{id} Ok");
            return Ok(_mapper.Map<SimpleElementReadDto>(temp));
        }

        [HttpPost("name")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult Create(string name)
        {
            try
            {

                _repo.Create(new Gender() { Name = name });
                _repo.SaveChanges();


                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Create:{name} Ok");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.Create:{name}. {ex.Message}");
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult Update(int id, string name)
        {
            try
            {

                _repo.Update(id, new Gender() { Name = name });
                _repo.SaveChanges();


                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Update:{name} Ok");
                return Ok();
            }
            catch (ArgumentOutOfRangeException)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.Update:{name} Not found");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.Update:{name}. {ex.Message}");
                return BadRequest();
            }
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Delete:{id} < 0");
                return BadRequest();
            }

            try
            {

                _repo.DeleteById(id);
                _repo.SaveChanges();


                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Delete:{id} Ok");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.Delete:{id}. {ex.Message}");
                return BadRequest();
            }
        }

    }
}
