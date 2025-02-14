using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FuncAttack : EnityFunctionality
{
    public GameObject Ability;

    private Transform castPosition;
    public static Guid funcTypeGuid { get; private set; } = Guid.NewGuid();
    public override void Activate<T>(EntityLogic logic, T value)
    {
       // Need ItemHandler first
       // castPosition = logic.weaponTransform;
       // Instantiate(Ability, castPosition.position, Quaternion.identity);
    }
}
