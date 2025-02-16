using System;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IAction
{
    void Execute(EntityLogic logic, InputValue value);
}
public interface IEnityFunctionality 
{ 
    public void Activate<T>(EntityLogic logic, T value);
}
