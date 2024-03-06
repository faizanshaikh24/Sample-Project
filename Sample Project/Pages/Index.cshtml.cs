using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sample_Project.Model;
using Sample_Project.Services;

namespace Sample_Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<SampleClass> SampleList;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            SampleService service = new SampleService();
            SampleList = service.GetSampleData();
        }
    }
}
