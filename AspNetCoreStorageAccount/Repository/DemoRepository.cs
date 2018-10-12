using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreStorageAccount.Entities;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AspNetCoreStorageAccount.Repository
{
    public class DemoRepository : IDemoRepository
    {
        private readonly CloudTable _table;

        public DemoRepository(string connectionString, string tableName)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            _table = tableClient.GetTableReference(tableName);
        }

        public async Task<List<DemoTableEntity>> GetAllRecords()
        {
            var tableQuery = new TableQuery<DemoTableEntity>();

            var results = new List<DemoTableEntity>();
            TableContinuationToken continuationToken = null;
            do
            {
                var segment = await _table.ExecuteQuerySegmentedAsync(tableQuery, continuationToken);
                continuationToken = segment.ContinuationToken;
                results.AddRange(segment.Results);
            }
            while (continuationToken != null);

            return results;
        }
    }
}
