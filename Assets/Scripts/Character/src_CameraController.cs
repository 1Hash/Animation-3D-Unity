using static src_Models;
using UnityEngine;

public class src_CameraController : MonoBehaviour
{
    [Header("References")]
    public src_PlayerController playerController;
    private Vector3 targetRotation;
    public GameObject yGimbal;
    private Vector3 yGimbalRotation;

    [Header("Settings")]
    public CameraSettingsModel settings;
    public float movementSmoothTime = 0.1f;

    #region - Update -
    private void Update()
    {
        CameraRotation();
        FollowPlayerCameraTarget();
    }

    #endregion

    #region - Position / Rotation -
    private void CameraRotation()
    {
        var viewInput = playerController.input_View;

        targetRotation.y += (settings.InvertedX ? -(viewInput.x * settings.SensivityX) : (viewInput.x * settings.SensivityX)) * Time.deltaTime;
        transform.rotation = Quaternion.Euler(targetRotation);

        yGimbalRotation.x += (settings.InvertedY ? (viewInput.y * settings.SensivityY) : -(viewInput.y * settings.SensivityY)) * Time.deltaTime;
        yGimbalRotation.x = Mathf.Clamp(yGimbalRotation.x, settings.YClampMin, settings.YClampMax);

        yGimbal.transform.localRotation = Quaternion.Euler(yGimbalRotation);

        if(playerController.isTargetMode)
        {
            var currentRotation = playerController.transform.rotation;

            var newRotation = currentRotation.eulerAngles;
            newRotation.y = targetRotation.y;

            currentRotation = Quaternion.Lerp(currentRotation, Quaternion.Euler(newRotation), settings.CharacterRotationSpeedSmoothdamp);

            playerController.transform.rotation = currentRotation;
        }
    }

    private void FollowPlayerCameraTarget()
    {
        transform.position = playerController.cameraTarget.position;
    }

    #endregion
}
