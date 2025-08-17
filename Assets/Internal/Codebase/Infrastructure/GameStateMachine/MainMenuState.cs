namespace Internal.Codebase
{
    public class MainMenuState : State
    {
        private GameManager gameManager;
        
        public MainMenuState(GameManager gameManager) => 
            this.gameManager = gameManager;
        
        public override void Enter()
        {
            SceneSwitcher.SwitchScene(Scenes.MainMenuScene);
        }

        public override void Exit()
        {
            
        }
    }
}