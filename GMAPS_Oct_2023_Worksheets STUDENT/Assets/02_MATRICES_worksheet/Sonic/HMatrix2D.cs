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
        //loop through each column
        for (int y = 0; y < 3; y++)
            //loop through each row element in each column
            for (int x = 0; x < 3; x++)
                //setting each element's coordinates
                Entries[y, x] = multiArray[y, x];
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        // First row
        Entries[0, 0] = m00;
        Entries[0, 1] = m01;
        Entries[0, 2] = m02;

        // Second row
        Entries[1, 0] = m10;
        Entries[1, 1] = m11;
        Entries[1, 2] = m12;

        // Third row
        Entries[2, 0] = m20;
        Entries[2, 1] = m21;
        Entries[2, 2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        //create new result matrix
        HMatrix2D result = new HMatrix2D();

        //iterate through each column element
        for (int y = 0; y < 3; y++)
            // iterate through each row element
            for (int x = 0; x < 3; x++)
                //set each element inside the result matrix by additing corresponding left and right matrix elements.
                result.Entries[y, x] = left.Entries[y, x] + right.Entries[y, x];

        return result;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        //create a new result matrix
        HMatrix2D result = new HMatrix2D();

        //iterate through each column element
        for (int y = 0; y < 3; y++)
            //iterate through each row element
            for (int x = 0; x < 3; x++)
                //set each each element inside the result matrix by subtracting corresponding elements from left and right matrices given
                result.Entries[y, x] = left.Entries[y, x] - right.Entries[y, x];

        return result;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D result = new HMatrix2D();

        //iterate through each row and column
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                //multiply each element in the left matrix by scalar and set each result matrix element respectively
                result.Entries[y, x] = left.Entries[y, x] * scalar;

        return result; // your code here
    }

    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
        (
            left.Entries[0, 0] * right.x + left.Entries[0, 1] * right.y + left.Entries[0, 2] * right.h,
            left.Entries[1, 0] * right.x + left.Entries[1, 1] * right.y + left.Entries[1, 2] * right.h
        );

    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            //top row multiplication
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
            left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2],


            // middle row multiplication
            left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],
            left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],
            left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2],


            //bottom row multiiplication
            left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],
            left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],
            left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2]


 );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        //iterate through each column and row element
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                // check if corresponding elements in both left and right matrices are the same (i.e., x1 = x2 etc.)
                if (left.Entries[x, y] != right.Entries[y, x])
                    //return false if corresponding elements do not match
                    return false;

        return true;
    }

    // the logic for != operator is the same as the == operator, only with the check between each element being flipped
    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                if (left.Entries[x, y] == right.Entries[y, x])
                    return false;

        return true;
    }

    //   public override bool Equals(object obj)
    //   {
    //       // your code here
    //   }

    //   public override int GetHashCode()
    //   {
    //       // your code here
    //   }

    //   public HMatrix2D transpose()
    //   {
    //       return // your code here
    //   }

    //   public float getDeterminant()
    //   {
    //       return // your code here
    //   }

    public void SetIdentity()
    {
        //for (int y = 0; y < 3;  y++)
        //{
        //    for (int x = 0; x < 3; x++)
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

        // interate through each column and row
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                // for entries with matching row and column indices (e.g., 1,1) set their values to 1 (i.e., setting the main diagonal for identity matrix)
                Entries[y, x] = (x == y) ? 1 : 0;

    }

    public void setTranslationMat(float transX, float transY)
    {
        SetIdentity();

        Entries[0, 2] = transX;
        Entries[1, 2] = transY;
    }

    public void setRotationMat(float rotDeg)
    {

        // make the matrix an identity matrix
        SetIdentity();
        // convert the given degree value to radian
        float rad = rotDeg * Mathf.Deg2Rad;

        //set corresponding elements, following the rotation matrix formula
        Entries[0, 0] = Mathf.Cos(rad);
        Entries[0, 1] = -Mathf.Sin(rad);
        Entries[1, 0] = Mathf.Sin(rad);
        Entries[1, 1] = Mathf.Cos(rad);
    }

    public void setScalingMat(float scaleX, float scaleY)
    {
        SetIdentity();
        Entries[0, 0] = scaleX;
        Entries[0, 1] = scaleY;
    }

    public void Print()
    {
        string result = "";
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result += Entries[y, x] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
