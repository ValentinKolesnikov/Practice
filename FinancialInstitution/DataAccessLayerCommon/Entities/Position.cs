namespace DataAccessLayerCommon
{
    using System;
    using System.Collections.Generic;
    
    public class Position
    {
        public Position()
        {
            this.Employees = new List<Employee>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Flag { get; set; }
    
        public ICollection<Employee> Employees { get; set; }
    }
}
