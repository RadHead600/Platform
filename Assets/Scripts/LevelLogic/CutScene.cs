using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class CutScene : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector;

    private Character _characterAttack;
    private EnemyAttack[] _enemiesAttack;

    private void Start()
    {
        _characterAttack = FindObjectOfType<Character>();
        _enemiesAttack = FindObjectsOfType<EnemyAttack>();
        _characterAttack.enabled = false;
        ChangeEnemiesEnable(false);
        StartCoroutine(EndCutScene());
    }

    private IEnumerator EndCutScene()
    {
        float timeDifference = 0.5f;
        float waitTime = ((float)_playableDirector.duration) - timeDifference;
        yield return new WaitForSeconds(waitTime);

        _characterAttack.enabled = true;
        ChangeEnemiesEnable(true);
        Destroy(gameObject);
    }

    private void ChangeEnemiesEnable(bool isEnable)
    {
        foreach (EnemyAttack enemy in _enemiesAttack)
        {
            enemy.enabled = isEnable;
        }
    }
}
