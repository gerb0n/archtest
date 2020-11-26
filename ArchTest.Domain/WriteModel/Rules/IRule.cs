using CQRSlite.Commands;

namespace ArchTest.Domain.Rules
{
    public interface IRule
    {
        void Execute(IRuleContext context);
        bool ShouldBeExecuted(ICommand command);
    }
}
