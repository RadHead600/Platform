    using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuUI : MonoBehaviour, IOpenMenu
{
    [SerializeField] private LevelButtonUI[] _levels;

    private const string IS_NOT_COMPLETED = "Не пройдено";
    private const string IS_COMPLETED = "Получено";
    private const string STARS = "звезда(ы)";

    void Start()
    {
        _levels[0].LevelButton.interactable = true;
        _levels[0].CompletedText.text = IS_NOT_COMPLETED;

        for (int i = 1; i < _levels.Length; i++)
        {
            if (SaveParameters.levelStars[i] > 0)
            {
                _levels[i].LevelButton.interactable = true;
                _levels[i].CompletedText.text = $"{IS_COMPLETED} {SaveParameters.levelStars[i]} {STARS}";
                continue;
            }

            _levels[i].CompletedText.text = IS_NOT_COMPLETED;
            _levels[i].LevelButton.interactable = false;
        }
    }

    public void StartLevel(int level)
    {
        SaveParameters.levelActive = level;
        SceneManager.LoadScene(level);
    }

    public void OpenMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
