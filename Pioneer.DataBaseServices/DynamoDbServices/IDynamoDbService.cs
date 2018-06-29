using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneer.DataBaseServices.DynamoDbServices
{
    interface IDynamoDbService
    {
        void Store<T>(T item) where T : new();
        void BatchStore<T>(IEnumerable<T> items) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
        T GetItem<T>(string key) where T : class;
        List<string> GetAllTables();
        string CreateTable(CreateTableRequest createTableRequest);
        string UpdateTable(UpdateTableRequest updateTableRequest);
        string DeleteTable(DeleteTableRequest deleteTableRequest);

    }
}
