namespace MagnetArgs.Rules.Workflow
{
    internal class RuleWorkflow
    {
        public State State { get; private set; }

        public Premise FlowInput { get; private set; }

        private State[,] _stateMachine;

        public RuleWorkflow()
        {
            _stateMachine = new State[,] {
            //    Ignore            Input               Required           Present              Key                 Default             Parse               Named               SetNative           SetTrue           SetTyped
                { State.OutOfFlow,  State.OutOfFlow,    State.OutOfFlow,   State.Key,           State.OutOfFlow,    State.OutOfFlow,    State.OutOfFlow,    State.OutOfFlow,    State.SetNative,    State.SetTrue,    State.SetTyped }, // HasKey
                { State.Input,      State.OutOfFlow,    State.OutOfFlow,   State.OutOfFlow,     State.OutOfFlow,    State.OutOfFlow,    State.OutOfFlow,    State.Input,        State.SetNative,    State.SetTrue,    State.SetTyped }, // HasValue
                { State.Required,   State.OutOfFlow,    State.OutOfFlow,   State.OutOfFlow,     State.OutOfFlow,    State.OutOfFlow,    State.OutOfFlow,    State.OutOfFlow,    State.SetNative,    State.SetTrue,    State.SetTyped }, // IsRequired
                { State.Present,    State.OutOfFlow,    State.OutOfFlow,   State.OutOfFlow,     State.OutOfFlow,    State.OutOfFlow,    State.OutOfFlow,    State.OutOfFlow,    State.SetNative,    State.SetTrue,    State.SetTyped }, // IsPresent
                { State.Default,    State.OutOfFlow,    State.Default,     State.OutOfFlow,     State.Default,      State.OutOfFlow,    State.OutOfFlow,    State.OutOfFlow,    State.SetNative,    State.SetTrue,    State.SetTyped }, // HasDefault
                { State.OutOfFlow,  State.OutOfFlow,    State.OutOfFlow,   State.OutOfFlow,     State.OutOfFlow,    State.OutOfFlow,    State.SetTyped,     State.OutOfFlow,    State.SetNative,    State.SetTrue,    State.SetTyped }, // HasParser
                { State.OutOfFlow,  State.SetNative,    State.OutOfFlow,   State.OutOfFlow,     State.OutOfFlow,    State.SetNative,    State.OutOfFlow,    State.OutOfFlow,    State.SetNative,    State.SetTrue,    State.SetTyped }, // IsNative
                { State.OutOfFlow,  State.OutOfFlow,    State.OutOfFlow,   State.OutOfFlow,     State.SetTrue,      State.OutOfFlow,    State.OutOfFlow,    State.OutOfFlow,    State.SetNative,    State.SetTrue,    State.SetTyped }, // IsBoolean
                { State.OutOfFlow,  State.Parse,        State.OutOfFlow,   State.OutOfFlow,     State.OutOfFlow,    State.Parse,        State.OutOfFlow,    State.OutOfFlow,    State.SetNative,    State.SetTrue,    State.SetTyped }, // IsTyped
                { State.Named,      State.OutOfFlow,    State.OutOfFlow,   State.OutOfFlow,     State.OutOfFlow,    State.OutOfFlow,    State.OutOfFlow,    State.OutOfFlow,    State.SetNative,    State.SetTrue,    State.SetTyped }, // ExistNamed
                { State.OutOfFlow,  State.OutOfFlow,    State.OutOfFlow,   State.OutOfFlow,     State.OutOfFlow,    State.OutOfFlow,    State.OutOfFlow,    State.Required,     State.SetNative,    State.SetTrue,    State.SetTyped }, // NamedHasValue
            };

            ResetState();
        }

        public State ChangeState(Premise premise)
        {
            State = _stateMachine[(int)premise, (int)State];

            return State;
        }

        public void ResetState()
        {
            State = State.Ignore;
            FlowInput = Premise.None;
        }
    }
}
