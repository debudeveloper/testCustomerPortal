using Pioneer.BusinessEntities.Objects;
using Pioneer.BusinessServices.Authentication.Contract;
using System;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Configuration.Assemblies;
using Pioneer.CloudPattern.AWS.DynamoDb;
using Amazon.DynamoDBv2.DocumentModel;

namespace Pioneer.BusinessServices.Authentication
{
    public class TokenServices : ITokenServices
    {
        #region Private member variables.

        private readonly DynamoService _dynamoDataService;
        #endregion

        #region Public constructor.
        /// <summary>
        /// Public constructor.
        /// </summary>
        public TokenServices(DynamoService dynamoDataService)
        {
            _dynamoDataService = dynamoDataService;
        }
        #endregion


        #region Public member methods.

        /// <summary>
        ///  Function to generate unique token with expiry against the provided userId.
        ///  Also add a record in database for generated token.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public TokenEntity GenerateToken(CustomerAPI userId)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(2154);
                                             // Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
            var tokendomain = new TokenEntity
            {
                UserId = userId.EmailAddress,
                UserType = userId.UserType,
                AuthToken = token,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn
            };
            userId.AuthData = new AuthenticationInfo();
            userId.AuthData.Password = "";
            userId.AuthData.AuthToken = token;
            userId.AuthData.IssuedOn = tokendomain.IssuedOn.ToLongTimeString();
            userId.AuthData.ExpiresOn = tokendomain.ExpiresOn.ToLongTimeString();

            // _dynamoDataService.UpdateItem(userId);
            // _dynamoDataService.UpdateMultipleAttributes(userId);
            _dynamoDataService.UpdateCustomerAuthItem(userId);

            var tokenModel = new TokenEntity()
            {
                UserId = userId.EmailAddress,
                UserType = userId.UserType,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn,
                AuthToken = token
            };

            return tokenModel;
        }

        /// <summary>
        /// Method to validate token against expiry and existence in database.
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public bool ValidateToken(string tokenId, string emailAddress, string userTpe)
        {
            QueryFilter filter = new QueryFilter();
            filter.AddCondition("EmailAddress", QueryOperator.Equal, emailAddress); //company is a parameter
            filter.AddCondition("UserType", QueryOperator.Equal, userTpe); //company is a parameter
            QueryOperationConfig config = new QueryOperationConfig()
            {
                Filter = filter,
                Select = SelectValues.SpecificAttributes,
                AttributesToGet = new List<string> { "AuthData" },
                ConsistentRead = true
            };

            var userData = _dynamoDataService.QueryItem<CustomerAPI>(emailAddress, userTpe, config).FirstOrDefault();

            //  _dynamoDataService.GetItem<CustomerAPI>()
            // var token = userData.Get(t => t.AuthToken == tokenId && t.ExpiresOn > DateTime.Now);
            if (userData != null && userData.AuthData != null
                //&& string.IsNullOrEmpty(userData.AuthData.ExpiresOn)
                && userData.AuthData.AuthToken.Equals(tokenId) && Convert.ToDateTime(userData.AuthData.ExpiresOn) > DateTime.Now)
            {
                if (!(DateTime.Now > Convert.ToDateTime(userData.AuthData.ExpiresOn)))
                {
                    //if (token != null && !(DateTime.Now > token.ExpiresOn))
                    //{
                    //    token.ExpiresOn = token.ExpiresOn.AddSeconds(
                    //                                  Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                    //    _unitOfWork.TokenRepository.Update(token);
                    //    _unitOfWork.Save();
                    //    return true;
                    //}
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method to kill the provided token id.
        /// </summary>
        /// <param name="tokenId">true for successful delete</param>
        public bool Kill(string tokenId)
        {
            //_unitOfWork.TokenRepository.Delete(x => x.AuthToken == tokenId);
            //_unitOfWork.Save();
            //var isNotDeleted = _unitOfWork.TokenRepository.GetMany(x => x.AuthToken == tokenId).Any();
            //if (isNotDeleted) { return false; }
            return true;
        }

        /// <summary>
        /// Delete tokens for the specific deleted user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true for successful delete</returns>
        public bool DeleteByUserId(Guid userId)
        {
            //_unitOfWork.TokenRepository.Delete(x => x.UserId == userId);
            //_unitOfWork.Save();
            //var isNotDeleted = _unitOfWork.TokenRepository.GetMany(x => x.UserId == userId).Any();
            //return !isNotDeleted;
            return false;
        }

        #endregion
    }
}
