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
    public class DetailsModel : PageModel
    {
        private readonly ZilloVersion1.Data.ZilloContext _context;

        public DetailsModel(ZilloVersion1.Data.ZilloContext context)
        {
            _context = context;
        }

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
    }
}
