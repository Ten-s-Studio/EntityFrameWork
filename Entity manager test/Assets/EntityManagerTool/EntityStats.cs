using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "ScriptableObjects/EntityStats")]
public class EntityStats : ScriptableObject
{
    [Header("General")]
    public float health = 1;
    public float maxHealth = 1;

    [Header("Movement")]
    public float movementSpeed = 1;


    [Header("Resistances")]

    [Tooltip("Resistance to heat, all heatsource will have X precent of reduced effect")]
    [Range(0f,100f)]
    public int heatResistance = 0;
   

    [Tooltip("Resistance to cold, all heatsource will have X precent of reduced effect")]
    [Range(0f, 100f)]
    public int coldResistance = 0;

}

