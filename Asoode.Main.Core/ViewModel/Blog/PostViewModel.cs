using System;
using System.Text.Encodings.Web;
using Asoode.Main.Core.ViewModel.General;

namespace Asoode.Main.Core.ViewModel.Blog
{
    public class PostViewModel : BaseViewModel
    {
        public int Index { get; set; }
        public Guid BlogId { get; set; }
        public Guid? CategoryId { get; set; }
        public string Culture { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string NormalizedTitle { get; set; }
        public string Summary { get; set; }
        public string Text { get; set; }
        public string ThumbImage { get; set; }
        public string MediumImage { get; set; }
        public string LargeImage { get; set; }
        public string Key { get; set; }
        public string EmbedCode { get; set; }

        public string Permalink(string domain) => $"https://{domain}/{Culture}/post/{Key}/{UrlEncoder.Default.Encode(NormalizedTitle)}";
    }
}