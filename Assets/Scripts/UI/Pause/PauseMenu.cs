using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour, IOpenMenu
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private List<GameObject> _disableObjects;

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
        _disableObjects.ForEach(obj => obj.gameObject.SetActive(!_isPause));
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
