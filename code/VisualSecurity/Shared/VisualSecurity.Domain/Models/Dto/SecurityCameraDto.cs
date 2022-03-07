namespace VisualSecurity.Domain.Models.Dto
{
    public class SecurityCameraDto
    {
        public int Id
        {
            get { return GenerateId(); }
        }
        public string Camera { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

        private int GenerateId()
        {
            if (int.TryParse(Camera.Substring(7, 3), out var value))
            {
                return value;
            }
            else
            {
                return 0;
            }
        }
    }
}
