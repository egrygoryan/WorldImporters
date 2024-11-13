namespace WorldImporters.CQS.Interfaces;

public interface IQueryHandler<TQuery, TResult>
{
    Task<ErrorOr<TResult>> Handle(TQuery query);
}
