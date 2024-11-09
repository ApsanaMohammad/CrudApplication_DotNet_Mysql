using CrudApplicationWithMySql3.CommonLayer.Model;
using CrudApplicationWithMySql3.ServiceLayer;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplicationWithMySql3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudApplicationController : ControllerBase
    {
        private readonly ICrudApplicationSL _crudApplicationSL;

        public CrudApplicationController(ICrudApplicationSL crudApplicationSL)
        {
            _crudApplicationSL = crudApplicationSL;
        }

        // POST: api/CrudApplication/AddInformation
        [HttpPost("AddInformation")]
        public IActionResult AddInformation(AddInformationRequest request)
        {
            var response = _crudApplicationSL.AddInformation(request);
            return Ok(response);
        }

        [HttpGet("GetAllInformation")]
        public IActionResult GetAllInformation()
        {
            var response = _crudApplicationSL.GetAllInformation();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound(new { Message = "No records found." });
        }

        // DELETE: api/CrudApplication/DeleteInformation/{id}
        [HttpDelete("DeleteInformation/{id}")]
        public IActionResult DeleteInformation(int id)
        {
            var response = _crudApplicationSL.DeleteInformation(id);
            return Ok(response);
        }

        // PUT: api/CrudApplication/UpdateInformation
        [HttpPut("UpdateInformation")]
        public IActionResult UpdateInformation(UpdateInformationRequest request)
        {
            var response = _crudApplicationSL.UpdateInformation(request);
            return Ok(response);
        }

        // GET: api/CrudApplication/GetInformationById/{id}
        [HttpGet("GetInformationById/{id}")]
        public IActionResult GetInformationById(int id)
        {
            var response = _crudApplicationSL.GetInformationById(id);
            return Ok(response);
        }
    }
}
