using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Status.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Status.Pages;

public class AddReviewModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly ILogger<AddReviewModel> _logger;

    [BindProperty]
    public Review Review {get; set;} = default!;

    public SelectList ProductsDropDown {get;set;} = default!;

    public AddReviewModel(AppDbContext context, ILogger<AddReviewModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {
        ProductsDropDown = new SelectList(_context.Products.ToList(), "ProductID", "Name");
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Reviews.Add(Review);
        _context.SaveChanges();

        return RedirectToPage("./Index");
    }
}