namespace NLayer.Core.Entity
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
