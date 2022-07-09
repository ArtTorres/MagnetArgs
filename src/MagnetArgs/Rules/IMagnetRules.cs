namespace MagnetArgs.Rules
{
    internal interface IMagnetRules
    {
        (MagnetAction, Source) Eval(string argumentName, IRulesPremise model);
    }
}
