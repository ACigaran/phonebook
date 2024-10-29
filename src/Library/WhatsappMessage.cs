namespace Library;

public class WhatsappMessage : Message
{
    /// <summary>
    /// Constructor de la clase WhatsappMessage
    /// </summary>
    /// <param name="from">Numero de telefono del remitente</param>
    /// <param name="to">Numero de telefono del destinatario</param>
    /// <param name="text">Texto del mensaje</param>
    public WhatsappMessage(string from, string to, string text) : base(from, to, text)
    {
        
    }
}