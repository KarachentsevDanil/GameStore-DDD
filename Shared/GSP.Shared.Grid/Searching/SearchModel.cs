using System.Collections.Generic;

namespace GSP.Shared.Grid.Searching
{
    public class SearchModel
    {
        public string Term { get; set; }

        public ICollection<string> SearchFields { get; set; }
    }
}