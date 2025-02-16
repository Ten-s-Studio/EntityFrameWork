using UnityEngine;
using UnityEngine.Events;

public class EFuncInteractable : MonoBehaviour, IEnityFunctionality
{
    public UnityEvent interactableEvent;
    public void Activate<T>(EntityLogic logic, T value){
        interactableEvent.Invoke();
        Debug.Log(logic.gameObject.name +" interacted with " + gameObject.name);
    }
}
