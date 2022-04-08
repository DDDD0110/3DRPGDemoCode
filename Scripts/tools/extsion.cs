using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class extsion
{
    private const float dotvalue = 0.2f;
    //target是否在面前
    public static bool IsFaceToTarget(this Transform transform, Transform target)
    {
        if (target == null)
            return false;
        var distance = target.position - transform.position;
        distance.Normalize();
        return Vector3.Dot(transform.forward, distance) >= dotvalue;
    }
}
