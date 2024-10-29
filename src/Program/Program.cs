using System;
using System.Collections.Generic;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear el contacto dueño
            Contact dueño = new Contact("Agustin");
            dueño.Phone = "+59898039376";
            Phonebook phonebookAgustin = new Phonebook(dueño);
            
            // Crear la lista de contactos
            Contact contact1 = new Contact("Agus");
            contact1.Phone = "+59898039376";
            Contact contact2 = new Contact("Rodri");
            contact2.Phone = "+59898039376";
            
            // Agregar contactos a la lista
            phonebookAgustin.AddContact(contact1);
            phonebookAgustin.AddContact(contact2);
            phonebookAgustin.RemoveContact(contact2);
           
            // Enviar un WhatsApp a algunos contactos
            WhatsAppChannel enviarMensajeWhatsapp = new WhatsAppChannel();
            phonebookAgustin.SendMessage(new[] {contact1.Name, contact2.Name}, "Esto es un mensaje automatico manco", enviarMensajeWhatsapp);
            
        }
    }
}