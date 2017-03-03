namespace TestCaseStorage.Models.Shared
{
    public enum ControlType
    {
        TextBox,
        Date
    }

    public class EditLineModel
    {
        public EditLineModel(string controlName, string controlValue, ControlType controlType, string placeHolder)
        {
            ControlType = controlType;
            PlaceHolder = placeHolder;
            ControlValue = controlValue;
            ControlName = controlName;
        }

        public string PlaceHolder { get; }
        public ControlType ControlType { get; }
        public string ControlName { get; }
        public string ControlValue { get; }
    }
}