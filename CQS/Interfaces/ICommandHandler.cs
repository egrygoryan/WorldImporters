namespace WorldImporters.CQS.Interfaces;

public interface ICommandHandler<TCommand> where TCommand : IRequest
{
    Task Handle(TCommand command);
}

//marker interface
public interface IRequest { }