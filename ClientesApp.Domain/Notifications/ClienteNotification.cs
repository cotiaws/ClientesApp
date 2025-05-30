using ClientesApp.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Notifications
{
    /// <summary>
    /// Define os dados que serão enviados para o MongoDB
    /// e que tipos de ações serão capturados pelo Notification
    /// </summary>
    public class ClienteNotification : INotification
    {
        public ClienteQuery? Cliente { get; set; } //dados do cliente
        public NotificationAction Action { get; set; } //tipo de ação
    }

    /// <summary>
    /// Enum para definir os tipos de ações
    /// </summary>
    public enum NotificationAction
    {
        Created = 1, //Ação de criação
        Updated = 2, //Ação de edição
        Deleted = 3  //Ação de exclusão
    }
}
