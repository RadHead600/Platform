using System;
using UnityEngine;

public class LevelRestriction : MonoBehaviour
{
    [SerializeField] private GameObject _cameraVM;

    private Vector3 _oldPosition;

    private void Start()
    {
        _oldPosition = _cameraVM.transform.position;
    }

    private void Update()
    {
        if(_cameraVM.transform.position.x > _oldPosition.x)
        {
            gameObject.transform.position += new Vector3(Math.Abs(_cameraVM.transform.position.x - _oldPosition.x), 0, 0);
            _oldPosition.x = _cameraVM.transform.position.x;
        }
    }
}
