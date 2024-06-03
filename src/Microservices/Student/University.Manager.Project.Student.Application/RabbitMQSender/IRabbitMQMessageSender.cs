using University.Manager.Project.MessageBus;

namespace University.Manager.Project.Student.Application.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
