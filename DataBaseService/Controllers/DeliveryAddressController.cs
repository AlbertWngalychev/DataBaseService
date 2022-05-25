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
    public class DeliveryAddressController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDelAddessRepo _daRepo;
        private readonly ILoggerManager _logger;

        public DeliveryAddressController(
            ILoggerManager logger,
            IDelAddessRepo delAddressRepo,
            IMapper mapper)
        {
            _mapper = mapper;
            _daRepo = delAddressRepo;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<DeliveryAddressReadDto> GetById(int id)
        {
            if (id <= 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById id < 0");
                return BadRequest();
            }
            var da = _daRepo.GetDeliveryAddressById(id);
            if (da == null)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById not fount by id:{id}");
                return NotFound();
            }
            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetById  id:{id} OK");
            return Ok(_mapper.Map<DeliveryAddressReadDto>(da));

        }


        [HttpGet("client/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<DeliveryAddressReadDto>> GetByClientId(int id)
        {
            List<DeliveryAddress> das = _daRepo.GetDeliveryAddressesByClientId(id).ToList();
            if (das.Count <= 0)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetByClientId not fount id:{id}");
                return NotFound();
            }
            List<DeliveryAddressReadDto> listdto = new();
            foreach (DeliveryAddress da in das)
                listdto.Add(_mapper.Map<DeliveryAddressReadDto>(da));

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetByClientId {id} OK");
            return Ok(listdto);
        }

        [HttpDelete("id")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Delete(int id)
        {
            try
            {

                _daRepo.DeleteDeliveryAddress(id);
                _daRepo.SaveChanges();

                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.DeleteById {id} OK");
                return Ok();
            }
            catch (Exception ex)
            {

                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.DeleteById {id} {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Create(DeliveryAddressCreateDto daDto)
        {

            try
            {
                var da = _mapper.Map<DeliveryAddress>(daDto);
                _daRepo.CreateDeliveryAddress(da);
                _daRepo.SaveChanges();

                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Create Client:{daDto.ClientId} OK");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.Create Client:{daDto.ClientId} {ex.Message}");
                return BadRequest();
            }

        }
    }
}
