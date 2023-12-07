using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);

    [HideInInspector]
    public float Radius;

    private void Start()
    {
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        //get the radius of the ball by halving the size of the local sprite (i.e., diameter / 2 )
        Radius = local_sprite_size.x / 2f;
    }

    public bool IsCollidingWith(float x, float y)
    {
        //check if the distance between two points is smaller than the assigned radius of the ball
        //this is done by calculating the magnitude of the resultant vector after subtracting the given points coordinates from  the ball's centre point
        float distance = Mathf.Sqrt((x - transform.position.x) * (x - transform.position.x) + (y - transform.position.y) * (y - transform.position.y));
        return distance <= Radius;
    }

    public bool IsCollidingWith(Ball2D other)
    {
        // Calculate the distance between the centers of the two balls
        float distance = Util.FindDistance(Position, other.Position);
        // Check if the distance between the centers is less than or equal to the sum of their radii
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        // finding the displacement of x and y, which is x and y's change in velocity over time
        float displacementX = Velocity.x * deltaTime;
        float displacementY = Velocity.y * deltaTime;

        //setting the new position after calculating displacement
        Position.x += displacementX;
        Position.y += displacementY;

        //applying the new position to the ball's transform position
        transform.position = new Vector2(Position.x, Position.y);
    }
}

