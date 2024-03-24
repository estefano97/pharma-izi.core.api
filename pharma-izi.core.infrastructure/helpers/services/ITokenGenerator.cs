namespace pharma_izi.core.infrastructure.helpers.services
{
    public interface ITokenGenerator
    {
        public string GenerateJsonWebTokenDoctor(Guid idUser, Guid idTempateReceta, string email);
    }
}
