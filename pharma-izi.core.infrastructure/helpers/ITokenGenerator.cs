

namespace pharma_izi.core.infrastructure.helpers
{
    public interface ITokenGenerator
    {
        public string GenerateJsonWebTokenDoctor(Guid idUser, Guid idTempateReceta, string email);
    }
}
