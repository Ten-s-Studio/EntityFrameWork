using UnityEngine;

public class EFuncVector2Movement : MonoBehaviour, IEFuncMovement
{
    public void Activate<T>(EntityLogic logic, T value)
    {
        if (value is Vector2 newValue)
        {
            logic.rb.linearVelocity = newValue * logic.stats.movementSpeed;
        }
        else
        {
            return;
        }

    }
}
