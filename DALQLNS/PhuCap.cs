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
    
    public partial class PhuCap
    {
        public int MaPhuCap { get; set; }
        public int MaNhanVien { get; set; }
        public int MaLoaiPhuCap { get; set; }
        public string NoiDung { get; set; }
    
        public virtual LoaiPhuCap LoaiPhuCap { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
