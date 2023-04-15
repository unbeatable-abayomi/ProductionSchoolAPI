using System;
using DLL.Model.Interfaces;

namespace DLL.Model
{
    public class Department : ISoftDeletable, ITrackable
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public string Createdby { get; set; }
        public DateTimeOffset LastUpdatedAt { get; set; }
        public string LastUpdatedby { get; set; }
    }
    

}