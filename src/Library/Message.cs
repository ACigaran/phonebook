namespace Library;

public class Message
{
    /// <summary>
    /// Constructor de la clase Message
    /// </summary>
    /// <param name="from">Numero de telefono del remitente</param>
    /// <param name="to">Numero de telefono del destinatario</param>
    /// <param name="text">Texto del mensaje</param>
    public Message(string from, string to, string text)
    {
        this.From = from;
        this.To = to;
		this.Text = text;
    }
    public string Text { get; set; }

    public string From { get; }

    public string To { get; }
}