using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace DynamoDbContext.Models
{
    //debu12345 access key for dyanamo db context
    public class DdService
    {
        public void Dbservice()
        {
            try
            {
                AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
                // Set the endpoint URL
                clientConfig.ServiceURL = "http://localhost:8000";

                var credentils = new BasicAWSCredentials("test1", "test2");
                AmazonDynamoDBClient client = new AmazonDynamoDBClient(credentils, clientConfig);
                List<string> currentTables = client.ListTables().TableNames;
                // foreach(var i in currentTables) { client.DeleteTable(new DeleteTableRequest() { TableName = "Customers" }); break; }

                if (!currentTables.Contains("TbaleGSI"))
                {
                    var OrganizationTabRequest = new CreateTableRequest
                    {
                        TableName = "TbaleGSI",
                        ProvisionedThroughput = new ProvisionedThroughput
                        {
                            ReadCapacityUnits = 1,
                            WriteCapacityUnits = 1
                        },
                        KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "pId",
                            KeyType = "HASH"
                        },
                        new KeySchemaElement
                        {
                            AttributeName ="PName",
                            KeyType = "RANGE"
                        }
                    },
                        GlobalSecondaryIndexes = new List<GlobalSecondaryIndex>()
                    {
                        new GlobalSecondaryIndex()
                        {
                            IndexName = "GSIId",

                             KeySchema = new List<KeySchemaElement>()
                            {
                                new KeySchemaElement
                                {
                                    AttributeName = "PName",
                                    KeyType = "HASH"
                                }
                            }

                        }
                    },

                        AttributeDefinitions = new List<AttributeDefinition>()
                    {
                        new AttributeDefinition()
                        {
                            AttributeName = "pId",AttributeType = "N"
                        },
                         new AttributeDefinition()
                        {
                            AttributeName = "PName",AttributeType = "S"
                        },
                    }
                    };
                    OrganizationTabRequest.GlobalSecondaryIndexes[0].ProvisionedThroughput = new ProvisionedThroughput(1, 1);
                    OrganizationTabRequest.GlobalSecondaryIndexes[0].Projection = new Projection() { ProjectionType = ProjectionType.ALL };
                    var respone = client.CreateTable(OrganizationTabRequest);
                }

                if (!currentTables.Contains("Organizations"))
                {
                    var OrganizationTabRequest = new CreateTableRequest
                    {
                        TableName = "Organizations",
                        ProvisionedThroughput = new ProvisionedThroughput
                        {
                            ReadCapacityUnits = 1,
                            WriteCapacityUnits = 1
                        },
                        KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "OrganizationId",
                            KeyType = "HASH"
                        }
                    },
                        AttributeDefinitions = new List<AttributeDefinition>()
                    {
                        new AttributeDefinition()
                        {
                            AttributeName = "OrganizationId",AttributeType = "N"
                        }
                    }
                    };
                    var respone = client.CreateTable(OrganizationTabRequest);
                }
                if (!currentTables.Contains("Login"))
                {
                    var request = new CreateTableRequest
                    {
                        TableName = "Login",
                        ProvisionedThroughput = new ProvisionedThroughput
                        {
                            ReadCapacityUnits = 1,
                            WriteCapacityUnits = 1
                        },
                        KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "Email",
                            KeyType = "HASH"
                        }

                    },
                        AttributeDefinitions = new List<AttributeDefinition>()
                    {
                        new AttributeDefinition()
                        {
                            AttributeName = "Email",AttributeType = "S"
                        }
                    }
                    };
                    var respone = client.CreateTable(request);
                }
                if (!currentTables.Contains("Buyers"))
                {
                    var request = new CreateTableRequest
                    {
                        TableName = "Buyers",
                        ProvisionedThroughput = new ProvisionedThroughput
                        {
                            ReadCapacityUnits = 1,
                            WriteCapacityUnits = 1
                        },
                        KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "Email",
                            KeyType = "HASH"
                        }

                    },
                        AttributeDefinitions = new List<AttributeDefinition>()
                    {
                        new AttributeDefinition()
                        {
                            AttributeName = "Email",AttributeType = "S"
                        }
                    }
                    };
                    var respone = client.CreateTable(request);
                }
                if (!currentTables.Contains("Products"))
                {
                    var request = new CreateTableRequest
                    {
                        TableName = "Products",
                        ProvisionedThroughput = new ProvisionedThroughput
                        {
                            ReadCapacityUnits = 1,
                            WriteCapacityUnits = 1
                        },
                        KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "ProductId",
                            KeyType = "HASH"
                        }

                    },
                        AttributeDefinitions = new List<AttributeDefinition>()
                    {
                        new AttributeDefinition()
                        {
                            AttributeName = "ProductId",AttributeType = "N"
                        }
                    }
                    };
                    var respone = client.CreateTable(request);
                }
                if (!currentTables.Contains("Customers"))
                {
                    var request = new CreateTableRequest
                    {
                        TableName = "Customers",
                        ProvisionedThroughput = new ProvisionedThroughput
                        {
                            ReadCapacityUnits = 1,
                            WriteCapacityUnits = 1
                        },
                        KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "Email",
                            KeyType = "HASH"
                        },
                        new KeySchemaElement
                        {
                            AttributeName ="CreatedOn",
                            KeyType ="RANGE"
                        }

                    },
                        AttributeDefinitions = new List<AttributeDefinition>()
                    {
                        new AttributeDefinition()
                        {
                            AttributeName = "Email",AttributeType = "S"
                        },
                         new AttributeDefinition()
                        {
                            AttributeName = "CreatedOn",AttributeType = "N"
                        }
                    }
                    };
                    var respone = client.CreateTable(request);
                }

                DynamoDBContext DbContext = new DynamoDBContext(client, new DynamoDBContextConfig
                {
                    //Setting the Consistent property to true ensures that you'll always get the latest 
                    ConsistentRead = true,
                    SkipVersionCheck = true
                });
                var dic = new Dictionary<string, IProduct>();

                var Gsi = new TbaleGSI
                {
                    pId = 1,
                    pName = "debu"
                };
                DbContext.Save<TbaleGSI>(Gsi);
                var customer = new Customers
                {
                    Address = "Address",
                    CreatedOn = 1,
                    Email = "test@test.com",
                    HomePhone = "000000000",
                    WorkPhone = "00000000000",
                    //    Products = new Dictionary<string, string>
                    //   {
                    // "test", new 
                    //   }


                };

                //DbContext.Save<DemoTest>(data);
                var loginTab = DbContext.Load<Login>("test@test.com");

                var rs = DbContext.Query<Organizations>("ythy", QueryOperator.GreaterThan, 0);
                var Qrequest = new QueryRequest
                {
                    TableName = "DemoTest",
                    KeyConditionExpression = "Title = :v_Title and ReleaseYear = :v_ReleaseYear",
                    ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                   {":v_Title", new AttributeValue {
                     S = "t1"
                   }},
                   {":v_ReleaseYear", new AttributeValue {
                     N = "51"
                   }}
                 },

                    // Optional parameter.
                    // ProjectionExpression = "Id, ReplyDateTime, PostedBy",
                    // Optional parameter.
                    ConsistentRead = true
                };
                // var Qresponse = DbContext.Query<DemoTest>("ythy", QueryOperator.Equal, 53);
                //foreach (Dictionary<string, AttributeValue> item in Qresponse.ToList())
                //{
                //}
                // var response = DbContext.Load<Organizations>(new Organizations() { ReleaseYear = 50, Title = "ythy" });

                // DbContext.Save<DemoTest>(data);//, new DynamoDBOperationConfig() { OverrideTableName = "DemoTest", SkipVersionCheck = true });
                // TestCRUDOperations(DbContext, client);
                //TestCRUDOperations(context);
                Console.WriteLine("To continue, press Enter");
            }
            catch (AmazonDynamoDBException e) { Console.WriteLine(e.Message); }
            catch (AmazonServiceException e) { Console.WriteLine(e.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        //private static void TestCRUDOperations(DynamoDBContext context, AmazonDynamoDBClient client)
        //{
        //    List<string> currentTables = client.ListTables().TableNames;


        //   // context.Save<Organizations>(data);

        //    int bookID = 1; // Some unique value.



        //    // Retrieve the updated book. This time add the optional ConsistentRead parameter using DynamoDBContextConfig object.
        //    Organizations updatedBook = context.Load<Organizations>(bookID, new DynamoDBContextConfig
        //    {
        //        ConsistentRead = true
        //    });

        //    // Delete the book.
        //    context.Delete<Organizations>(bookID);
        //    // Try to retrieve deleted book. It should return null.
        //    Organizations deletedBook = context.Load<Organizations>(bookID, new DynamoDBContextConfig
        //    {
        //        ConsistentRead = true
        //    });
        //    if (deletedBook == null)
        //        Console.WriteLine("Book is deleted");
        //}
    }

    public class TbaleGSI
    {
        public int pId { get; set; }
        public string pName { get; set; }
    }
    public class Organizations
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public string Hashkey { get; set; }
    }
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string TokenExpiry { get; set; }
    }
    public class Buyer
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
    }
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }

    public class Customers
    {
        public string Email { get; set; }
        public int CreatedOn { get; set; }
        public string WorkPhone { get; set; }
        public string HomePhone { get; set; }
        public string Address { get; set; }
        public Dictionary<string, IProduct> Products { get; set; }
    }

    public class IProduct
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
    public class Mortgage : IProduct
    {
        public int LoanValue { get; set; }
        public int MortgageValue { get; set; }
        public int DebtValue { get; set; }
        public bool CriticalIllness { get; set; }
    }
}