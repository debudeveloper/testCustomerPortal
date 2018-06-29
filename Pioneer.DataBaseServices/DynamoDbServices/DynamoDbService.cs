using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneer.DataBaseServices.DynamoDbServices
{
    public class DynamoDbService : IDynamoDbService
    {
        public readonly DynamoDBContext DbContext;
        public AmazonDynamoDBClient DynamoClient;

        public DynamoDbService()
        {

        }
        public string CreateTable(CreateTableRequest createTableRequest)
        {
            CreateTableResponse createTableResponse = DynamoClient.CreateTable(createTableRequest);

            while (createTableResponse.TableDescription.TableStatus != "ACTIVE")
            {
                System.Threading.Thread.Sleep(5000);
            }
            return createTableResponse.TableDescription.TableStatus.Value.ToString();
        }

        public string UpdateTable(UpdateTableRequest updateTableRequest)
        {
            return "";
        }
        public string DeleteTable(DeleteTableRequest deleteTableRequest)
        {
            return "";
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
    }
}
