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

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EntitySetup();
    }

    private void OnMove(InputValue value)
    {
        if (noEnityLogic)
            return;
        
        entityLogic.PerformFuntionality<Vector2>(EntityFunctionalityManager.GetFunctionality("FuncVector2Movement"), value.Get<Vector2>());
    }
    public void OnAttack(InputValue value)
    {
        if (noEnityLogic)
            return;

        entityLogic.PerformFuntionality(EntityFunctionalityManager.GetFunctionality("FuncAttack"), value);
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






