//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicSchool
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public decimal Summ { get; set; }
        public System.DateTime Date { get; set; }
        public System.DateTime PaidFor { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
