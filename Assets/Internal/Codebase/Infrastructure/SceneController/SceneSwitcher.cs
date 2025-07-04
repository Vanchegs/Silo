using UnityEngine.SceneManagement;

namespace Internal.Codebase
{
    public static class SceneSwitcher
    {
        public static void SwitchScene(Scenes scene) => 
            SceneManager.LoadScene(scene.ToString());
    }
}