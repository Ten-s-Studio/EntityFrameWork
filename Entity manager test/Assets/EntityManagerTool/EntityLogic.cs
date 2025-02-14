using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EntityLogic : MonoBehaviour
{
    [Header("Entity Settings")]
    public EntityStats stats;

    public Rigidbody2D rb { get; private set; }

 


    [HideInInspector]
    public List<EnityFunctionality> Functionalities = new(10);



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        var enityFunctionalities = GetComponents<EnityFunctionality>();
        foreach (var enityFunctionality in enityFunctionalities)
        {
            Functionalities.Add(enityFunctionality);      
        }
        if(stats == null) 
        { 
           stats= new EntityStats();
            Debug.LogWarning("No EnityStats FOUND, On: " + gameObject.name);
        }
    }

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
