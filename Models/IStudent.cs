using System;
namespace Models
{
    public interface IStudent
    {
        System.Collections.Generic.IList<Behavior> Behaviors { get; set; }
        string FirstName { get; set; }
        int Id { get; }
        string LastName { get; set; }
        string Teacher { get; set; }
    }
}
