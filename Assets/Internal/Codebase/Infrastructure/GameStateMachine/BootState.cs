namespace Internal.Codebase
{
    public class BootState : State
    {
        private GameManager gameManager;
        
        public BootState(GameManager gameManager) => 
            this.gameManager = gameManager;

        public override void Enter()
        {
            if (gameManager.IsServicesInitialized)
                return;
            
            gameManager.InitializeServices();
        }

        public override void Exit() => 
            SceneSwitcher.SwitchScene(Scenes.MainMenuScene);
    }
}