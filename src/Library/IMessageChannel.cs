namespace Library;

// Pueden agregar operaciones a esta interfaz.
public interface IMessageChannel
{
        /// <summary>
        /// Envia un mensaje a traves del canal
        /// </summary>
        /// <param name="message">El mensaje que se enviara</param>
        void Send(Message message);
        /// <summary>
        /// Verifica si el mensaje puede enviarse entre el remitente y el destinatario
        /// </summary>
        /// <param name="sender">Contacto del remitente</param>
        /// <param name="receiver">Contacto del destinatario</param>
        /// <returns>Si es true puede enviarse, si es false no puede enviarse</returns>
        bool canSend(Contact sender, Contact receiver); 
}