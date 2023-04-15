using System;

namespace DLL.Model.Interfaces
{
    public interface ITrackable
    {
        DateTimeOffset CreatedAt { get; set; }
        string Createdby { get; set; }
        DateTimeOffset LastUpdatedAt { get; set; }
        string LastUpdatedby { get; set; }
        // DateTimeOffset CreatedAt { get; set; }
        // string Createdby { get; set; }
    }
}