using System.Collections.Generic;

namespace GSP.Shared.Grid.Models.Searching
{
    public class SearchModel
    {
        public string Term { get; set; }

        public ICollection<string> SearchFields { get; set; }
    }
}