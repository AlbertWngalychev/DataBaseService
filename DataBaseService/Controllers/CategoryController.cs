using AutoMapper;
using DataBaseService.Data;
using DataBaseService.Dtos;
using DataBaseService.Logger;
using DataBaseService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataBaseService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly ICategoryRepo _repo;

        public CategoryController(
            IMapper mapper,
            ILoggerManager logger,
            ICategoryRepo repo)
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
            List<Category> categotiesModel = _repo.GetCategories().ToList();
            if (categotiesModel.Count == 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetAll Categories: Not found");
                return NotFound(new List<SimpleElementReadDto>());
            }
            var dtos = new List<SimpleElementReadDto>();
            foreach (var type in categotiesModel)
                dtos.Add(_mapper.Map<SimpleElementReadDto>(type));

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetAll Categories: OK");
            return Ok(dtos);
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

            Category? c = _repo.GetById(id);

            if (c == null)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById:{id} Not found");
                return NotFound();
            }

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById:{id} OK");
            return Ok(_mapper.Map<SimpleElementReadDto>(c));
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Post(string name)
        {
            try
            {

                _repo.Create(new Category() { Name = name });
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


        [HttpPut("{id}:{name}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id, string name)
        {
            if (id < 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Put by id:{id} < 0 Bad Request");
                return BadRequest();
            }
            if (_repo.GetById(id) == null)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Put by id:{id} not found");
                return NotFound();
            }

            try
            {

                _repo.Update(id, new Category() { Name = name });
                _repo.SaveChanges();

                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Put by id:{id} name:{name} OK");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.Put by id:{id} name:{name}. {ex.Message}");
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
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Delete by id:{id} < 0 Bad Request");
                return BadRequest();
            }
            try
            {
                _repo.DeleteById(id);
                _repo.SaveChanges();


                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Delete by id:{id} OK");
                return Ok();
            }
            catch (ArgumentNullException)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Delete by id:{id} Not Found");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.Delete by id:{id} {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet("{id}/types")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<TypeReadDto>> GetTypesByCategoById(int id)
        {
            if (id < 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetTypesByCategotyId by id:{id} < 0 Bad Request");
                return BadRequest();
            }
            List<Models.Type> types = _repo.GetTypesByCategoById(id).ToList();

            if (types.Count == 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetTypesByCategotyId by id:{id} Not Found");
                return NotFound();
            }

            List<TypeReadDto> temp = new();
            foreach (var type in types)
                temp.Add(_mapper.Map<TypeReadDto>(type));

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetTypesByCategotyId by id:{id} OK");
            return Ok(temp);

        }

    }
}
