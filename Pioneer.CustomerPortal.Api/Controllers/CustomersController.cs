using Pioneer.BusinessEntities.Objects;
using Pioneer.BusinessServices.Authentication.Contract;
using Pioneer.BusinessServices.User;
using Pioneer.CustomerModule.Models;
using Pioneer.CustomerPortal.Api.ActionFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Pioneer.CustomerPortal.Api.Controllers
{
    [RoutePrefix("v1/customers")]
    [AuthorizationRequired]
    public class CustomersController : ApiController
    {
        #region Customer
        /// <summary>
        /// Get list of <see cref="CustomerResponse" />
        /// </summary>        
        /// <returns>list of Advisers</returns>
        /// <response code="200">OK</response>
        /// <response code="500">Something went wrong</response>
        [HttpGet]
        [Route("", Name = "GetCustomers")]
        [ResponseType(typeof(CustomerResponse))]
        public IHttpActionResult GetCustomers()
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
                // _logger.ExtendedError("Unexpected Error", ex);
                return InternalServerError();
            }
        }


        /// <summary>
        /// Get a single <see cref="CustomerResponse" /> by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single Customer Object</returns>
        /// <response code="200">OK</response>
        /// <response code="500">Something went wrong</response>
        [HttpGet]

        [Route("{id}", Name = "GetCustomerById")]
        [ResponseType(typeof(CustomerResponse))]
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
                //_logger.ExtendedError("Unexpected Error", ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Create a new <see cref="CustomerCreate" />
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns>201</returns>
        /// <response code="201">Returns the uri for the newly created item</response>
        /// <response code="409">Customer already exists</response>
        /// <response code="400">Customer required data not provided</response>
        /// <response code="500">Something went wrong</response>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(CustomerCreate))]
        public IHttpActionResult Post([FromBody]CustomerCreate customer)
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
                // _logger.ExtendedException(ex, buyer.ToJson());
                return InternalServerError();
            }
        }

        /// <summary>
        /// Update a <see cref="CustomerCreate" />
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adviser"></param>
        /// <returns>Returns updated cusomer object</returns>
        /// <response code="200">Customer updated</response>
        /// <response code="404">Customer not found</response>
        /// <response code="409">Customer already exists</response>
        /// <response code="400">Customer required data not provided</response>
        /// <response code="500">Something went wrong</response>
        [HttpPut]
        [Route("{id}")]

        [ResponseType(typeof(CustomerCreate))]
        public IHttpActionResult Put(int id, [FromBody] CustomerCreate Customer)
        {
            if (ModelState.IsValid == false || Customer?.Id != id)
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
        /// Delete a <see cref="CustomerCreate" />
        /// </summary>
        /// <param name="id"></param>       
        /// <returns>200</returns>
        /// <response code="200">Customer Delete</response>
        /// <response code="404">Customer not found</response>       
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
        #endregion Customer
    }
}
