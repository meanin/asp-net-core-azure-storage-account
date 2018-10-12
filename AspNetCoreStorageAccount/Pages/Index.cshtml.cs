using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreStorageAccount.Entities;
using AspNetCoreStorageAccount.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreStorageAccount.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDemoRepository _demoRepository;

        public List<DemoTableEntity> Entities { get; set; }

        public IndexModel(IDemoRepository demoRepository)
        {
            _demoRepository = demoRepository;
        }

        public async Task OnGetAsync()
        {
            Entities = await _demoRepository.GetAllRecords();
        }
    }
}
