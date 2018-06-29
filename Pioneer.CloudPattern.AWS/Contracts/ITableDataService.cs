using Amazon.DynamoDBv2.DocumentModel;
using Pioneer.BusinessEntities.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneer.CloudPattern.AWS.Contracts
{
    public interface ITableDataService
    {
        void Store<T>(T item) where T : new();
        void BatchStore<T>(IEnumerable<T> items) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
        T GetItem<T>(string key) where T : class;
        List<string> GetAllTables();
        string InitTableProcess();
        IEnumerable<T> GetEnumerable<T>(string hasKey, string rangeKey) where T : class;
        IEnumerable<T> QueryItem<T>(string key, string value, QueryOperationConfig config) where T : class;
        void UpdateCustomerAuthItem(CustomerAPI item);
        void UpdateMultipleAttributes(CustomerAPI obj);
    }
}