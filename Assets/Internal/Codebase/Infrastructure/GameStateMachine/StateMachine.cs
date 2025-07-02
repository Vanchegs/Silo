using System;
using System.Collections.Generic;

namespace Internal.Codebase
{
    public class StateMachine
    {
        private State currentState;

        private Dictionary<Type, State> gameStates = new();

        public void RegisterState<TState>(TState state) where TState : State
        {
            Type stateType = typeof(TState);

            if (!gameStates.ContainsKey(stateType))
                gameStates.Add(stateType, state);
            else
                throw new ArgumentException($"State {stateType.Name} is already registered!");
        }
        
        public void EnterState<TState>() where TState : State
        {
            Type stateType = typeof(TState);

            if (gameStates.TryGetValue(stateType, out State newState))
            {
                currentState?.Exit();
                currentState = newState;
                currentState.Enter();
            }
            else
                throw new KeyNotFoundException($"State {stateType.Name} is not registered!");
        }

        public void ChangeState<TState>() where TState : State => 
            EnterState<State>();

        public void ExitState<TState>()
        {
            currentState?.Exit();
            currentState = null;
        }
        
        public State GetCurrentState<TState>() => 
            currentState;
    }
}