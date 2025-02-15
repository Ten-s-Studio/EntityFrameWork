using UnityEngine;
using UnityEngine.Events;

public class EFuncInteractable : EnityFunctionality
{
    public UnityEvent interactableEvent;
    public override void Activate<T>(EntityLogic logic, T value){
        interactableEvent.Invoke();
        Debug.Log(logic.gameObject.name +" interacted with " + gameObject.name);
    }
}
