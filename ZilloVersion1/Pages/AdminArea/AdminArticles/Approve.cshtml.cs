using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ZilloVersion1.Models;

namespace ZilloVersion1.Pages.AdminArea
{
    public class ApproveModel : PageModel
    {
        private readonly ZilloVersion1.Data.ZilloContext _context;

        public ApproveModel(ZilloVersion1.Data.ZilloContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SubmittedArticle Article { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SubmittedArticles == null)
            {
                return NotFound();
            }

            var article = await _context.SubmittedArticles.FirstOrDefaultAsync(m => m.ArticleId == id);

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
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.SubmittedArticles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            var approvedArticle = new ApprovedArticle {

                //ApprovedArticleId = article.ArticleId,

                Author = article.Author,

                Body = article.Body,

                Date = DateTime.Now,

                ImageData = article.ImageData,

                ImageDescription = article.ImageDescription,

                Title = article.Title


        };

            _context.ApprovedArticles.Add(approvedArticle);

           

            // Remove the article from the current table
            _context.SubmittedArticles.Remove(article);

            // Save changes to the database
            await _context.SaveChangesAsync();

            return RedirectToPage("./SubmittedArticles");



        }
    }
}
