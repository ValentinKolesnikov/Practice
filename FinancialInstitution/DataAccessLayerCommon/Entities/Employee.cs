namespace DataAccessLayerCommon
{
    using System;
    using System.Collections.Generic;
    
    public class Employee
    {
        public Employee()
        {
            this.ServicesHistories = new List<ServicesHistory>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public System.DateTime BirthDay { get; set; }
        public int BranchId { get; set; }
        public int PositionId { get; set; }
    
        public Branch Branch { get; set; }
        public Position Position { get; set; }
        public ICollection<ServicesHistory> ServicesHistories { get; set; }
    }
}
