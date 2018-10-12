using Microsoft.WindowsAzure.Storage.Table;

namespace AspNetCoreStorageAccount.Entities
{
    public class DemoTableEntity : TableEntity
    {
        public string OtherColumn { get; set; }
        public string FourthColumn { get; set; }
    }
}