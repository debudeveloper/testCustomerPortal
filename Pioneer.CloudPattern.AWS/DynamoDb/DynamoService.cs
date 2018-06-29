using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Pioneer.BusinessEntities.Objects;
using Pioneer.CloudPattern.AWS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneer.CloudPattern.AWS.DynamoDb
{
    public class DynamoService : ITableDataService
    {

        public readonly DynamoDBContext DbContext;
        public AmazonDynamoDBClient DynamoClient;

        public DynamoService()
        {
            //DynamoClient = new AmazonDynamoDBClient();
            //AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
            //clientConfig.ServiceURL = "http://localhost:5151";
            //DynamoClient = new AmazonDynamoDBClient("fake_access_id","fake_access_key",clientConfig);
            //DynamoClient = new AmazonDynamoDBClient("AKIAIGQSXMOKDNULWAWA", "EgZwTBGpV6LzuSuyJWlZQGsHf5Cfbib0hAUZLNM2", clientConfig);

            DynamoClient = new AmazonDynamoDBClient("AKIAIGQSXMOKDNULWAWA", "EgZwTBGpV6LzuSuyJWlZQGsHf5Cfbib0hAUZLNM2", Amazon.RegionEndpoint.EUWest1);

            DbContext = new DynamoDBContext(DynamoClient, new DynamoDBContextConfig
            {
                //Setting the Consistent property to true ensures that you'll always get the latest 
                ConsistentRead = true,
                SkipVersionCheck = true
            });
        }

        public string InitTableProcess()
        {
            List<string> currentTables = DynamoClient.ListTables().TableNames;
            if (!currentTables.Contains("DVD"))
            {
                var createTableRequest = new CreateTableRequest
                {
                    TableName = "DVD",
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 1,
                        WriteCapacityUnits = 1
                    },
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "Title",
                            KeyType = "HASH"
                        },
                        new KeySchemaElement
                        {
                            AttributeName = "ReleaseYear",
                            KeyType = "RANGE"
                        },
                    },
                    AttributeDefinitions = new List<AttributeDefinition>()
                    {
                        new AttributeDefinition()
                        {
                            AttributeName = "Title",AttributeType = "S"
                        },
                        new AttributeDefinition()
                        {
                            AttributeName = "ReleaseYear",AttributeType = "N"
                        }
                    }
                };


                CreateTableResponse createTableResponse = DynamoClient.CreateTable(createTableRequest);

                while (createTableResponse.TableDescription.TableStatus != "ACTIVE")
                {
                    System.Threading.Thread.Sleep(5000);
                }
                return createTableResponse.TableDescription.TableStatus.Value.ToString();
            }
            return "Empty Hand";

        }

        /// <summary>
        /// Uses the scan operator to retrieve all items in a table
        /// <remarks>[CAUTION] This operation can be very expensive if your table is large</remarks>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<string> GetAllTables()
        {
            List<string> listTables = DynamoClient.ListTables().TableNames;
            return listTables;
        }

        /// <summary>
        /// The Store method allows you to save a POCO to DynamoDb
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void Store<T>(T item) where T : new()
        {
            DbContext.Save(item);
        }

        /// <summary>
        /// The BatchStore Method allows you to store a list of items of type T to dynamoDb
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        public void BatchStore<T>(IEnumerable<T> items) where T : class
        {
            var itemBatch = DbContext.CreateBatchWrite<T>();

            foreach (var item in items)
            {
                itemBatch.AddPutItem(item);
            }

            itemBatch.Execute();
        }
        /// <summary>
        /// Uses the scan operator to retrieve all items in a table
        /// <remarks>[CAUTION] This operation can be very expensive if your table is large</remarks>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetAll<T>() where T : class
        {
            IEnumerable<T> items = DbContext.Scan<T>();
            return items;
        }

        /// <summary>
        /// Retrieves an item based on a search key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetItem<T>(string keys) where T : class
        {
            return DbContext.Load<T>(keys);
        }

        /// <summary>
        /// Not In Use : Test Method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public IEnumerable<T> GetEnumerable<T>(string hasKey, string rangeKey) where T : class
        {
            IEnumerable<T> userInformation = DbContext.Query<T>(hasKey,
                                        QueryOperator.Equal, rangeKey);
            // DbContext.Query<T>("surhere@gmail.com", new DynamoDBOperationConfig { IndexName = "Email-index" }).FirstOrDefault();
            return userInformation;
        }

        /// <summary>
        /// Retrieves an item based on a search key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public IEnumerable<T> QueryItem<T>(string key, string value, QueryOperationConfig config) where T : class
        {
            return DbContext.FromQuery<T>(config);
        }

        /// <summary>
        /// Method Updates and existing item in the table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void UpdateItem<T>(T item) where T : class
        {
            T savedItem = DbContext.Load(item);

            if (savedItem == null)
            {
                throw new AmazonDynamoDBException("The item does not exist in the Table");
            }

            DbContext.Save(item);
        }

        /// <summary>
        /// Method Updates and existing item in the table : Working
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void UpdateCustomerAuthItem(CustomerAPI item)
        {
            var savedItem = DbContext.Load<CustomerAPI>(item);
            savedItem.AuthData = item.AuthData;
            if (savedItem == null)
            {
                throw new AmazonDynamoDBException("The item does not exist in the Table");
            }

            DbContext.Save(savedItem);
        }

        /// <summary>
        /// Not In Use : Test Method -- Testt Data with Hard code value
        /// </summary>
        public void UpdateMultipleAttributes(CustomerAPI value)
        {
            var request = new UpdateItemRequest
            {
                Key = new Dictionary<string, AttributeValue>()
            {
                { "EmailAddress", new AttributeValue { S = "neilhere@gmail.com" }},
                 { "UserType", new AttributeValue { S = "Customer" }}
            },
                // Perform the following updates:
                // 1) Add two new authors to the list
                // 1) Set a new attribute
                // 2) Remove the ISBN attribute
                ExpressionAttributeNames = new Dictionary<string, string>()
            {
                {"#A","AuthData.AuthToken"},
                {"#NA","NewAttribute"}//,
                //{"#I","Dnc"}
            },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
            {
                {
                        ":auth",new AttributeValue {S = "Test Token"}

                },

                {":new",new AttributeValue {
                     S = "New Value"
                 }}
            },

                // UpdateExpression = "ADD #A :auth SET #NA = :new REMOVE #I",
                UpdateExpression = "ADD #A :auth SET #NA = :new ",
                TableName = "CustomerAPI",
                ReturnValues = "ALL_NEW" // Give me all attributes of the updated item.
            };
            var response = DynamoClient.UpdateItem(request);

            // Check the response.
            var attributeList = response.Attributes;
        }

        /// <summary>
        /// M Not In Use : Test Method -- Testt Data with Hard code value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void UpdateItemAttributes<T>(T item) where T : class
        {
            UpdateItemRequest updateRequest = new UpdateItemRequest()
            {
                TableName = "CustomerAPI",
                Key = new Dictionary<string, AttributeValue>
                {
                    { "EmailAddress",  new AttributeValue {
                          S = "surhere@gmail.com"
                      } },
                    { "UserType", new AttributeValue {
                          S = "Customer"
                      }}
                },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
            {
                { ":r", new AttributeValue {
                      S = "5.5"
                  } },
                { ":p", new AttributeValue {
                      S = "Everything happens all at once!"
                  } }
                //    ,
                //{ ":a", new AttributeValue {
                //      SS = { "Larry","Moe","Curly" }
                //  } }
            },
                UpdateExpression = "SET AuthData.AuthToken = :r, AuthData.IssuedOn = :p",
                ReturnValues = "UPDATED_NEW"
            };

            DynamoClient.UpdateItem(updateRequest);
        }

        /// <summary>
        /// Deletes an Item from the table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void DeleteItem<T>(T item)
        {
            var savedItem = DbContext.Load(item);

            if (savedItem == null)
            {
                throw new AmazonDynamoDBException("The item does not exist in the Table");
            }

            DbContext.Delete(item);
        }

    }
}