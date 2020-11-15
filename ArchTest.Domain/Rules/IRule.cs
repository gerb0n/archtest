using CQRSlite.Commands;

namespace ArchTest.Domain.Rules
{
    public interface IRule
    {
        void Execute();
        bool ShouldBeExecuted(ICommand command);
    }
}
