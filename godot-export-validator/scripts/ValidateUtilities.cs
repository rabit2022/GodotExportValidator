using System;
using System.Collections;
using Godot;
using GodotObject = Godot.GodotObject;

namespace GodotExportValidator;

public static class ValidateUtilities
{
    private static string GetThisObjectString<T>(T thisObject)
    {
        switch (thisObject)
        {
            case Resource resource:
                return ColorSettings.ResourceToString(resource);
            case Node node:
                return ColorSettings.NodeToString(node);
            case null:
                return null;
            default:
                return thisObject.ToString();
        }
    }

    private static string GetFieldName(string fieldName)
    {
        return ColorSettings.Validate + ColorSettings.WrapFieldName(fieldName);
    }

    #region Checks

    
    public static bool ValidateCheckEmptyString<T>(T thisObject, string fieldName, string stringToCheck)
    {
        return Checks.ValidateCheckEmptyString(GetThisObjectString(thisObject), GetFieldName(fieldName), stringToCheck);
    }
    
    public static bool ValidateCheckNullValue<T,R>(T thisObject, string fieldName, R objectToCheck)
    {
        return Checks.ValidateCheckNullValue(GetThisObjectString(thisObject), GetFieldName(fieldName), GetThisObjectString(objectToCheck));
    }
    
    
    public static bool ValidateCheckEnumerableValues<T>(T thisObject, string fieldName,
        IEnumerable enumerableObjectToCheck)
    {
        return Checks.ValidateCheckEnumerableValues(GetThisObjectString(thisObject), GetFieldName(fieldName), enumerableObjectToCheck);
    }

    
    public static bool ValidateCheckPositiveValue<T>(T thisObject, string fieldName, int valueToCheck,
        bool isZeroAllowed)
    {
        return Checks.ValidateCheckPositiveValue(GetThisObjectString(thisObject), GetFieldName(fieldName), valueToCheck,
            isZeroAllowed);
    }


    public static bool ValidateCheckPositiveValue<T>(T thisObject, string fieldName, float valueToCheck,
        bool isZeroAllowed)
    {
        return Checks.ValidateCheckPositiveValue(GetThisObjectString(thisObject), GetFieldName(fieldName), valueToCheck,
            isZeroAllowed);
    }

    public static bool ValidateCheckPositiveRange<T>(T thisObject, string fieldNameMinimum, float valueToCheckMinimum,
        string fieldNameMaximum, float valueToCheckMaximum, bool isZeroAllowed)
    {
        return Checks.ValidateCheckPositiveRange(GetThisObjectString(thisObject), GetFieldName(fieldNameMinimum), valueToCheckMinimum,
            GetFieldName(fieldNameMaximum), valueToCheckMaximum, isZeroAllowed);
    }
    
    public static bool ValidateCheckPositiveRange<T>(T thisObject, string fieldNameMinimum,
        int valueToCheckMinimum, string fieldNameMaximum, int valueToCheckMaximum, bool isZeroAllowed)
    {
        return Checks.ValidateCheckPositiveRange(GetThisObjectString(thisObject), GetFieldName(fieldNameMinimum), valueToCheckMinimum,
            GetFieldName(fieldNameMaximum), valueToCheckMaximum, isZeroAllowed);
    }
    
    #endregion Checks
}