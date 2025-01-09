namespace Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Users
{
    public class UserUpdateRequest
    {
        public required string Id { get; set; } = string.Empty;
        public required string Nombre { get; set; } = string.Empty;
        public required string Telefono { get; set; } = string.Empty;

        public required DireccionRequest Direccion { get; set; }
    }
}
