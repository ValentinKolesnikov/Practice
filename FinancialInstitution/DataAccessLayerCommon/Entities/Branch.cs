namespace DataAccessLayerCommon
{
    using System;
    using System.Collections.Generic;
    
    public class Branch
    {    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    
        public ICollection<Employee> Employees { get; set; }
        public ICollection<ServicesDirectory> ServicesDirectories { get; set; }

        public Branch()
        {
            this.Employees = new List<Employee>();
            this.ServicesDirectories = new List<ServicesDirectory>();
        }
    }
}
