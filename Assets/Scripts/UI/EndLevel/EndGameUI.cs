using System.Collections.Generic;
using UnityEngine;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private CompletedLevelUI _menuEndGame;
    [SerializeField] private LoseGameUI _lossMenu;
    [SerializeField] private LevelStarCompletedParameters _completedParameters;
    [SerializeField] private List<GameObject> _disableObjects;

    private delegate Material AddStarDelegate(int starNum);

    private int _pointsCount;
    private AddStarDelegate _addStars;

    void Start()
    {
        Enemy[] enemys = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemys)
        {
            _pointsCount += enemy.Points;
        }

        _menuEndGame.gameObject.SetActive(false);
        _lossMenu.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Character character))
        {
            CountingLevelStars();
            DisableObjects();
        }
    }

    public void LoseCanvas()
    {
        Time.timeScale = 0;
        _lossMenu.gameObject.SetActive(true);
        DisableObjects();
    }

    private void CountingLevelStars()
    {
        Time.timeScale = 0;

        _menuEndGame.gameObject.SetActive(true);

        int points = SaveParameters.levelPoints[SaveParameters.levelActive];

        _addStars += AddStar;

        for (int i = 0; i < _completedParameters.CompletedStarPercent.Count; i++)
        {
            if (points >= _pointsCount * _completedParameters.CompletedStarPercent[i])
            {
                SaveParameters.levelStars[SaveParameters.levelActive] = i + 1;
            }
        }

        SaveParameters.money = points / 100;

        _menuEndGame.PointsText.text = points.ToString();

        SaveParameters.levelComplete[SaveParameters.levelActive] = true;

        _addStars(SaveParameters.levelStars[SaveParameters.levelActive]);
    }

    private Material AddStar(int starNum)
    {
        return _menuEndGame.StarsImages[starNum].material = null;
    }

    private void OnDestroy()
    {
        _addStars -= AddStar;
    }

    private void DisableObjects()
    {
        _disableObjects.ForEach(obj => obj.gameObject.SetActive(false));
    }
}
