namespace Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services
{
    public interface ICurrentSessionProvider
    {
        Guid? GetUserId();
    }
}
