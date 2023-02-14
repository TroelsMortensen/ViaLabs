namespace Application.CommandHandler;

public interface ICommandHandler<T>
{
    Task Handle(T command);
}