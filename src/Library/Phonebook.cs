using System.Collections.Generic;

namespace Library;

public class Phonebook
{
    private List<Contact> persons;
    
    /// <summary>
    /// Constructor de la clase Phonebook
    /// </summary>
    /// <param name="owner">Contacto del dueño de la agenda</param>
    public Phonebook(Contact owner)
    {
        this.Owner = owner;
        this.persons = new List<Contact>();
    }
    
    /// <summary>
    /// Dueño de la agenda
    /// </summary>
    public Contact Owner { get; }
    
    /// <summary>
    /// Busca los contactos por nombre
    /// </summary>
    /// <param name="names">Array con los nombres que deseo buscar en la lista de contactos</param>
    /// <returns>Lista de contactos que quiero enviar mensaje y estan en mi agenda</returns>
    public List<Contact> Search(string[] names)
    {
        List<Contact> result = new List<Contact>();

        foreach (Contact person in this.persons)
        {
            foreach (string name in names)
            {
                if (person.Name.Equals(name))
                {
                    result.Add(person);
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Agrego un contacto a la agenda
    /// </summary>
    /// <param name="friend">Contacto que se agregara</param>
    public void AddContact(Contact friend)
    {
        this.persons.Add(friend);
    }

    /// <summary>
    /// Elimino un contacto de mi agenda
    /// </summary>
    /// <param name="friend">Contacto que se eliminara</param>
    public void RemoveContact(Contact friend)
    {
        this.persons.Remove(friend);
    }

    /// <summary>
    /// Envia un mensaje a una lista de contactos a traves de una aplicacion (en este caso wpp)
    /// </summary>
    /// <param name="contactNames">Nombre de los contactos a los que enviare mensajes</param>
    /// <param name="text">Texto del mensaje a enviar</param>
    /// <param name="channel">aplicacion a traves de la que enviare el mensaje (en este caso wpp)</param>
    /// <exception cref="Exception">Si no encuentra la aplicacion o canal de mensajeria devolvera un error</exception>
    public void SendMessage(string[] contactNames, string text, IMessageChannel channel)
    {
        List<Contact> recipients = Search(contactNames); // creo una nueva lista de contactos, sera a quien quiero enviarle y este en mi lista de "agendados"
        foreach (Contact recipient in recipients)
        {
            if (channel.canSend(Owner, recipient))  // verifica si los numeros del que envia y el que recibe son validos
            {
                Message message;
                if (channel is WhatsAppChannel)     // verifico que sea un canal de whatsapp
                {
                    message = new WhatsappMessage(Owner.Phone, recipient.Phone, text);      // cambio el message a message de wpp
                }
                else
                {
                    throw new System.Exception("Canal no encontrado.");
                }
                
                channel.Send(message);  // envio en message
            }
        }
    }
}