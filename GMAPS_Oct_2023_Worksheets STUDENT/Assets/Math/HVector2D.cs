using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[Serializable]
public class HVector2D
{
    public float x, y;
    public float h;

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    public HVector2D(Vector2 _vec)
    {
        x = _vec.x;
        y = _vec.y;
        h = 1.0f;
    }

    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1.0f;
    }

     public static HVector2D operator +(HVector2D a, HVector2D b)
     {
        return new HVector2D(a.x + b.x, a.y + b.y);
     }

     public static HVector2D operator -(HVector2D a, HVector2D b)
     {
        return new HVector2D(a.x - b.x, a.y - b.y);
     }

     public static HVector2D operator *(HVector2D a, float scalar)
     {
        return new HVector2D(a.x * scalar, a.y * scalar );
     }

     public static HVector2D operator /(HVector2D a, float scalar)
     {
        return new HVector2D(a.x / scalar, a.y / scalar );
     }

    public float Magnitude()
     {
         return (float)Math.Sqrt((x * x) + (y * y));
     }

     public void Normalize()
     {
        float mag = Magnitude();
        x /= mag;
        y /= mag;

     }

     public float DotProduct(HVector2D _vec)
     {
        return (x * _vec.x) + (y * _vec.y);
     }

     public HVector2D Projection(HVector2D targetVector)
     {
        // Formula for projection is (a dot b) / ||b||^2 * b, where a is projected onto b

        // Calculating a dot b
        float dotProduct = this.DotProduct(targetVector);

        // Calculating (a dot b) / ||b||^2 and assigning it to scalar var x
        float x = dotProduct / (targetVector.Magnitude() * targetVector.Magnitude());
        
        // Multiplying x to targetVector to calculate projection
        return targetVector * x;
     }

    // public float FindAngle(/*???*/)
    // {

    // }

    public Vector2 ToUnityVector2()
    {
        return Vector2.zero; // change this
    }

    public Vector3 ToUnityVector3()
    {
        return new Vector3(x, y, 0);
    }

    // public void Print()
    // {

    // }
}
