namespace MagnetArgs.Rules
{
    internal interface IRulesPremise
    {
        bool HasKey { get; }

        bool HasValue { get; }

        bool IsNative { get; }

        bool IsTyped { get; }

        bool IsBoolean { get; }

        bool IsRequired { get; }

        bool IsPresent { get; }

        bool ExistNamed { get; }

        bool NamedHasValue { get; }

        bool HasDefault { get; }

        bool HasParser { get; }
    }
}
