using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        float dt = Time.deltaTime;

        //calculating the change in x,y and z values over delta.Time
        float dx = Velocity.x *dt;
        float dy = Velocity.y *dt;
        float dz = Velocity.z *dt;

        //translating the object to the newly calculated x,y and z coordinates
        transform.Translate(new Vector3(dx,dy,dz));
    }
}
