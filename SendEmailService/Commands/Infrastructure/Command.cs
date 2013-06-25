namespace SendEmailService.Commands.Infrastructure
{
    public abstract class Command<T> where T : class
    {
        public T Result { get; protected set; }

        public abstract void Execute();

        public abstract override string ToString();

        public virtual void Run()
        {
            Execute();
        }
    }
}