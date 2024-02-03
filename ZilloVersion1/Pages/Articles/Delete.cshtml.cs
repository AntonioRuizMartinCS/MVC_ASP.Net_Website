using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ZilloVersion1.Data;
using ZilloVersion1.Models;

namespace ZilloVersion1.Pages.Articles
{
    public class DeleteModel : PageModel
    {
        private readonly ZilloVersion1.Data.ZilloContext _context;

        public DeleteModel(ZilloVersion1.Data.ZilloContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ApprovedArticle Article { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ApprovedArticles == null)
            {
                return NotFound();
            }

            var article = await _context.ApprovedArticles.FirstOrDefaultAsync(m => m.ApprovedArticleId == id);

            if (article == null)
            {
                return NotFound();
            }
            else 
            {
                Article = article;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ApprovedArticles == null)
            {
                return NotFound();
            }
            var article = await _context.ApprovedArticles.FindAsync(id);

            if (article != null)
            {
                Article = article;
                _context.ApprovedArticles.Remove(Article);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
