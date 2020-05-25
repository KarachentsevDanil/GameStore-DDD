using GSP.Shared.Grid.Models.Sorting.Enums;

namespace GSP.Shared.Grid.Models.Sorting
{
    public class SortingModel
    {
        public string PropertyName { get; set; }

        public int Order { get; set; }

        public SortingDirection Direction { get; set; }
    }
}