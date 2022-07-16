namespace MagnetArgs.Rules.Workflow
{
    internal enum Premise
    {
        HasKey,
        HasValue,
        IsRequired,
        IsPresent,
        HasDefault,
        HasParser,
        IsNative,
        IsBoolean,
        IsTyped,
        ExistNamed,
        NamedHasValue,
        None
    }
}
