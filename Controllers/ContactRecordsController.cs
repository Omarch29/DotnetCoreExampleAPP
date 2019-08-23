using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solstice.API.DATA;
using Solstice.API.DTOs;

namespace Solstice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactRecordsController : ControllerBase
    {
        private readonly IContactRepository _repo;
        private readonly IMapper _mapper;
        public ContactRecordsController(IContactRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {   
            var contacts = await _repo.GetAllContacts();
            var response = _mapper.Map<IEnumerable<ContactDTO>>(contacts);
            return Ok(response);
        }
    }
}