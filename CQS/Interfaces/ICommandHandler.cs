namespace WorldImporters.CQS.Interfaces;

public interface ICommandHandler<TCommand, TStatus>
    where TCommand : IRequest
    where TStatus : struct
{
    Task<ErrorOr<TStatus>> Handle(TCommand command);
}

//marker interface
public interface IRequest { }