namespace SendEmailService.Commands.Infrastructure
{
    public class CommandExecutor
    {
        /// <summary>
        ///     Executes the command for commands with a result.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="cmd">The CMD.</param>
        /// <returns></returns>
        public static TResult ExecuteCommand<TResult>(Command<TResult> cmd) where TResult : class
        {
            cmd.Run();

            return cmd.Result;
        }
    }
}