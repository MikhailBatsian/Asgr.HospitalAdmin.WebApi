namespace Asgr.HospitalAdmin.WebApi.Models.Response;

public class PagingResponseModel<T>
{
    public int TotalCount { get; set; }

    public IList<T> Items { get; set; }
}
