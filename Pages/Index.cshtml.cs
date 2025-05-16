using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Status.Models;
using Microsoft.EntityFrameworkCore;

namespace Status.Pages
{
public class IndexModel : PageModel

    {
        private readonly Status.Models.AppDbContext _context;

        public IndexModel(Status.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 5;
        public int TotalPages {get; set;}

        public async Task OnGetAsync()
        {
            TotalPages = (int)Math.Ceiling(_context.Products.Count() / (double)PageSize);
    
        Product = await _context.Products.Include(r => r.Reviews!)
        .Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync(); 
        }
    }
}
