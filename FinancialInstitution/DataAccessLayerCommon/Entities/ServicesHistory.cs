namespace DataAccessLayerCommon
{
    using System;
    using System.Collections.Generic;
    
    public class ServicesHistory
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public int ServicesDirectoryId { get; set; }
        public int ClientId { get; set; }
    
        public Client Client { get; set; }
        public Employee Employee { get; set; }
        public ServicesDirectory ServicesDirectory { get; set; }
    }
}
