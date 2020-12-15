using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_NewServie.Models;
using Core_NewServie.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_NewServie.Controllers
{
    /// <summary>
    /// Customize the Route Expression for containg Method name
    /// [controller] : The API Controller Name
    /// [action] : Aciton Method Name
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentBindingController : ControllerBase
    {
        IService<Department, int> repository;
        public DepartmentBindingController(IService<Department, int> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// FromBody: Parse the Http Request body and mpa with CLR object
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>

        [HttpPost]
        /// The custom action name
        [ActionName("PostBody")]
        public  IActionResult PostFromBody([FromBody]Department dept)
        {
            return Ok();
        }


        /// <summary>
        /// http://localhost:5000/api/DepartmentBinding/PostQuery?DeptName=Dname&Location=Loc&Capacity=3
        /// FromQuery: Parse the Querystring and map the Name:value pair to CLR Object
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("PostQuery")]
        public IActionResult PostFromQuery([FromQuery] Department dept)
        {
            return Ok();
        }


        /// <summary>
        /// http://localhost:5000/api/DepartmentBinding/PostRoute/IT/Pune/3
        /// FromRoute: Parse the ROute Expression and Map with CLR object
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost("{DeptName}/{Location}/{Capacity}")]
        [ActionName("PostRoute")]
        public IActionResult PostFromRoute([FromRoute] Department dept)
        {
            return Ok();
        }

        /// <summary>
        /// FromForm: The Name:value pair of the form wll be mapped with CLR object
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("PostForm")]
        public IActionResult PostFromForm([FromForm] Department dept)
        {
            return Ok();
        }
    }
}