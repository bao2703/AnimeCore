namespace Models.ClaimViewModels
{
    public class ClaimViewModel
    {
        public string Action { get; set; }

        public string Controller { get; set; }

        public bool IsLocked { get; set; }
    }
}