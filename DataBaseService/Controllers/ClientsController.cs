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
    public class ClientsController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IClientRepo _clientRepo;
        private readonly IMapper _mapper;

        public ClientsController(
            ILoggerManager logger,
            IClientRepo clientRepo,
            IMapper mapper)
        {
            _logger = logger;
            _clientRepo = clientRepo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<ClientReadDto> GetClientById(int id)
        {

            var client = _clientRepo.GetClientById(id);
            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.GetClientById {id} {client != null}");
            if (client != null)
            {
                return Ok(_mapper.Map<ClientReadDto>(client));
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult CreateClient(ClientCreateDto clientCreateDto)
        {
            var clientModel = _mapper.Map<Client>(clientCreateDto);
            try
            {
                _clientRepo.Create(clientModel);
                _clientRepo.SaveChanges();

                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.CreateClient {clientCreateDto.EMail}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.CreateClient {ex.Message}" +
                    $" {clientCreateDto.EMail}/" +
                    $"{clientCreateDto.Tel}/" +
                    $"{clientCreateDto.Fname}/");
                return BadRequest();
            }


        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult UpdateClient(int id, ClientCreateDto clientCreateDto)
        {

            try
            {
                var newclient = _mapper.Map<Client>(clientCreateDto);
                _clientRepo.UpdateClient(id, newclient);
                _clientRepo.SaveChanges();
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.UpdateClient {id} Result ok");
                return Ok();
            }
            catch (ArgumentNullException)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.UpdateClient.GetClientById {id} Not found");
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.Write(NLog.LogLevel.Error, $"{ToString()}.UpdateClient Message:{e.Message} ClientId:{id} ");
                return BadRequest();
            }
        }
    }
}
