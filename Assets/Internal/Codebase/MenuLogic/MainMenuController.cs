using UnityEngine;

namespace Internal.Codebase
{
    public class MainMenuController : MonoBehaviour
    {
        public void GameButtonClick() => 
            GameManager.Instance.SceneSwitcher.SwitchScene(Scenes.GameScene);
    }
}

