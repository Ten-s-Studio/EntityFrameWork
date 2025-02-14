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

 

    //Hidden Inspector Variables

    [HideInInspector]
    public List<EnityFunctionality> Functionalities = new(10);

    private void Awake()
    {
        EntitySetup();
    }

    //Setup 
    private void EntitySetup()
    {
        rb = GetComponent<Rigidbody2D>();
        var enityFunctionalities = GetComponents<EnityFunctionality>();
        foreach (var enityFunctionality in enityFunctionalities)
        {
            Functionalities.Add(enityFunctionality);
        }
        if (stats == null)
        {
            stats = ScriptableObject.CreateInstance<EntityStats>();
            Debug.LogWarning("No EnityStats FOUND, On: " + gameObject.name);
        }
    }

    //overall class that activates a Functionality
    public void PerformFuntionality<T>(EnityFunctionality func, T value)
    {
        foreach (EnityFunctionality enityFunctionality in Functionalities)
        {
            if (enityFunctionality.GetType() == func.GetType())
            {
                enityFunctionality.Activate(this, value);
            }
        }
   
    }
}
