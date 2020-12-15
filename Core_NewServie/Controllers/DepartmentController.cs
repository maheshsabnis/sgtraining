using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_NewServie.Models;
using Core_NewServie.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Core_NewServie.Controllers
{
    /// <summary>
    /// Route: The RouteAttributeb class that is used to accept
    /// request for the controller and execute Http Action Method(?)
    ///
    /// ControllerBase: Uses ApiControllerAttribute class and Request Property of the type HttpRequest
    /// 1. Map the HttpRequest Type (GET / POST /PUT  / DELETE) to HttpAction Method decoarated with
    /// HttpMethod Attributes HttpGetAttribute, HttpPostAttribute, HttpPutAttribute and HttpDeleteAttribte
    ///
    /// 2. ApiControllerAttribute, used to Map the Post/Put HTTP request body data to CLR Object
    /// of Post and Put method
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IService<Department, int> deptService;
        /// <summary>
        /// COnstructor Injection of the DepartmentService
        /// </summary>
        /// <param name="deptService"></param>
        public DepartmentController(IService<Department, int> deptService)
        {
            this.deptService = deptService;
        }

        /// <summary>
        /// http://localhost:5000/api/Department
        /// </summary>
        /// <returns></returns>
        ///
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await deptService.GetDataAsync();
            // use Sytem.Text.Json.JsonSerializer object to serialize the response
            // JSON format
            return Ok(result);
        }

        /// <summary>
        /// http://localhost:5000/api/Department/{id}
        /// </summary>
        /// <returns></returns>
        ///
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await deptService.GetDataAsync(id);
             
            return Ok(result);
        }
        /// <summary>
        /// http://localhost:5000/api/Department
        /// </summary>
        /// <returns></returns>
        ///
        [HttpPost]
        public async Task<IActionResult> Post(Department data)
        {
            // Check for the Model Validations
            if (ModelState.IsValid)
            {
                var result = await deptService.CreateDataAsync(data);
                return Ok(result);
            }
            // return all error messages
            return BadRequest(ModelState);
        }
        /// <summary>
        /// http://localhost:5000/api/Department/{id}
        /// </summary>
        /// <returns></returns>
        ///
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Department data)
        {
            // Check for the Model Validations
            if (ModelState.IsValid)
            {
                var result = await deptService.UpdateDataAsync(id,data);
                return Ok(result);
            }
            // return all error messages
            return BadRequest(ModelState);
        }

        /// <summary>
        /// http://localhost:5000/api/Department/{id}
        /// </summary>
        /// <returns></returns>
        ///
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await deptService.DeleteDataAsync(id);
            if(result)  return Ok(result);
            return NotFound($"Department Record based on DeptNo {id} is not found ");
           
        }
    }
}