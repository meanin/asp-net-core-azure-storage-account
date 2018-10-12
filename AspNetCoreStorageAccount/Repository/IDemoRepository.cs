using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreStorageAccount.Entities;

namespace AspNetCoreStorageAccount.Repository
{
    public interface IDemoRepository
    {
        Task<List<DemoTableEntity>> GetAllRecords();
    }
}