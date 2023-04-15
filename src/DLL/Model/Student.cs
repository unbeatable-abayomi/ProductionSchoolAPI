using System;
using DLL.Model.Interfaces;

namespace DLL.Model
{
    public class Student : ISoftDeletable, ITrackable
    {
        public int StudentId  {get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //dotnet ef migrations add InitialMigration --project "DLL" --startup-project "API"
        // dotnet ef database update --project "DLL" --startup-project "API"

        public DateTimeOffset CreatedAt { get; set; }
        public string Createdby { get; set; }
        public DateTimeOffset LastUpdatedAt { get; set; }
        public string LastUpdatedby { get; set; }
    }
}