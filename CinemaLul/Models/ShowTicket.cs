//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaLul.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShowTicket
    {
        public int Id { get; set; }
        public int show { get; set; }
        public short count { get; set; }
        public System.DateTime at { get; set; }
    
        public virtual Show Show1 { get; set; }
    }
}