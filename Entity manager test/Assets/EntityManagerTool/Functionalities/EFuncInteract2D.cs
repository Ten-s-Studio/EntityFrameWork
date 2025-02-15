using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class EFuncInteract2D : EnityFunctionality
{
    Type interactableType = typeof(EFuncInteractable);
    public float distance = 5f;
    public LayerMask interactableLayer;
    private Vector2 gizmoDirection;
    
    public override void Activate<T>(EntityLogic logic, T value)
    {
        if (value is Vector2 newValue)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, newValue, distance, interactableLayer);
            
            if (!hit) {
                Debug.Log("No interactable found");
                return;
            }
            EntityLogic interactableEntity = hit.collider.gameObject.GetComponent<EntityLogic>();
            interactableEntity?.PerformFuntionality(interactableType, 1);

            gizmoDirection = newValue;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)gizmoDirection * distance);
    }
}
