using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerNew : MonoBehaviour
{
    public PlayerControls playerControls;

    // Start is called before the first frame update
    void OnEnable()
    {
        playerControls = new PlayerControls();
        playerControls.Gameplay.Enable();

        playerControls.Gameplay.Jump.started += OnJump;
    }

    void OnDisable()
    {
        playerControls.Gameplay.Jump.started -= OnJump;
        playerControls.Gameplay.Disable();

    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
    }
}
