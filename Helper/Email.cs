using System.Net;
using System.Net.Mail;

namespace CadastroDeContatos.Helper
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;

        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Enviar(string email, string assunto, string mensagem)
        {
            try
            {
                string host = _configuration.GetValue<string>("SMTP:Host");
                string nome = _configuration.GetValue<string>("SMTP:Nome");
                string username = _configuration.GetValue<string>("SMTP:UserName");
                string senha = _configuration.GetValue<string>("SMTP:Senha");
                int porta = _configuration.GetValue<int>("SMTP:Porta");

                // Validar configurações
                if (string.IsNullOrEmpty(host) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(senha) || porta <= 0)
                {
                    // Log ou lançar uma exceção aqui, dependendo dos requisitos do seu aplicativo.
                    // Exemplo de log: Console.WriteLine("Configurações de e-mail inválidas.");
                    return false;
                }

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(username)
                };

                mail.To.Add(email);
                mail.Subject = assunto;
                mail.Body = mensagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(host, porta))
                {
                    smtp.Credentials = new NetworkCredential(username, senha);
                    smtp.EnableSsl = true;

                    // Tratamento de exceções específicas
                    try
                    {
                        smtp.Send(mail);
                        return true;
                    }
                    catch (SmtpException ex)
                    {
                        // Log ou tratamento específico para SmtpException
                        // Exemplo de log: Console.WriteLine($"Erro durante o envio de e-mail: {ex.Message}");
                        return false;
                    }
                    catch (Exception ex)
                    {
                        // Log ou tratamento genérico para outras exceções
                        // Exemplo de log: Console.WriteLine($"Erro inesperado: {ex.Message}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log ou tratamento genérico para exceções ocorridas nas configurações
                // Exemplo de log: Console.WriteLine($"Erro nas configurações: {ex.Message}");
                return false;
            }
        }
    }
}
