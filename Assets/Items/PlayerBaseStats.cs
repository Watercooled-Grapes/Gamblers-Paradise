using UnityEngine;

[CreateAssetMenu(fileName = "PlayerBaseStats", menuName = "Scriptable Objects/PlayerBaseStats")]
public class PlayerBaseStats : ScriptableObject
{
    #region Movement Stats
    public float acceleration = 10f;
    public float walkSpeed = 5f;
    public float sprintSpeed = 7f;
    public float jumpPower = 5f;
    #endregion
}
