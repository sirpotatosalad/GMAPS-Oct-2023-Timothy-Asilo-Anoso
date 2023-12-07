using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        //find difference between x and y coordinates between p1 and p2
        //also are the x and y coordinates of the vector from p1 to p2
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;

        //use pythagorean theorem to find the distance
        return (float) Mathf.Sqrt(dx * dx + dy * dy);
    }
}

