namespace TestCaseStorage.Models.Shared
{
    public class InfoLineModel
    {
        public InfoLineModel(string label, string value)
        {
            Label = label;
            Value = value;
        }

        public string Label { get; set; }
        public string Value { get; set; }
    }
}