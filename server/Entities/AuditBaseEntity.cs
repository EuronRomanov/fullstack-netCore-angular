namespace server.Entities
{
    public abstract class AuditBaseEntity
    {

        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}
