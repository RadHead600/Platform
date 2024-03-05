using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompletedLevelUI : MonoBehaviour, IOpenMenu
{
    [SerializeField] private List<Image> _starsImages;
    [SerializeField] private TextMeshProUGUI _pointsText;

    public List<Image> StarsImages => _starsImages;
    public TextMeshProUGUI PointsText => _pointsText;

    public void OpenNextLevel()
    {
        SaveParameters.levelActive++;

        if (SceneManager.sceneCountInBuildSettings > SaveParameters.levelActive)
        {
            SceneManager.LoadScene(SaveParameters.levelActive);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void OpenMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
