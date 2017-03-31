namespace Models.ModalViewModels
{
    public enum ModalSize
    {
        Small,
        Large,
        Medium
    }

    public class Modal
    {
        public string Id { get; set; }

        public ModalSize ModalSize { get; set; }

        public string Message { get; set; }

        public string ModalSizeClass
        {
            get
            {
                switch (ModalSize)
                {
                    case ModalSize.Small:
                        return "modal-sm";
                    case ModalSize.Large:
                        return "modal-lg";
                    default:
                        return "";
                }
            }
        }
    }
}