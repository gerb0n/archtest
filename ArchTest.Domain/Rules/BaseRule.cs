namespace ArchTest.Domain.Rules
{
    public abstract class BaseRule<T>
        where T : IRuleContext
    {
        protected T ParseContext(IRuleContext context)
        {
            return (T)context;
        }
    }
}
