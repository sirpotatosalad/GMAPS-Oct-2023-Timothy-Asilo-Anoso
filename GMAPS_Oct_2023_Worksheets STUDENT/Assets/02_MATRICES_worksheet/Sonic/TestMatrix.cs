// Uncomment this whole file.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();


    void Start()
    {
        mat.SetIdentity();
        mat.Print();
        Question2();
    }

    void Question2()
    {
        HMatrix2D mat1 = new HMatrix2D(1,2,3,4,5,6,7,8,9);
        HMatrix2D mat2 = new HMatrix2D(5,6,7,8,9,10,11,12,13);
        HMatrix2D resultMat = new HMatrix2D();
        HVector2D vec1 = new HVector2D(3,7);

        resultMat = mat1 * mat2;
        resultMat.Print();
    }

}
