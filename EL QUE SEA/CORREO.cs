using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EL_QUE_SEA
{
    internal class CORREO
    {
        

        public void EnviarCorreo(string error)
        {
            try
            {

                 SmtpClient cliente = new SmtpClient("smtp.office365.com", 587); // Servidor SMTP de Office 365
            cliente.EnableSsl = true;  // Habilitar la conexión SSL
            cliente.Credentials = new NetworkCredential("112977@alumnouninter.mx", "Morelos1");  // Tu correo y contraseña


                // 3. Crear el mensaje de correo
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress("112977@alumnouninter.mx");         // Remitente
                mensaje.To.Add("ecorrales@uninter.edu.mx");                        // Destinatario
                mensaje.Subject = "ERROR EN LA APLICACIÓN";                        // Asunto
                mensaje.Body = $"Se ha producido el siguiente error:\n\n{error}";  // Cuerpo del mensaje

                // 4. Enviar el mensaje
                cliente.Send(mensaje);

                Console.WriteLine("✅ Correo enviado correctamente al profesor.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ No se pudo enviar el correo.");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
    }



