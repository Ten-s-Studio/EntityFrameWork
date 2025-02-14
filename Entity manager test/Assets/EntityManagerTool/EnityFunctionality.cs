using System;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IAction
{
    void Execute(EntityLogic logic, InputValue value);
}
public abstract class EnityFunctionality : MonoBehaviour
{ 
    public abstract void Activate<T>(EntityLogic logic, T value);
}
