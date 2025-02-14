using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FuncMovement : EnityFunctionality
{
    public static Guid funcTypeGuid { get; private set; } = Guid.NewGuid();

    public override void Activate<T>(EntityLogic logic, T value)
    {
     
    }
}



