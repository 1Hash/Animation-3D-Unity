using System;
using UnityEngine;

public static class src_Models
{
    #region - Player -

    [Serializable]
    public class CameraSettingsModel
    {
        [Header("Camera Settings")]
        public float SensivityX;
        public bool InvertedX;
        public float SensivityY;
        public bool InvertedY;

        public float YClampMin = -70f;
        public float YClampMax = 60f;

        [Header("Character")]
        public float CharacterRotationSpeedSmoothdamp = 1f;
    }

    [Serializable]
    public class PlayerSettingsModel
    {
        public float CharacterRotationSmoothdamp = 0.6f;

        [Header("Movement Speeds")]
        public float WalkingSpeed;
        public float RunningSpeed;

        public float WalkingBackwardSpeed;
        public float RunningBackwardSpeed;

        public float WalkingStrafingSpeed;
        public float RunningStrafingSpeed;

        public float SprintingSpeed;

        [Header("Jumping")]
        public float JumpingForce;
    }

    [Serializable]
    public class PlayerStatsModel
    {
        public float Stamina = 100;
        public float MaxSatamina = 100;
        public float StaminaDrain = 4;
        public float StaminaRestore = 8;
        public float StaminaDelay = 2;
        public float StaminaCurrentDelay = 0;
    }

    #endregion
}
