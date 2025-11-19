using System;
using System.Collections;
using Godot;

namespace GodotExportValidatorGenerator;

public static class ValidateUtilities
{
    private static Action<string> Print = GD.PrintErr;

    private static string NodeToString(this Node node)
    {
        // <type    path>
        return $"<{node.GetType().Name}    {node.GetPath()}>";
    }

    #region Checks

    /// <summary>
    /// Empty string debug check
    /// </summary>
    public static bool ValidateCheckEmptyString(Node thisObject, string fieldName, string stringToCheck)
    {
        if (stringToCheck == "" || string.IsNullOrWhiteSpace(stringToCheck))
        {
            Print("[Validate]    " + fieldName + " is empty and must contain a value in object " +
                  NodeToString(thisObject));
            return true;
        }

        return false;
    }

    /// <summary>
    /// null value debug check
    /// </summary>
    public static bool ValidateCheckNullValue(Node thisObject, string fieldName, Node objectToCheck)
    {
        if (objectToCheck == null)
        {
            Print("[Validate]    " + fieldName + " is null and must contain a value in object " +
                  NodeToString(thisObject));
            return true;
        }

        return false;
    }


    /// <summary>
    /// list empty or contains null value check - returns true if there is an error
    /// </summary>
    public static bool ValidateCheckEnumerableValues(Node thisObject, string fieldName,
        IEnumerable enumerableObjectToCheck)
    {
        bool error = false;
        int count = 0;

        if (enumerableObjectToCheck == null)
        {
            Print("[Validate]    " + fieldName + " is null in object " + NodeToString(thisObject));
            return true;
        }


        foreach (var item in enumerableObjectToCheck)
        {
            if (item == null)
            {
                Print("[Validate]    " + fieldName + " has null values in object " + NodeToString(thisObject));
                error = true;
            }
            else
            {
                count++;
            }
        }

        if (count == 0)
        {
            Print("[Validate]    " + fieldName + " has no values in object " + NodeToString(thisObject));
            error = true;
        }

        return error;
    }


    /// <summary>
    /// positive value debug check- if zero is allowed set isZeroAllowed to true. Returns true if there is an error
    /// </summary>
    public static bool ValidateCheckPositiveValue(Node thisObject, string fieldName, int valueToCheck,
        bool isZeroAllowed)
    {
        bool error = false;

        if (isZeroAllowed)
        {
            if (valueToCheck < 0)
            {
                Print("[Validate]    " + fieldName + " must contain a positive value or zero in object " +
                      NodeToString(thisObject));
                error = true;
            }
        }
        else
        {
            if (valueToCheck <= 0)
            {
                Print("[Validate]    " + fieldName + " must contain a positive value in object " +
                      NodeToString(thisObject));
                error = true;
            }
        }

        return error;
    }

    /// <summary>
    /// positive value debug check - if zero is allowed set isZeroAllowed to true. Returns true if there is an error
    /// </summary>
    public static bool ValidateCheckPositiveValue(Node thisObject, string fieldName, float valueToCheck,
        bool isZeroAllowed)
    {
        bool error = false;

        if (isZeroAllowed)
        {
            if (valueToCheck < 0)
            {
                Print("[Validate]    " + fieldName + " must contain a positive value or zero in object " +
                      NodeToString(thisObject));
                error = true;
            }
        }
        else
        {
            if (valueToCheck <= 0)
            {
                Print("[Validate]    " + fieldName + " must contain a positive value in object " +
                      NodeToString(thisObject));
                error = true;
            }
        }

        return error;
    }

    /// <summary>
    /// positive range debug check - set isZeroAllowed to true if the min and max range values can both be zero. Returns true if there is an error
    /// </summary>
    public static bool ValidateCheckPositiveRange(Node thisObject, string fieldNameMinimum, float valueToCheckMinimum,
        string fieldNameMaximum, float valueToCheckMaximum, bool isZeroAllowed)
    {
        bool error = false;
        if (valueToCheckMinimum > valueToCheckMaximum)
        {
            Print("[Validate]    " + fieldNameMinimum + " must be less than or equal to " + fieldNameMaximum +
                  " in object " +
                  NodeToString(thisObject));
            error = true;
        }

        if (ValidateCheckPositiveValue(thisObject, fieldNameMinimum, valueToCheckMinimum, isZeroAllowed)) error = true;

        if (ValidateCheckPositiveValue(thisObject, fieldNameMaximum, valueToCheckMaximum, isZeroAllowed)) error = true;

        return error;
    }

    /// <summary>
    /// positive range debug check - set isZeroAllowed to true if the min and max range values can both be zero. Returns true if there is an error
    /// </summary>
    public static bool ValidateCheckPositiveRange(Node thisObject, string fieldNameMinimum, int valueToCheckMinimum,
        string fieldNameMaximum, int valueToCheckMaximum, bool isZeroAllowed)
    {
        bool error = false;
        if (valueToCheckMinimum > valueToCheckMaximum)
        {
            Print("[Validate]    " + fieldNameMinimum + " must be less than or equal to " + fieldNameMaximum +
                  " in object " +
                  NodeToString(thisObject));
            error = true;
        }

        if (ValidateCheckPositiveValue(thisObject, fieldNameMinimum, valueToCheckMinimum, isZeroAllowed)) error = true;

        if (ValidateCheckPositiveValue(thisObject, fieldNameMaximum, valueToCheckMaximum, isZeroAllowed)) error = true;

        return error;
    }

    #endregion Checks
}