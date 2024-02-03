using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ZilloVersion1.Models;

namespace ZilloVersion1.Pages.AdminArea
{
    public class SubmittedArticlesModel : PageModel
    {
        private readonly ZilloVersion1.Data.ZilloContext _context;

        public SubmittedArticlesModel(ZilloVersion1.Data.ZilloContext context)
        {
            _context = context;
        }

        public IList<SubmittedArticle> Article { get; set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.SubmittedArticles != null)
            {
                Article = await _context.SubmittedArticles.ToListAsync();

            }
        }
    }
}

