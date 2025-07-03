namespace Internal.Codebase
{
    public class BootState : State
    {
        private GameManager gameManager;
        
        public BootState(GameManager gameManager) => 
            this.gameManager = gameManager;

        public override void Enter()
        {
            throw new System.NotImplementedException();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}