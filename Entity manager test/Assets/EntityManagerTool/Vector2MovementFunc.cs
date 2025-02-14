using UnityEngine;

public class Vector2MovementFunc : MovementFunc
{
    public override void Activate<T>(EntityLogic logic, T value)
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
