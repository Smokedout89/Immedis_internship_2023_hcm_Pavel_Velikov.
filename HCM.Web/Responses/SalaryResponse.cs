namespace HCM.Web.Responses;

public class SalaryResponse : BaseResponse<SalaryPayload>
{
}

public class SalaryPayload
{
    public string Id { get; set; } = string.Empty;
    public decimal GrossSalary { get; set; }
    public decimal NetSalary { get; set; }
    public bool BonusAvailable { get; set; }
}