using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using University.Manager.Project.Financial.Application.Messages;
using University.Manager.Project.Financial.Domain.Entities;
using University.Manager.Project.Financial.Domain.Interfaces;

namespace University.Manager.Project.Financial.Application.MessageConsumer
{
    public class RabbitMQStudentInstallmentConsumer : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string RegistredStudent = "student_financial_installments";
        public RabbitMQStudentInstallmentConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            ConnectionFactory factory = new()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };


            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(RegistredStudent, false, false, false, null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            EventingBasicConsumer consumer = new(_channel);
            consumer.Received += (channel, evt) =>
            {
                string content = Encoding.UTF8.GetString(evt.Body.ToArray());
                StudentEntityRequestMessage vo = JsonSerializer.Deserialize<StudentEntityRequestMessage>(content);
                CreateInstallments(vo).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };

            _channel.BasicConsume(RegistredStudent, false, consumer);
            return Task.CompletedTask;
        }

        private async Task CreateInstallments(StudentEntityRequestMessage model)
        {

            try
            {
                List<CourseInstallments> list = [];
                decimal total = model.TotalValue / 12;
                for (int i = 0; i < 12; i++)
                {
                    list.Add(new CourseInstallments
                    {
                        CreationData = DateTime.Now,
                        PaymentDate = null,
                        UpdatedData = DateTime.Now,
                        DueDate = DateTime.Now.AddMonths(i),
                        InstallmentPrice = total,
                        InstallmentStatus = Domain.Entities.Enums.EInstallmentStatus.Pending,
                        PaymentMethod = Domain.Entities.Enums.EPaymentMethod.Other,
                        StudentId = model.Id,

                    });
                }
                using IServiceScope scope = _serviceProvider.CreateScope();
                ICourseInstallmentsRepository courseInstallmentsRepository = scope.ServiceProvider.GetRequiredService<ICourseInstallmentsRepository>();
                await courseInstallmentsRepository.CreateMany(list);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
