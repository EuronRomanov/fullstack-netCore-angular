namespace server.Entities
{
    public abstract class AuditBaseEntity
    {

        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}
