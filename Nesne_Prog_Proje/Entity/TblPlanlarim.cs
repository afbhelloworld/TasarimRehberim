//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nesne_Prog_Proje.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblPlanlarim
    {
        public int ID { get; set; }
        public string PlanAd { get; set; }
        public string PlanAciklama { get; set; }
        public string PlanTur { get; set; }
        public Nullable<bool> Durum { get; set; }
        public Nullable<System.DateTime> TarihStart { get; set; }
        public string Saat { get; set; }
        public Nullable<System.DateTime> TarihFinish { get; set; }
    }
}
