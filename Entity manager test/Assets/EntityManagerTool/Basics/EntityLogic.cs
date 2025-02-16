using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EntityLogic : MonoBehaviour
{
    //Settings displaying in the inspector
    [Header("Entity Settings")]
    public EntityStats stats;

    //Components
    public Rigidbody2D rb { get; private set; }

    private List<IEnityFunctionality> functionalities = new(10);

    private void Awake()
    {
        EntitySetup();
    }

    //Setup 
    private void EntitySetup()
    {
        rb = GetComponent<Rigidbody2D>();

        functionalities = GetComponents<IEnityFunctionality>().ToList();

        if (stats == null)
        {
            stats = ScriptableObject.CreateInstance<EntityStats>();
            Debug.LogWarning("No EnityStats FOUND, On: " + gameObject.name);
        }
    }

    //overall class that activates a Functionality
    public void PerformFuntionality<TFunc, TValue>(TValue value)
        where TFunc : IEnityFunctionality
    {
        foreach (IEnityFunctionality enityFunctionality in functionalities)
        {
            if(enityFunctionality is TFunc func)
            {
                func.Activate(this, value);
                break;
            }
        }
    }
}
