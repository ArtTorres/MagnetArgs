using MagnetArgs.Rules.Workflow;

namespace MagnetArgs.Rules
{
    internal class MagnetRules : IMagnetRules
    {
        private RuleWorkflow _flow;
        private State _previousState = State.OutOfFlow;
        private Source _source = Source.None;

        public MagnetRules()
        {
            _flow = new RuleWorkflow();
        }

        public (MagnetAction, Source) Eval(IRulesPremise premise)
        {
            try
            {
                _flow.ResetState();

                var state = GetState(premise);

                switch (state)
                {
                    case State.SetNative:
                        return (MagnetAction.SetNative, _source);
                    case State.SetTyped:
                        return (MagnetAction.SetTyped, _source);
                    case State.SetTrue:
                        return (MagnetAction.SetTrue, _source);
                    default:
                        return (MagnetAction.Ignore, _source);
                }
            }
            catch
            {
                throw;
            }
        }

        private State GetState(IRulesPremise model)
        {
            _previousState = _flow.State;

            if (_flow.State == State.Ignore)
            {
                if (model.ExistNamed)
                    ChangeState(Premise.ExistNamed);

                else if (model.HasValue)
                    ChangeState(Premise.HasValue);

                else if (model.IsRequired)
                    ChangeState(Premise.IsRequired);

                else if (model.IsPresent)
                    ChangeState(Premise.IsPresent);

                else if (model.HasDefault)
                    ChangeState(Premise.HasDefault);
            }
            else if (_flow.State == State.Input)
            {
                if (model.IsNative)
                    ChangeState(Premise.IsNative);

                else if (model.IsTyped)
                    ChangeState(Premise.IsTyped);
            }
            else if (_flow.State == State.Default)
            {
                if (model.IsNative)
                    ChangeState(Premise.IsNative);

                else if (model.IsTyped)
                    ChangeState(Premise.IsTyped);
            }
            else if (_flow.State == State.Required)
            {
                if (model.HasDefault)
                    ChangeState(Premise.HasDefault);

                else
                    throw new ArgumentNotFoundException("Required");
            }
            else if (_flow.State == State.Present)
            {
                if (model.HasKey)
                    ChangeState(Premise.HasKey);
            }
            else if (_flow.State == State.Key)
            {
                if (model.IsBoolean)
                    ChangeState(Premise.IsBoolean);

                else if (model.HasDefault)
                    ChangeState(Premise.HasDefault);

                else
                    throw new DefaultIsMissingException("Present");
            }
            else if (_flow.State == State.Named)
            {
                if (model.HasValue)
                    ChangeState(Premise.HasValue);

                else if (model.NamedHasValue)
                    ChangeState(Premise.NamedHasValue);
            }
            else if (_flow.State == State.Parse)
            {
                if (model.HasParser)
                    ChangeState(Premise.HasParser);
                else
                {
                    throw new MissingParserException("Parse");
                }
            }

            if (_previousState == _flow.State)
            {
                return _flow.State;
            }

            return GetState(model);
        }

        private void ChangeState(Premise premise)
        {
            var state = _flow.ChangeState(premise);

            switch (state)
            {
                case State.Input:
                    _source= Source.Input;
                    break;
                case State.Default:
                    _source= Source.Default;
                    break;
            }
        }
    }
}
