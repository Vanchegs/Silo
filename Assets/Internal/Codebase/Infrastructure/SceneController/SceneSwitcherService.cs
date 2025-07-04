using UnityEngine.SceneManagement;

namespace Internal.Codebase
{
    public class SceneSwitcherService : IService
    {
        public void SwitchScene(Scenes scene) => 
            SceneManager.LoadScene(scene.ToString());
    }
}