using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour, IOpenMenu
{
    [SerializeField] private GameObject _pauseMenu;

    private bool _isPause;

    void Start()
    {
        _pauseMenu.SetActive(false);    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        _isPause = !_isPause;
        Time.timeScale = (_isPause ? 0 : 1);
        _pauseMenu.SetActive(_isPause);
    }

    public void OpenMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void CloseGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
