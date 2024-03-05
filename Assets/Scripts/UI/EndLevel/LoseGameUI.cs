using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGameUI : MonoBehaviour, IOpenMenu
{
    public void ReloadGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SaveParameters.levelActive);
    }

    public void OpenMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
