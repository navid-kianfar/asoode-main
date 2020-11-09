using System;

namespace Asoode.Main.Core.ViewModel.General
{
    public class SiteMapViewModel
    {
        public string Location { get; set; }
        public string Title { get; set; }
        public DateTime LastModified { get; set; }
        public string Priority { get; set; }
    }

    public class RssViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public RssItemViewModel[] Items { get; set; }
    }

    public class RssItemViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}