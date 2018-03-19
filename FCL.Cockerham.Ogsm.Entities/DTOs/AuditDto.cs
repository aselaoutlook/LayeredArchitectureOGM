using System;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class AuditDto
    {
        public long AuditId { get; set; }
        public DateTime EventDateUTC { get; set; }
        public string Action { get; set; }
        public string TableName { get; set; }
        public string UserName { get; set; }
        public string RecordID { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
    }
}
