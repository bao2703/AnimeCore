namespace Models.ModalViewModels
{
    public class ModalFooter
    {
        public string SubmitButtonText { get; set; } = "Submit";

        public string CancelButtonText { get; set; } = "Cancel";

        public string SubmitButtonId { get; set; } = "btn-submit";

        public string CancelButtonId { get; set; } = "btn-cancel";

        public string SubmitButtonClass { get; set; } = "btn-submit";

        public string CancelButtonClass { get; set; } = "btn-default";

        public bool OnlyCancelButton { get; set; }
    }
}