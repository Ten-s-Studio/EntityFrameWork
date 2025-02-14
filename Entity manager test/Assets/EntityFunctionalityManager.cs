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

    public List<enityFunctionalitystruct> AllFunctionalities;

    public EnityFunctionality GetFunctionality(string name)
    {
        foreach(enityFunctionalitystruct enityFunctionalitystructin in AllFunctionalities)
        {
           if(enityFunctionalitystructin.Name == name)
           {
                return enityFunctionalitystructin.Functionality;
           }
        }
        return default;
     
    }

}

[Serializable]
public struct enityFunctionalitystruct
{
    public string Name;
    public EnityFunctionality Functionality;
    
}
