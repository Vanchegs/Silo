namespace Internal.Codebase
{
    public class GameState : State
    {
        private GameManager gameManager;
        
        public GameState(GameManager gameManager) => 
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