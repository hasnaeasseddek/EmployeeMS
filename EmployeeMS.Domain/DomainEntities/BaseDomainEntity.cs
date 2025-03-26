namespace EmployeeMS.Domain.DomainEntities
{
    public class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? ModifiedBY { get; set; }

    }
}
