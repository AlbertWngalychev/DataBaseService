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
    public class ModifController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IModifRepo _repo;

        public ModifController(
            IMapper mapper,
            ILoggerManager logger,
            IModifRepo repo)
        {
            _mapper = mapper;
            _logger = logger;
            _repo = repo;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<ModifReadDto> Get(int id)
        {
            if (id <= 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById:{id} Bad Request");
                return BadRequest();
            }

            Mdification? t = _repo.GetById(id);

            if (t == null)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById:{id} Not found");
                return NotFound();
            }

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById:{id} OK");
            return Ok(_mapper.Map<ModifReadDto>(t));
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Post(ModifCreateDto dto)
        {
            try
            {
                _repo.Create(_mapper.Map<Mdification>(dto));
                _repo.SaveChanges();

                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Create {dto.Name},  Ok");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.Create {dto.Name}. {ex.Message}");
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id, ModifCreateDto dto)
        {
            if (_repo.GetById(id) == null)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.UpdateById:{id} not found");
                return NotFound();
            }


            try
            {
                _repo.Update(id, _mapper.Map<Mdification>(dto));
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
            if (id < 0)
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

        [HttpGet("{id}/characteristics")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<CharacteristicsModificationsReadDto>> GetCharacteristicsIdsByModificationsId(int id)
        {
            var listModels = _repo.GetCharacteristicsIdsByModificationsId(id).ToList();
            if (listModels.Count == 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetAllByModifId  Not Found");
                return NotFound();
            }

            List<CharacteristicsModificationsReadDto> list = new();
            foreach (var item in listModels)
                list.Add(_mapper.Map<CharacteristicsModificationsReadDto>(item));

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetAllByModifId  Ok");
            return Ok(list);
        }


    }
}