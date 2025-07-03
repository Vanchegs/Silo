namespace Internal.Codebase
{
    public class BootState : State
    {
        private GameManager gameManager;
        
        public BootState(GameManager gameManager) => 
            this.gameManager = gameManager;

        public override void Enter()
        {
            gameManager.InitializeServices();
        }

        public override void Exit()
        {
            gameManager.SceneSwitcher.SwitchScene(Scenes.MainMenuScene);
        }
    }
}