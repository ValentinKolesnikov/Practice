namespace DataAccessLayerCommon
{
    using System;
    using System.Collections.Generic;
    
    public class Client
    {
        public Client()
        {
            this.ServicesHistories = new List<ServicesHistory>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public System.DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string PassportSeriesAndNumber { get; set; }
        public string CardNumber { get; set; }
    
        public ICollection<ServicesHistory> ServicesHistories { get; set; }
    }
}
