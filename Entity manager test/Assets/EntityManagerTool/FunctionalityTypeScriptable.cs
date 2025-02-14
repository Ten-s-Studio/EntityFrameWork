using System;
using UnityEngine;


[CreateAssetMenu(fileName = "FunctionalityType", menuName = "ScriptableObjects/FunctionalityType")]
public class FunctionalityTypeScriptable : ScriptableObject
{
    public Guid guid = Guid.NewGuid();
}
