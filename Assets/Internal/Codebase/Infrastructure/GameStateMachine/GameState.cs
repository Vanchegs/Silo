using UnityEngine;

namespace Internal.Codebase
{
    public class GameState : State
    {
        private GameManager gameManager;
        
        public GameState(GameManager gameManager) => 
            this.gameManager = gameManager;
        
        public override void Enter()
        {
            SceneSwitcher.SwitchScene(Scenes.GameScene);
            Debug.Log("sgfserf");
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}