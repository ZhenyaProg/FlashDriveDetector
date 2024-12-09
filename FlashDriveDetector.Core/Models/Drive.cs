namespace FlashDriveDetector.Core.Models
{
    public class Drive
    {
        public string VolumeLabel { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int TotalSize { get; set; }
    }
}