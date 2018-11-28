using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ListersDemo.API.DataContracts.Requests;
using ListersDemo.API.DataContracts;
using AutoMapper;
using S = ListersDemo.API.Common;
using ListersDemo.Services.Contracts;
using ListersDemo.API.EfContext;

namespace ListersDemo.API.Controllers
{

    [ApiVersion("1.0")]
    //Default versioning
    //[Route("api/vehicles")] 
    [Route("api/v{version:apiVersion}/vehicles")]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _service;
        private readonly IMapper _mapper;
        private readonly ListersDemoAPIContext _context;

        public VehicleController(IVehicleService service, IMapper mapper, ListersDemoAPIContext context)
        {
            _service = service;
            _mapper = mapper;
            _context = context;
        }

        #region GET
        /// <summary>
        ///   /// Retrurn a list of all Vehicles in DB
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Vehicle> Get(VehicleRequest request)
        {
            var data = _service.Get(request);
            return _mapper.Map<IEnumerable<Vehicle>>(data);
        }

        /// <summary>
        /// Get Vehicle record by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Vehicle> Get(string id)
        {           
            var data = await _service.GetAsync(id);

            if (data != null)
                return _mapper.Map<Vehicle>(data);
            else
                return null;
        }
        #endregion

        #region POST
        /// <summary>
        /// Create a new vehicle record
        /// </summary>
        /// <param name="Vehicle"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateVehicle([FromBody]Vehicle Vehicle)
        {
            if (Vehicle == null)
                throw new ArgumentNullException("value");

            bool result = await _service.Create(Mapper.Map<S.Vehicle>(Vehicle));

            if (!result) return BadRequest(Vehicle);

            return CreatedAtAction("GetVehicle", new { id = Vehicle.Id}, Vehicle);
        }
        #endregion

        #region PUT
        /// <summary>
        /// Amend a vehicle record
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task<bool> UpdateVehicle(Vehicle parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException("parameter");

            return await _service.UpdateAsync(Mapper.Map<S.Vehicle>(parameter));
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Delete a vehicle record 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<bool> DeleteVehicle([FromRoute] string id)
        {
            return await _service.DeleteAsync(id);
        }
        #endregion
       
    }
}


