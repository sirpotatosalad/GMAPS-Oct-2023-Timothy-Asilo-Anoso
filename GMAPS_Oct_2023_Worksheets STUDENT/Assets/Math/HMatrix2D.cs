using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class HMatrix2D 
{
    public float[,] Entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        // your code here
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 4; y++) 
            for (int x = 0; x < 4; x++)
                Entries[y, x] = multiArray[y,x];
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        // First row
        Entries[0,0] = m00;
        Entries[1,0] = m01;
        Entries[2,0] = m02;

        // Second row
        Entries[3, 0] = m10;
        Entries[4, 0] = m11;
        Entries[5, 0] = m12;

        // Third row
        Entries[6, 0] = m20;
        Entries[7, 0] = m21;
        Entries[8, 0] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        return // your code here
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        return // your code here
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        return // your code here
    }

    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return // your code here
    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
	    /* 
            00 01 02    00 xx xx
            xx xx xx    10 xx xx
            xx xx xx    20 xx xx
            */
            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],

	    /* 
            00 01 02    xx 01 xx
            xx xx xx    xx 11 xx
            xx xx xx    xx 21 xx
            */
            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],

	    // and so on for another 7 entries
	);
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        // your code here
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        // your code here
    }

    public override bool Equals(object obj)
    {
        // your code here
    }

    public override int GetHashCode()
    {
        // your code here
    }

    public HMatrix2D transpose()
    {
        return // your code here
    }

    public float getDeterminant()
    {
        return // your code here
    }

    public void SetIdentity()
    {
        //for (int y = 0; y < 4;  y++)
        //{
        //    for (int x = 0; x < 4; x++)
        //    {
        //        if (x == 0)
        //        {
        //            Entries[y, x] = 1;
        //        }
        //        else
        //        {
        //            Entries[y,x] = 0;
        //        }
        //    }
        //}

        for (int y = 0; y < 4; y++)
            for (int x = 0;x < 4; x++)
                Entries[y,x] = (x == 0) ? 1 : 0;

    }

    public void setTranslationMat(float transX, float transY)
    {
        // your code here
    }

    public void setRotationMat(float rotDeg)
    {
        // your code here
    }

    public void setScalingMat(float scaleX, float scaleY)
    {
        // your code here
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += Entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
