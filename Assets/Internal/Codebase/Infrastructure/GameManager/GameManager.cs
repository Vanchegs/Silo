using UnityEngine;

namespace Internal.Codebase
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        public StateMachine StateMachine;

        public bool IsServicesInitialized { get; private set; }

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GameManager>();
                
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject("GameManager");
                        _instance = obj.AddComponent<GameManager>();
                    }
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
            _instance = this;
            
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            StateMachine = new StateMachine();
            StatesRegistration();
            StateMachine.ChangeState<BootState>();
        }

        public void InitializeServices()
        {
            ServiceLocator.RegisterService(new EconomyDataService());
            
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