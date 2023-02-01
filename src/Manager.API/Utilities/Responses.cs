using Manager.API.ViewModels;

namespace Manager.API.Utilities
{
    public static class Responses
    {
        public static ResultViewModel ApplicationErrorMessage()
        {
            return new ResultViewModel
            {
                Message = "Ocorreu um erro interno na aplicação, por favor tente novamente.",
                Sucess = false,
                Data = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message)
        {
            return new ResultViewModel
            {
                Message = message,
                Sucess = false,
                Data = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> erros)
        {
            return new ResultViewModel
            {
                Message = message,
                Sucess = false,
                Data = erros
            };
        }

        public static ResultViewModel UnauthorizedErrorMessage()
        {
            return new ResultViewModel
            {
                Message = "A combinação de login e senha do usuário está incorreta!",
                Sucess = false,
                Data = null
            };
        }
    }
}