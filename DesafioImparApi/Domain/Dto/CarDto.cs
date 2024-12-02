namespace Domain.Dto
{
    public class CarDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public PhotoDto Photo { get; set; }
    }
}
