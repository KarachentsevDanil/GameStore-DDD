using GSP.Shared.Grid.Sorting.Enums;

namespace GSP.Shared.Grid.Sorting
{
    public class SortingModel
    {
        public SortingModel(string propertyName, SortingDirection direction)
        {
            PropertyName = propertyName;
            Direction = direction;
        }

        public string PropertyName { get; set; }

        public SortingDirection Direction { get; set; }

        public override string ToString()
        {
            return $"{PropertyName} {Direction}";
        }
    }
}