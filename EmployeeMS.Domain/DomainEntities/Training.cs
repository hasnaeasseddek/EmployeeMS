namespace EmployeeMS.Domain.DomainEntities
{
    public class Training : BaseDomainEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<EmployeeTraining> Participants { get; set; }
    }
}
