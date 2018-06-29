using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneer.DataBaseServices.DynamoDbMigrations
{
   public class AdviserTableRequest
    {
        CreateTableRequest GetCreateTableRequest()
        {
            var request = new CreateTableRequest()
            {

            };
            return request;
        }
        UpdateTableRequest GetUpdateTableRequest()
        {
            var request = new UpdateTableRequest()
            {

            };
            return request;
        }

        DeleteTableRequest GetDeleteTableRequest()
        {
            var request = new DeleteTableRequest()
            {

            };
            return request;
        }
    }
}
