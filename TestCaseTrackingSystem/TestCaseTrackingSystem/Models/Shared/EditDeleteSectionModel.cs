namespace TestCaseStorage.Models.Shared
{
    public class EditDeleteSectionModel
    {
        public EditDeleteSectionModel(string controller, string deleteItemName, object hiddenIdentifier, string editAction = "Edit", string deleteAction = "Delete")
        {
            Controller = controller;
            DeleteItemName = deleteItemName;
            HiddenIdentifier = hiddenIdentifier;
            EditAction = editAction;
            DeleteAction = deleteAction;
        }

        public string DeleteItemName { get; set; }
        public string Controller { get; set; }
        public string EditAction { get; set; }
        public string DeleteAction { get; set; }
        public object HiddenIdentifier { get; set; }
    }
}