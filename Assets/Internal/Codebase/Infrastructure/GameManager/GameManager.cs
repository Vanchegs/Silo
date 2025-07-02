using UnityEngine;

namespace Internal.Codebase
{
    public class GameManager : MonoBehaviour
    {
        public StateMachine StateMachine = new StateMachine();

        private void Awake()
        {
            StatesRegistration();
            
            StateMachine.ChangeState<BootState>();
        }

        private void StatesRegistration()
        {
            StateMachine.RegisterState(new BootState());
            StateMachine.RegisterState(new GameState());
        }
    }
}