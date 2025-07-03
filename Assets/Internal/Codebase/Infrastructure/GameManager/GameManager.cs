using UnityEngine;

namespace Internal.Codebase
{
    public class GameManager : MonoBehaviour
    {
        public StateMachine StateMachine = new();
        
        public bool IsServicesInitialized { get; private set; }
        
        public SceneSwitcher SceneSwitcher { get; set; }

        private void Awake()
        {
            DontDestroyOnLoad(this);
            
            StatesRegistration();
            
            StateMachine.ChangeState<BootState>();
        }

        public void InitializeServices()
        {
            SceneSwitcher = new SceneSwitcher();
            
            IsServicesInitialized = true;
            StateMachine.ChangeState<MainMenuState>();
        }
        
        private void StatesRegistration()
        {
            StateMachine.RegisterState(new BootState(this));
            StateMachine.RegisterState(new GameState(this));
            StateMachine.RegisterState(new MainMenuState(this));
        }
    }
}