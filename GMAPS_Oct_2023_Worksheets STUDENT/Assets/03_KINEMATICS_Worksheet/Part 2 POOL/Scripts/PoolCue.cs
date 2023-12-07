using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

    private Line drawnLine;
    private Ball2D ball;

    private void Start()
    {
        ball = ballObject.GetComponent<Ball2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
            {
                //initialises a line that starts from the ball's transform position and ends at the mouse's current position in the screen
                drawnLine = lineFactory.GetLine(ball.transform.position,startLinePos,2f,Color.black);
                drawnLine.EnableDrawing(true);
            }
        }
        else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        {
            drawnLine.EnableDrawing(false);

            
            // create a velocity vector b. the direction is determined by performing vector subtraction between the end point and start point.
            // in this case, the end point is the drawLine.start , and the end point is drawLine.end
            // this is because we want the ball to shoot opposite of the shooting line
            HVector2D v = new HVector2D(drawnLine.start.x - drawnLine.end.x, drawnLine.start.y - drawnLine.end.y);
            //update the velocity of the white ball.
            ball.Velocity = v;
            Debug.Log(ball.Velocity);

            drawnLine = null; // End line drawing            
        }

        if (drawnLine != null)
        {
            drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Update line end
        }
    }

    public void Clear()
    {
        var activeLines = lineFactory.GetActive();

        foreach (var line in activeLines)
        {
            line.gameObject.SetActive(false);
        }
    }
}
