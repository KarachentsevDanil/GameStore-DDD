using GSP.Shared.Grid.Sorting.Enums;

namespace GSP.Shared.Grid.Sorting
{
    public class SortingModel
    {
        public string PropertyName { get; set; }

        public int Order { get; set; }

        public SortingDirection Direction { get; set; }
    }
}