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
    public class OrderElementController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IOrderElementRepo _repo;

        public OrderElementController(
            IMapper mapper,
            ILoggerManager logger,
            IOrderElementRepo repo)
        {
            _mapper = mapper;
            _logger = logger;
            _repo = repo;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<OrderElementReadDto> Get(int id)
        {
            if (id < 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById:{id} Bad Request");
                return BadRequest();
            }

            OrderElement? t = _repo.GetById(id);

            if (t == null)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById:{id} Not found");
                return NotFound();
            }

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById:{id} OK");
            return Ok(_mapper.Map<OrderElementReadDto>(t));
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Post(OrderElementCreateDto dto)
        {
            try
            {
                _repo.Create(_mapper.Map<OrderElement>(dto));
                _repo.SaveChanges();

                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Create OrderId:{dto.OrderId}   Ok");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.Create  OrderId:{dto.OrderId}. {ex.Message}");
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id, OrderElementCreateDto dto)
        {
            if (_repo.GetById(id) == null)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.UpdateById:{id} not found");
                return NotFound();
            }


            try
            {
                _repo.Update(id, _mapper.Map<OrderElement>(dto));
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

        [HttpGet("order/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<OrderElementReadDto>> GetByOrderId(int id)
        {
            var listModels = _repo.GetByOrderId(id).ToList();
            if (listModels.Count == 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetByOrderId  Not Found");
                return NotFound();
            }

            List<OrderElementReadDto> list = new();
            foreach (var item in listModels)
                list.Add(_mapper.Map<OrderElementReadDto>(item));

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetByOrderId  Ok");
            return Ok(list);
        }


    }
}