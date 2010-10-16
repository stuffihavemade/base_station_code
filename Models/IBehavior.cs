using System;
namespace Models
{
    public interface IBehavior
    {
        int Id { get; }
        DateTime TimeRecorded { get; set; }
    }
}
