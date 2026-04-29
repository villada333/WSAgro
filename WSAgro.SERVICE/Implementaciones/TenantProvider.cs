using WSAgro.DAO.Interfaces;

namespace WSAgro.SERVICE.Implementaciones;

public class TenantProvider : ITenantProvider
{
    private string _tenantId;

    public string GetTenantId()
    {
        return _tenantId;
    }

    public void SetTenantId(string tenantId)
    {
        _tenantId = tenantId;
    }
}
