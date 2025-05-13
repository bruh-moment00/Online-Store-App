namespace Online_Store_Backend.Domain.Base.Dto
{
    public abstract class BaseDto
    {
        public long ID { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
