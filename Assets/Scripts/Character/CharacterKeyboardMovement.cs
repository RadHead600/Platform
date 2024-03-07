using UnityEngine;

public class CharacterKeyboardMovement : CharacterMovement
{
    private float _horizontalForce;

    void Start()
    {
    }

    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        _horizontalForce = Input.GetAxis("Horizontal");
        Move(_horizontalForce);
        if (Input.GetButtonDown("Jump") && Grounded())
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AcrossPlatform();
        }
#endif
    }
}
