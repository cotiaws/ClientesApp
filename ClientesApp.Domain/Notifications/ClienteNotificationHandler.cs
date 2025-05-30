using ClientesApp.Domain.Interfaces.Storage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Notifications
{
    /// <summary>
    /// Classe para implementar o Notification Handler de clientes
    /// </summary>
    public class ClienteNotificationHandler(IClienteStorage clienteStorage)
        : INotificationHandler<ClienteNotification>
    {
        public async Task Handle(ClienteNotification notification, CancellationToken cancellationToken)
        {
            switch(notification.Action)
            {
                case NotificationAction.Created:
                    await clienteStorage.Insert(notification.Cliente);
                    break;

                case NotificationAction.Updated:
                    await clienteStorage.Update(notification.Cliente);
                    break;

                case NotificationAction.Deleted:
                    await clienteStorage.Deactivate(notification.Cliente.Id);
                    break;
            }
        }
    }
}
