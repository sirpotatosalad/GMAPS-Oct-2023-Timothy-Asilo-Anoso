using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;

        return (float) Mathf.Sqrt(dx * dx + dy * dy);
    }
}

