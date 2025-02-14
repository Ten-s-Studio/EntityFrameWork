using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EntityFunctionalityManager : MonoBehaviour
{

    #region Static check
    public static EntityFunctionalityManager instance { get; private set; }

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
    //list of all the functionality options ANY entity can Choose from
    public List<EnityFunctionalitystruct> AllFunctionalities;


    public EnityFunctionality GetFunctionality(string name)
    {
        foreach(EnityFunctionalitystruct enityFunctionalitystructin in AllFunctionalities)
        {
           if(enityFunctionalitystructin.Name == name)
           {
                return enityFunctionalitystructin.Functionality;
           }
        }
        Debug.LogWarning("Functionality " + name + "Not Found In " + gameObject.name);
        return default;
     
    }

}

[Serializable]
public struct EnityFunctionalitystruct
{
    

    [Header("Functionality Name Without Capital Letters ")]
    [Tooltip("Searching Name for the Functionality")]
    public string Name;
    [Header("Script Instance of the Functionality")]
    public EnityFunctionality Functionality;
    
}
