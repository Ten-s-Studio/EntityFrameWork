using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerEntityInputManager : MonoBehaviour
{
    #region Static check
    public static PlayerEntityInputManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion

    public GameObject currentEntity;

    private EntityLogic entityLogic;

    private bool noEnityLogic = true;

    private Vector2 LastDirection;

    void Start()
    {
        EntitySetup();
    }

    private void OnMove(InputValue value)
    {
        if (noEnityLogic)
            return;
        
        LastDirection = value.Get<Vector2>();
        entityLogic.PerformFuntionality<IEFuncMovement,Vector2>(LastDirection);
    }
    public void OnAttack(InputValue value)
    {
        if (noEnityLogic)
            return;

        entityLogic.PerformFuntionality<EFuncInteractable,InputValue>(value);
    }
    void OnInteract(InputValue value){
        Debug.Log("tried to interact: " + entityLogic.gameObject.name);
        entityLogic.PerformFuntionality<EFuncInteractable,Vector2>(LastDirection);
    }

    private bool EntitySetup()
    {
        if (currentEntity != null)
        {
            entityLogic = currentEntity.GetComponent<EntityLogic>();
            if (entityLogic != null)
            {
                noEnityLogic = false;
                return true;
            }
        }
        noEnityLogic = true;
        return false;
    }

    public void SetNewEnity(GameObject newEntity)
    {
        GameObject obj = currentEntity;

        currentEntity = newEntity;
        if (!EntitySetup())
        {
            if (obj != null)
            {
                SetNewEnity(obj);
            }
        }
    }

}






