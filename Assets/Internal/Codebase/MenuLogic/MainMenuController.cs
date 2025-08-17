using UnityEngine;

namespace Internal.Codebase
{
    public class MainMenuController : MonoBehaviour
    {
        private GameManager gameManager;

        private void Start() => 
            gameManager = FindObjectOfType<GameManager>();

        public void GameButtonClick() => 
            gameManager.StateMachine.ChangeState<GameState>();
    }
}

