using System;
using System.Collections.Generic;

namespace Internal.Codebase
{
    public class GameStateMachine
    {
        private IGameState currentState;

        private Dictionary<Type, IGameState> gameStates = new();

        public void RegisterState<TState>(TState state) where TState : IGameState
        {
            Type stateType = typeof(TState);

            if (!gameStates.ContainsKey(stateType))
                gameStates.Add(stateType, state);
            else
                throw new ArgumentException($"State {stateType.Name} is already registered!");
        }
        
        public void EnterState<TState>() where TState : IGameState
        {
            Type stateType = typeof(TState);

            if (gameStates.TryGetValue(stateType, out IGameState newState))
            {
                currentState?.Exit();
                currentState = newState;
                currentState.Enter();
            }
            else
                throw new KeyNotFoundException($"State {stateType.Name} is not registered!");
        }

        public void ChangeState<TState>() where TState : IGameState => 
            EnterState<TState>();

        public void ExitState<TState>()
        {
            currentState?.Exit();
            currentState = null;
        }
        
        public IGameState GetCurrentState<TState>() => 
            currentState;
    }
}