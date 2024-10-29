using System;

namespace Library;

using WhatsAppApiUCU;
public class WhatsAppChannel : IMessageChannel
{
    private readonly WhatsAppApi whatsApp;

    public WhatsAppChannel()
    {
        this.whatsApp = new WhatsAppApi();
    }
    public void Send(Message message)
    {
        if (message is WhatsappMessage) // verifica que sea un mensaje de wpp y no solamente un mensaje o mensaje de tw por ejemplo
        {
            string resultado = whatsApp.Send(message.To, message.Text);
            Console.WriteLine(resultado);
        }
        else
        {
            throw new System.Exception("El mensaje no es de whatsapp");
        }
    }

    public bool canSend(Contact sender, Contact receiver) // verifico que tengan numero de telefono valido, no puedo enviar un mensaje a alguien que no tiene numero
    {
        return !string.IsNullOrEmpty(sender.Phone) && !string.IsNullOrEmpty(receiver.Phone);
    }
}