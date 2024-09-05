using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    private PlayerControls playerControls;
    public float HorizontalMove => playerControls.CameraControls.CamMove.ReadValue<float>();

    public InputManager()
    {
        playerControls = new PlayerControls();
    }

    public void EnableCamInputs() => playerControls.CameraControls.Enable();
    public void DisableCamInputs() => playerControls.CameraControls.Disable();
}
