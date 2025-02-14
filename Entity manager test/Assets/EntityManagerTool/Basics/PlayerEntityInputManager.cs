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

        PlayerEntitySetup();
    }
    #endregion

    [Header("Enity The Player Is Controlling")]
    public GameObject currentEntity;


    //List of Functionalities the player can choose from 
    private FuncVector2Movement movement;
    private FuncAttack attack;



    //private Viarables

    private EntityLogic entityLogic;
    private bool noEnityLogic = true;


    private void Start()
    {
        //not in the awake due to the EntityFunctionalityManager first needing to compleet his setup in the awake
        FindAllFunctionalities();
    }

    private bool PlayerEntitySetup()
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

    private void FindAllFunctionalities()
    {
        movement = (FuncVector2Movement)EntityFunctionalityManager.instance.GetFunctionality("vector2movement");
        attack = (FuncAttack)EntityFunctionalityManager.instance.GetFunctionality("attack");

    }


    #region Functions based on Player Input system
    private void OnMove(InputValue value)
    {
        if (noEnityLogic)
            return;
        
        entityLogic.PerformFuntionality(movement, value.Get<Vector2>());
    }
    public void OnAttack(InputValue value)
    {
        if (noEnityLogic)
            return;

        entityLogic.PerformFuntionality(attack, value);
    }

    #endregion

    #region Support Functions
    public void SetNewEnity(GameObject newEntity)
    {
        GameObject obj = currentEntity;

        currentEntity = newEntity;
        if (!PlayerEntitySetup())
        {
            if (obj != null)
            {
                SetNewEnity(obj);
            }
        }
    }
    #endregion
}






