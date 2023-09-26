using System.Net;
using Api.Domain.Dtos.Country;
using Api.Domain.Interfaces.Services.Country;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _service;

        public CountriesController(ICountryService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var response = await _service.GetAll();

                return Ok(response);
            }
            catch (ArgumentException ae)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ae.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetCountryWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var response = await _service.Get(id);

                if (response == null) return NotFound();

                return Ok(response);
            }
            catch (ArgumentException ae)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ae.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetCompleteById(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var response = await _service.GetFullById(id);

                if (response == null) return NotFound();

                return Ok(response);
            }
            catch (ArgumentException ae)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ae.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{codIBGE}")]
        public async Task<ActionResult> GetCompleteByIBGE(int codIBGE)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var response = await _service.GetFullByIBGE(codIBGE);

                if (response == null) return NotFound();

                return Ok(response);
            }
            catch (ArgumentException ae)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ae.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CountryCreateDto country)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var response = await _service.Post(country);

                if (response == null) return BadRequest();

                var linkRedirect = Url.Link("GetCountryWithId", new { id = response.Id })!;
                return Created(new Uri(linkRedirect), response);
            }
            catch (ArgumentException ae)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ae.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CountryUpdateDto country)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var response = await _service.Put(country);

                return response != null ? Ok(response) : BadRequest();
            }
            catch (ArgumentException ae)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ae.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var response = await _service.Delete(id);

                return Ok(response);
            }
            catch (ArgumentException ae)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ae.Message);
            }
        }
    }
}
