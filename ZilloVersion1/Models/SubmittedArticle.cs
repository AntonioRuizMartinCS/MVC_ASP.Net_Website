using System.Diagnostics.CodeAnalysis;

namespace ZilloVersion1.Models
{
    public class SubmittedArticle
    {
        public int ArticleId { get; set; }
        [AllowNull]
        public string Title { get; set; }
        [AllowNull]
        public string Body { get; set; }
        [AllowNull]
        public string Author { get; set; }
        [AllowNull]
        public DateTime Date { get; set; }
        [AllowNull]
        public string ImageDescription { get; set; }

        [AllowNull]
        public byte[] ImageData { get; set; }


    }
}
