//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DALQLNS
{
    using System;
    using System.Collections.Generic;
    
    public partial class TangCa
    {
        public int MaTangCa { get; set; }
        public int MaNhanVien { get; set; }
        public Nullable<System.DateTime> Ngay { get; set; }
        public Nullable<int> SoGio { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}