//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryWork.sql
{
    using System;
    using System.Collections.Generic;
    
    public partial class Readers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int idInfoReader { get; set; }
        public int idBooks { get; set; }
        public int idBookExtradition { get; set; }
        public int idBookReturn { get; set; }
    
        public virtual Books Books { get; set; }
        public virtual Extradition Extradition { get; set; }
        public virtual InfoReader InfoReader { get; set; }
        public virtual Return Return { get; set; }
    }
}
