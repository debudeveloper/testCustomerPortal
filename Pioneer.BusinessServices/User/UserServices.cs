using Amazon.DynamoDBv2.DocumentModel;
using AutoMapper;
using Pioneer.BusinessEntities.Objects;
using Pioneer.CloudPattern.AWS.DynamoDb;
using Pioneer.CloudPattern.AWS.Entity;
using Pioneer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;

namespace Pioneer.BusinessServices.User
{

    /// <summary>
    /// Offers services for user specific operations
    /// </summary>
    public class UserServices : IUserServices
    {
        private readonly DynamoService _dynamoDataService;


        /// <summary>
        /// Public constructor.
        /// </summary>
        public UserServices(DynamoService dynamoDataService)
        {
            _dynamoDataService = dynamoDataService;
        }

        /// <summary>
        /// Public method to authenticate user by user name and password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public CustomerAPI Authenticate(string userName, string password)
        {
            CustomerAPI obj = new CustomerAPI();
            obj.EmailAddress = userName;
            obj.Password = password;

            #region Trial Blocked Code
            //var user = _unitOfWork.UserRepository.Get(u => u.user_name == userName && u.password == EncryptText("wgt_hmis", password));


            //var request = new QueryRequest
            //{
            //    TableName = "Reply",
            //    KeyConditionExpression = "userName = :v_userName and emailAddress > :v_emailAddress",
            //    ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
            //        {":v_userName", new AttributeValue { S =  "surhere" }},
            //        {":v_emailAddress", new AttributeValue { S =  "surhere@gmail.com" }}
            //    },
            //    ProjectionExpression = "Subject, ReplyDateTime, PostedBy",
            //    ConsistentRead = true
            //};

            //IDictionary<string, DynamoDBEntry> keys = new Dictionary<string, DynamoDBEntry>();
            //keys["EmailAddress"] = "surhere@gmail.com";
            //keys["UserType"] = "Customer";
            //var userData = _dynamoDataService.GetItem<CustomerAPI>(keys);

            //var user = _dynamoDataService.GetItem<DVD>("The Godfather");
            #endregion

            QueryFilter filter = new QueryFilter();
            filter.AddCondition("EmailAddress", QueryOperator.Equal, userName); //company is a parameter
            filter.AddCondition("UserType", QueryOperator.Equal, "Customer"); //company is a parameter
            QueryOperationConfig config = new QueryOperationConfig()
            {
                Filter = filter,
                Select = SelectValues.SpecificAttributes,
                AttributesToGet = new List<string> { "AuthData", "Password", "FirstName", "LastName", "EmailAddress" },
                ConsistentRead = true
            };

            var userData = _dynamoDataService.QueryItem<CustomerAPI>(userName, password, config).FirstOrDefault();

            //var user = _dynamoDataService.GetEnumerable<CustomerAPI>(obj).FirstOrDefault();
            if (userData != null && userData.AuthData != null)
            {
                // validate if password is matched
                if (userData.Password != null && !string.IsNullOrEmpty(userData.Password))
                {
                    //if(userData.AuthData.Password.Equals(password))
                    if (userData.Password.Equals(password))
                    {
                        userData.UserName = userData.EmailAddress;
                        userData.FirstName = userData.FirstName;
                        return userData;
                    }
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// Get All users.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IEnumerable<CustomerAPI> GetAllUsers()
        {
            var users = _dynamoDataService.GetAll<CustomerAPI>().ToList();
            if (users.Any())
            {
                // Mapper.CreateMap<hmis_user_base, hmisUserBase>();
                Mapper.Reset();
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Customer, CustomerAPI>();

                });
                // var userModel = Mapper.Map<List<Customer>, List<CustomerAPI>>(users);
                return users;
            }
            return null;
        }

        /// <summary>
        /// Creates a user in DBV
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        public Guid CreateUser(CustomerAPI userEntity)
        {
            using (var scope = new TransactionScope())
            {
                var userHMIS = new CustomerAPI
                {
                    EmailAddress = userEntity.EmailAddress,
                    UserAgent = userEntity.UserAgent,
                    //  password = EncryptText("wgt_hmis", userEntity.password),
                    FirstName = userEntity.FirstName,
                    LastName = userEntity.LastName,
                    Address1 = userEntity.Address1,
                    Address2 = userEntity.Address2,
                    City = userEntity.City,
                    CreatedOn = DateTime.Now,
                    // CreatedBy = "To be done",
                    Postcode = userEntity.Postcode,
                    Password = userEntity.Password,
                    AuthData = userEntity.AuthData

                };
                _dynamoDataService.Store(userHMIS);
                //  _unitOfWork.Save();
                scope.Complete();
                return userHMIS.Id;
            }
        }

        public void DynameTestService()
        {
            _dynamoDataService.InitTableProcess();
            //   var dvdMaker = new SampleData();

            /*CREATE*/
            //foreach (var dvd in dvdMaker.Dvds)
            //{
            //    _dynamoDataService.Store(dvd);
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string EncryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            byte[] bytesEncrypted = AESManaged.AES_Encrypt(bytesToBeEncrypted, passwordBytes);
            string result = Convert.ToBase64String(bytesEncrypted);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string DecryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            byte[] bytesDecrypted = AESManaged.AES_Decrypt(bytesToBeDecrypted, passwordBytes);
            string result = Encoding.UTF8.GetString(bytesDecrypted);
            return result;
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="usertId"></param>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        //public bool UpdateUser(Guid userId, BusinessEntities.CustomerAPI userEntity)
        //{
        //    var success = false;
        //    if (userEntity != null)
        //    {
        //        using (var scope = new TransactionScope())
        //        {
        //            var user = _unitOfWork.UserRepository.GetByID(userId);
        //            if (user != null)
        //            {
        //                user.SID = userEntity.SID;
        //                _unitOfWork.UserRepository.Update(user);
        //                _unitOfWork.Save();
        //                scope.Complete();
        //                success = true;
        //            }
        //        }
        //    }
        //    return success;
        //}

        /// <summary>
        /// Deletes a particular user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //public bool DeleteUser(Guid userId)
        //{
        //    var success = false;
        //    if (userId != null && userId != Guid.Empty)
        //    {
        //        using (var scope = new TransactionScope())
        //        {
        //            var product = _unitOfWork.UserRepository.GetByID(userId);
        //            if (product != null)
        //            {

        //                _unitOfWork.UserRepository.Delete(product);
        //                _unitOfWork.Save();
        //                scope.Complete();
        //                success = true;
        //            }
        //        }
        //    }
        //    return success;
        //}

        /// <summary>
        /// Fetches product details by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserEntity GetUserById(string userId, string userType)
        {
            // UserEntity responseUser = new UserEntity();
            QueryFilter filter = new QueryFilter();
            filter.AddCondition("EmailAddress", QueryOperator.Equal, userType); //company is a parameter
            filter.AddCondition("UserType", QueryOperator.Equal, userType); //company is a parameter
            QueryOperationConfig config = new QueryOperationConfig()
            {
                Filter = filter,
                //Select = SelectValues.SpecificAttributes,
                //AttributesToGet = new List<string> { "AuthData", "Password", "FirstName", "LastName", "EmailAddress" },
                ConsistentRead = true
            };

            // var userData = _dynamoDataService.QueryItem<CustomerAPI>(userId, userType, config).FirstOrDefault();
            var userData = _dynamoDataService.GetEnumerable<CustomerAPI>(userId, userType).FirstOrDefault();
            if (userData != null)
            {
                // Mapper.CreateMap<hmis_user_base, hmisUserBase>();
                //Mapper.Reset();
                //Mapper.Initialize(cfg =>
                //{
                //    cfg.CreateMap<hmis_user_base, hmisUserBase>();
                //    //cfg.CreateMap<hmis_link_role_persmissions, hmisRolePermissions>();
                //    //cfg.CreateMap<hmis_permission_base, hmisPermisionBase>();

                //});
                //var userModel = Mapper.Map<hmis_user_base, hmisUserBase>(user);

                var responseUser = new UserEntity
                {
                    UserId = userData.EmailAddress,
                    UserName = userData.EmailAddress,
                    Password = userData.Password,
                    FirstName = userData.FirstName,
                    LastName = userData.LastName
                };

                return responseUser;
            }
            return null;
        }
    }

}
