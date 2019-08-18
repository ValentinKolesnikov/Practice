namespace DataAccessLayerCommon
{
    using System;
    using System.Collections.Generic;
    
    public class ServicesDirectory
    {
        public ServicesDirectory()
        {
            this.ServicesHistories = new List<ServicesHistory>();
            this.Branches = new List<Branch>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public ICollection<ServicesHistory> ServicesHistories { get; set; }
        public ICollection<Branch> Branches { get; set; }
    }
}
