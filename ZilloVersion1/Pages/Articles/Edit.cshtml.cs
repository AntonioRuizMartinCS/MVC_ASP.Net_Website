using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZilloVersion1.Data;
using ZilloVersion1.Models;

namespace ZilloVersion1.Pages.Articles
{
    public class EditModel : PageModel
    {
        private readonly ZilloVersion1.Data.ZilloContext _context;

        public EditModel(ZilloVersion1.Data.ZilloContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ApprovedArticle Article { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ApprovedArticles == null)
            {
                return NotFound();
            }

            var article =  await _context.ApprovedArticles.FirstOrDefaultAsync(m => m.ApprovedArticleId == id);
            if (article == null)
            {
                return NotFound();
            }
            Article = article;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {


            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Article).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(Article.ApprovedArticleId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArticleExists(int id)
        {
          return _context.ApprovedArticles.Any(e => e.ApprovedArticleId == id);
        }
    }
}
