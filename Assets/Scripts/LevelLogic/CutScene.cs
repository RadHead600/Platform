using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutScene : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] private List<GameObject> _disableGameObjects;

    private CharacterMouseAttack _characterMouseAttack;
    private CharacterJoystickAttack _characterJoystickAttack;
    private EnemyAttack[] _enemiesAttack;

    private void Start()
    {
        _characterJoystickAttack = FindObjectOfType<CharacterJoystickAttack>();
        _characterMouseAttack = FindObjectOfType<CharacterMouseAttack>();
        _enemiesAttack = FindObjectsOfType<EnemyAttack>();
        _characterMouseAttack.enabled = false;
        _characterJoystickAttack.enabled = false;
        ChangeEnemiesEnable(false);
        StartCoroutine(EndCutScene());
    }

    private IEnumerator EndCutScene()
    {
        float timeDifference = 0.5f;
        float waitTime = ((float)_playableDirector.duration) - timeDifference;
        DisableGameObjects(false);
        yield return new WaitForSeconds(waitTime);

        _characterMouseAttack.enabled = true;
        _characterJoystickAttack.enabled = true;
        ChangeEnemiesEnable(true);
        DisableGameObjects(true);
        Destroy(gameObject);
    }

    private void DisableGameObjects(bool isDisable)
    {
        foreach (var obj in _disableGameObjects)
        {
            obj.SetActive(isDisable);
        }
    }

    private void ChangeEnemiesEnable(bool isEnable)
    {
        foreach (EnemyAttack enemy in _enemiesAttack)
        {
            enemy.enabled = isEnable;
        }
    }
}
