using UnityEngine.SceneManagement;

namespace Internal.Codebase
{
    public class SceneSwitcher
    {
        public void SwitchScene(Scenes scene) => 
            SceneManager.LoadScene(scene.ToString());
    }
}