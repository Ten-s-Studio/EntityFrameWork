using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class EntityFunctionalityManager
{
    private static Dictionary<string, Type> functionalityTypes = new Dictionary<string, Type>();

    static EntityFunctionalityManager()
    {
        LoadFunctionalities();
    }

    private static void LoadFunctionalities()
    {
        // Find all classes that inherit from EnityFunctionality
        var functionalityClasses = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(EnityFunctionality)))
            .ToList();

        Debug.Log($"Found {functionalityClasses.Count} functionalities");

        foreach (var type in functionalityClasses)
        {
            Debug.Log($"Registered functionality: {type.Name}");
            functionalityTypes[type.Name] = type;
        }
    }

    public static Type GetFunctionality(string name)
    {
        if (functionalityTypes.TryGetValue(name, out var type))
        {
            return type;
        }

        Debug.LogWarning($"Functionality '{name}' not found.");
        return null;
    }

    public static EnityFunctionality CreateFunctionalityInstance(string name, GameObject target)
    {
        Type type = GetFunctionality(name);
        if (type == null) return null;

        return target.AddComponent(type) as EnityFunctionality;
    }

    public static IEnumerable<string> GetAllFunctionalityNames()
    {
        return functionalityTypes.Keys;
    }
}
