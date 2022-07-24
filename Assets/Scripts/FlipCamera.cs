using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FlipCamera : MonoBehaviour
{
    public ARCameraManager cameraManager
    {
        get => m_CameraManager;
        set => m_CameraManager = value;
    }

   // public ImageTracking imageTracking;

    [SerializeField]
    ARCameraManager m_CameraManager;

    /// <summary>
    /// On button press callback to toggle the requested camera facing direction.
    /// </summary>
    public void OnSwapCameraButtonPress()
    {
        CameraFacingDirection newFacingDirection;
        switch (m_CameraManager.requestedFacingDirection)
        {
            case CameraFacingDirection.World:
                newFacingDirection = CameraFacingDirection.User;
               // imageTracking.TurnOffAnimals();
                break;
            case CameraFacingDirection.User:
            default:
                newFacingDirection = CameraFacingDirection.World;
                break;
        }
        m_CameraManager.requestedFacingDirection = newFacingDirection;
    }
}
