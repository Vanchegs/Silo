using UnityEngine;

namespace Internal.Codebase
{
    public class MainMenuController : MonoBehaviour
    {
        public void GameButtonClick() => 
            SceneSwitcher.SwitchScene(Scenes.GameScene);
    }
}

