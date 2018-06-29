
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Pioneer.CustomerPortal.Api.Controllers
{
    [RoutePrefix("v1/advisers")]
    public class AdvisersController : ApiController
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        #region Adviser
        /// <summary>
        /// Get list of <see cref="AdviserResponse" /> by Id
        /// </summary>        
        /// <returns>list of Advisers</returns>
        /// <response code="200">OK</response>
        /// <response code="500">Something went wrong</response>
        [HttpGet]
        [Route("", Name = "GetAdvisers")]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetAdvisers()
        {
            try
            {
                return Ok();
            }
            catch (NotImplementedException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                 _logger.LogException(LogLevel.Error,"Unnable To Get adviser",ex);
                return InternalServerError();
            }
        }


        /// <summary>
        /// Get a single <see cref="AdvisersResponse" /> by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single Adviser Object</returns>
        /// <response code="200">OK</response>
        /// <response code="500">Something went wrong</response>
        [HttpGet]

        [Route("{id}", Name = "GetAdviserById")]
        [ResponseType(typeof(string))]
        public IHttpActionResult Get(int id)
        {
            try
            {

                return Ok();
            }
            catch (NotImplementedException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                //  _logger.ExtendedError("Unexpected Error", ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Create a new <see cref="CreateBuyerRequest" />
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns>201</returns>
        /// <response code="201">Returns the uri for the newly created item</response>
        /// <response code="409">Adviser already exists</response>
        /// <response code="400">Adviser required data not provided</response>
        /// <response code="500">Something went wrong</response>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(string))]
        public IHttpActionResult Post([FromBody]dynamic adviser)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            try
            {
                //  var buyerId = _buyerService.Create(buyer);
                // buyer.Id = buyerId;
                // return CreatedAtRoute("GetBuyerById", new { id = buyerId }, new { buyerId });
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogException(LogLevel.Error,"Faild",ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Update a <see cref="CreateAdviserRequest" />
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adviser"></param>
        /// <returns>Returns updated buyer object</returns>
        /// <response code="200">Adviser updated</response>
        /// <response code="404">Adviser not found</response>
        /// <response code="409">Adviser already exists</response>
        /// <response code="400">Adviser required data not provided</response>
        /// <response code="500">Something went wrong</response>
        [HttpPut]
        [Route("{id}")]

        [ResponseType(typeof(string))]
        public IHttpActionResult Put(int id, [FromBody] dynamic buyer)
        {
            if (ModelState.IsValid == false || buyer?.Id != id)
            {
                return BadRequest();
            }

            try
            {
                // _buyerService.Update(buyer);
                //  var updatedBuyer = _buyerService.GetById(id);
                // return Ok(updatedBuyer);
                return Ok();
            }
            catch (NotImplementedException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                //_logger.ExtendedException(ex, "Unexpected error occurred", new { BuyerId = id });
                return InternalServerError();
            }
        }

        /// <summary>
        /// Delete a <see cref="CreateAdviserRequest" />
        /// </summary>
        /// <param name="id"></param>       
        /// <returns>200</returns>
        /// <response code="200">Buyer Delete</response>
        /// <response code="404">Buyer not found</response>       
        /// <response code="500">Something went wrong</response>
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                //_buyerService.Delete(id);
                return Ok();
            }
            catch (NotImplementedException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                //_logger.ExtendedError("Unexpected Error", ex);
                return InternalServerError();
            }
        }
        #endregion Adviser
    }
}
