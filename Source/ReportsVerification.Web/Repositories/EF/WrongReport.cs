//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReportsVerification.Web.Repositories.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class WrongReport
    {
        public System.Guid Id { get; set; }
        public string Content { get; set; }
        public string FileName { get; set; }
        public System.DateTime DateCreate { get; set; }
        public string Message { get; set; }
        public System.Guid SessionId { get; set; }
    
        public virtual Session Session { get; set; }
    }
}
