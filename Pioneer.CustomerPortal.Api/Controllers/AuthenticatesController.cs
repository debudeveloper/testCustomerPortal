using AttributeRouting.Web.Http;
using Pioneer.CustomerPortal.Api.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pioneer.CustomerPortal.Api.Controllers
{
    [Route("v1/authenticate")]
    public class AuthenticatesController : ApiController
    {
        #region Users 

        /// <summary>
        /// Save User <see cref="AdviserResponse" /> 
        /// </summary>        
        /// <returns>Success Message with Status Code</returns>
        /// <response code="201">Created</response>
        /// <response code="500">Something went wrong</response>


        ///// <summary>
        ///// Authenticates user and returns token with expiry.
        ///// </summary>
        ///// <returns></returns>
        //[POST("login")]
        //[POST("authenticate")]
        //[POST("get/token")]
        ////  [EnableCors(origins: "*", headers: "*", methods: "*")]
        //public HttpResponseMessage Authenticate()
        //{
        //    if (System.Threading.Thread.CurrentPrincipal != null && System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
        //    {
        //        var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
        //        if (basicAuthenticationIdentity != null)
        //        {
        //            var userId = basicAuthenticationIdentity;
        //            return GetAuthToken(userId);
        //        }
        //    }
        //    return null;
        //}

        /// <summary>
        /// Returns auth token for the validated user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //private HttpResponseMessage GetAuthToken(BasicAuthenticationIdentity userId)
        //{
        //    LoginResponseObject obj = new LoginResponseObject();
        //    CustomerAPI objCus = new CustomerAPI();
        //    objCus.EmailAddress = userId.UserName;
        //    objCus.UserType = userId.UserType;
        //    var token = _tokenServices.GenerateToken(objCus);
        //    obj.Authorized = "Authorized:";
        //    obj.access_token = token;
        //    obj.userName = userId.UserName.ToString();
        //    //obj.expiration = token.ExpiresOn.ToLongDateString(); 
        //    obj.userData.email = userId.UserId.ToString();
        //    //  obj.userData.id = userId.ToString();
        //    var response = Request.CreateResponse(HttpStatusCode.OK, obj);
        //    response.Headers.Add("Token", token.AuthToken);
        //    response.Headers.Add("UserID", userId.UserId.ToString());
        //    // response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
        //    response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
        //    response.Content.Headers.Add("access_token", token.AuthToken);
        //    //response.Content.Headers.Add("userName", userId.ToString());
        //    var session = HttpContext.Current.Session;
        //    //if(session!=null)
        //    //{
        //    //    if(session["AuthUser"]==null)
        //    //    {
        //    //        session["AuthUser"] = token;
        //    //    }
        //    //}
        //    return response;
        //}
        //public class LoginResponseObject
        //{
        //    public LoginResponseObject()
        //    {
        //        this.userData = new UserObject();
        //    }
        //    public string userName { get; set; }
        //    public string Authorized { get; set; }
        //    public TokenEntity access_token { get; set; }
        //    CustomerAPI SessionUserData { get; set; }
        //    public UserObject userData { get; set; }
        //}

        //public class UserObject
        //{
        //    public string id { get; set; }
        //    public string email { get; set; }
        //    public string userName { get; set; }

        //}

        #endregion Users
    }
}
