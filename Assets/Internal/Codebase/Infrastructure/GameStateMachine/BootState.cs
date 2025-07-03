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
            
            Exit();
        }

        public override void Exit() => 
            gameManager.StateMachine.ChangeState<MainMenuState>();
    }
}