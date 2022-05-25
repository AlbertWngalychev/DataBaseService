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
    public class ClothesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IClothesRepo _repo;

        public ClothesController(
            IMapper mapper,
            ILoggerManager logger,
            IClothesRepo repo)
        {
            _mapper = mapper;
            _logger = logger;
            _repo = repo;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<ClothesReadDto> Get(int id)
        {
            if (id <= 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById:{id} Bad Request");
                return BadRequest();
            }


            Сlothe? t = _repo.GetById(id);

            if (t == null)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById:{id} Not found");
                return NotFound();
            }

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById:{id} OK");
            return Ok(_mapper.Map<ClothesReadDto>(t));
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Post(ClothesCreatDto dto)
        {
            var p = _mapper.Map<Сlothe>(dto);
            try
            {
                _repo.Create(p);
                _repo.SaveChanges();

                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Create {p.Name} {p.VendorCode}  Ok");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.Create {p.Name} {p.VendorCode}. {ex.Message}");
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id, ClothesCreatDto dto)
        {
            if (_repo.GetById(id) == null)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.UpdateById:{id} not found");
                return NotFound();
            }

            Сlothe p = _mapper.Map<Сlothe>(dto);
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

        [HttpGet("gender/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<ClothesReadDto>> GetClothesByGenderId(int id)
        {
            if (id < 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetClothesByGenderId:{id} Bad Request");
                return BadRequest();
            }
            var listModels = _repo.GetClothesByGenderId(id).ToList();
            if (listModels.Count == 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetClothesByGenderId:{id} Not Found");
                return NotFound();
            }

            List<ClothesReadDto> list = new();
            foreach (var item in listModels)
                list.Add(_mapper.Map<ClothesReadDto>(item));

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetClothesByGenderId:{id} Ok");
            return Ok(list);
        }

        [HttpGet("type/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<ClothesReadDto>> GetClothesByTypeId(int id)
        {
            if (id < 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetClothesByTypeId:{id} Bad Request");
                return BadRequest();
            }
            var listModels = _repo.GetClothesByTypeId(id).ToList();
            if (listModels.Count == 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetClothesByTypeId:{id} Not Found");
                return NotFound();
            }

            List<ClothesReadDto> list = new();
            foreach (var item in listModels)
                list.Add(_mapper.Map<ClothesReadDto>(item));

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetClothesByTypeId:{id} Ok");
            return Ok(list);
        }

        [HttpGet("{id}/modif")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<ModifReadDto>> GetMdifications(int id)
        {
            if (id < 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetMdifications:{id} Bad Request");
                return BadRequest();
            }
            var listModels = _repo.GetClothesByGenderId(id).ToList();
            if (listModels.Count == 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetMdifications:{id} Not Found");
                return NotFound();
            }

            List<ModifReadDto> list = new();
            foreach (var item in listModels)
                list.Add(_mapper.Map<ModifReadDto>(item));

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetMdifications:{id} Ok");
            return Ok(list);
        }
    }
}
