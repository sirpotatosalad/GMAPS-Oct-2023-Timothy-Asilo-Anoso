// Uncomment this whole file.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        Translate(1, 1);
        Rotate(45);
    }


    void Translate(float x, float y)
    {
        //creating a translation matrix to translate the mesh vertices 
        transformMatrix.SetIdentity();
        transformMatrix.setTranslationMat(x,y);
        Transform();

        pos = transformMatrix * pos;
    }

    void Rotate(float angle)
    {
        // homogeneous transformation matrices for translation to and from the origin, and rotation.
        HMatrix2D toOriginMatrix = new HMatrix2D();
        HMatrix2D fromOriginMatrix = new HMatrix2D();
        HMatrix2D rotateMatrix = new HMatrix2D();

        // set translation matrices to move to and from the origin based on the object's position
        toOriginMatrix.setTranslationMat(-pos.x, -pos.y);
        fromOriginMatrix.setTranslationMat(pos.x, pos.y);

        // set the rotation matrix based on the given angle
        rotateMatrix.setRotationMat(angle);

        //initialise the final transform matrix
        transformMatrix.SetIdentity();

        //combine all translation and rotation matrices from right to left
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;

        //apply the transformation
        Transform();
    }

    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            //convert each vertex to a 2D homogeneous vector
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            //apply the transformation matrix to each vertex
            vert = transformMatrix * vert;
            //update the old vertex coordinates with the newly calculated vertex coordinates
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;
        }

        //update the vertice elements for cloned mesh
        meshManager.clonedMesh.vertices = vertices;
    }
}
