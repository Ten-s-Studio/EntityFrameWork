using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class EFuncAttack : MonoBehaviour, IEnityFunctionality
{
    public GameObject Ability;

    private Transform castPosition;
    public static Guid funcTypeGuid { get; private set; } = Guid.NewGuid();
    public void Activate<T>(EntityLogic logic, T value)
    {
        Debug.Log("Attacked");
       // Need ItemHandler first
       // castPosition = logic.weaponTransform;
       // Instantiate(Ability, castPosition.position, Quaternion.identity);
    }
}
