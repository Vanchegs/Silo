using UnityEngine;

namespace Internal.Codebase
{
    public class GameManager : MonoBehaviour
    {
        public StateMachine StateMachine = new();

        private void Awake()
        {
            DontDestroyOnLoad(this);
            
            StatesRegistration();
            
            StateMachine.ChangeState<BootState>();
        }

        private void StatesRegistration()
        {
            StateMachine.RegisterState(new BootState(this));
            StateMachine.RegisterState(new GameState(this));
            StateMachine.RegisterState(new MainMenuState(this));
        }
    }
}