namespace MagnetArgs.Rules
{
    internal interface IMagnetRules
    {
        (MagnetAction, Source) Eval(IRulesPremise model);
    }
}
