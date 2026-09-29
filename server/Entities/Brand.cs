namespace server.Entities
{
    public class Brand:AuditBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ImageUrl { get; set; }


    }
}
