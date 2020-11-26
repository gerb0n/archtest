using CQRSlite.Commands;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace ArchTest.Core.Extensions.CqrsLite
{
    public static class CommandSenderExtensions
    {
        public static async Task ValidateAndSend<T>(this ICommandSender commandSender, T command, CancellationToken cancellationToken = default)
            where T : class, ICommand
        {
            var context = new ValidationContext(command);
            Validator.ValidateObject(command, context, true);

            await commandSender.Send(command);
        }
    }
}
