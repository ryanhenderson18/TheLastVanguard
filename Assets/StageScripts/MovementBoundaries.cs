using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBoundaries
{
    public static bool leftTrespass(Vector3 position)
    {
        if (position.x <= -12)
            return true;
        return false;
    }

    public static bool rightTrespass(Vector3 position)
    {
        if (position.x >= 12)
            return true;
        return false;
    }

    public static bool forwardTrespass(Vector3 position)
    {
        if (position.z >= 7)
            return true;
        return false;
    }

    public static bool downwardTrespass(Vector3 position)
    {
        if (position.z <= -10)
            return true;
        return false;
    }
}
