using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Interfaces;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers;

public class SubscriptionHandler : Notifiable<Notification>, IHandler<CreateBoletoSubscriptionCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IEmailService _emailService;

    public SubscriptionHandler(IStudentRepository studentRepository, IEmailService emailService)
    {
        _studentRepository = studentRepository;
        _emailService = emailService;
    }

    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
        // Fail Fast Validations
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar sua assinatura");
        }
        
        //Verificar se Documento já está cadastrado
        if (_studentRepository.DocumentExists(command.Document))
            AddNotification("Document", "Este CPF já está em uso");
        
        //Verificar se E-mail já está cadastrado
        if (_studentRepository.EmailExists(command.Email))
            AddNotification("Email", "Este E-mail já está em uso");

        // Gerar os VOs
        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document, command.PayerDocumentType);
        var email = new Email(command.Email);
        var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
        
        // Gerar as entidades
        var student = new Student(name, document, email);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payment = new BoletoPayment(
            command.BarCode,
            command.BoletoNumber,
            command.PaidDate,
            command.ExpireDate,
            command.Total,
            command.TotalPaid,
            document,
            address,
            command.Payer,
            email
        );
        
        //Relacionamentos
        subscription.AddPayment(payment);
        student.AddSubscription(subscription);
        
        // Aplicar as validações de negócio
        AddNotifications(name, document, email, address, student, subscription, payment);
        
        //Checar as notificações
        if (!IsValid)
            return new CommandResult(false, "Não foi possível realizar sua assinatura");
        
        // Salvar as informações
        _studentRepository.CreateSubscription(student);
        
        // Enviar e-mail de boas-vindas
        _emailService.Send(student.Name.ToString()!, student.Email.Address, "Bem vindo ao balta.io", "Sua assinatura foi criada");
        
        return new CommandResult(true, "Assinatura realizada com sucesso");
    }
}