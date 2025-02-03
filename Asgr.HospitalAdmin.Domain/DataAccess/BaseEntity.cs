using System.ComponentModel.DataAnnotations;

namespace Asgr.HospitalAdmin.Domain.DataAccess;

public abstract class BaseEntity
{
    [Key] 
    public virtual Guid Id { get; set; }
}