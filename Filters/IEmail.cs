using System.Reflection.Metadata;

namespace PROJECT_GESTOR_V3.Filters
{
    public interface IEmail
    {
        bool Enviar(string email, string assunto, string mensagem);
    }
}
