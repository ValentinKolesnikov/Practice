////------------------------------------------------------------------------------
//// <auto-generated>
////     Этот код создан по шаблону.
////
////     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
////     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
//// </auto-generated>
////------------------------------------------------------------------------------

//namespace DataAccessLayerEF
//{
//    using System;
//    using System.Collections.Generic;
    
//    public partial class Client
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public Client()
//        {
//            this.ServicesHistories = new HashSet<ServicesHistory>();
//        }
    
//        public int Id { get; set; }
//        public string FirstName { get; set; }
//        public string SecondName { get; set; }
//        public string MiddleName { get; set; }
//        public System.DateTime BirthDay { get; set; }
//        public string Address { get; set; }
//        public string PassportSeriesAndNumber { get; set; }
//        public string CardNumber { get; set; }
    
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<ServicesHistory> ServicesHistories { get; set; }
//    }
//}