namespace MagnetArgs.Rules.Workflow
{
    internal enum State
    {
        Ignore,
        Input,
        Required,
        Present,
        Key,
        Default,
        Parse,
        Named,
        SetNative,
        SetTrue,
        SetTyped,
        OutOfFlow
    }
}
