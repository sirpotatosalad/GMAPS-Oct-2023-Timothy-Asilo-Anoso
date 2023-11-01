using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;

    private void Start()
    {
       OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(t => t != this).ToArray();
    }

    float Magnitude(Vector3 vector)
    {
        return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
    }

    Vector3 Normalise(Vector3 vector)
    {
        float mag = Magnitude(vector);
        return vector / mag;
    }

    float Dot(Vector3 vectorA, Vector3 vectorB)
    {
        return vectorA.x * vectorB.x + vectorA.y * vectorB.y + vectorA.z * vectorB.z;
    }

    SoccerPlayer FindClosestPlayerDot()
    {
        SoccerPlayer closest = null;
        float minAngle = 180f;

        for (int i = 0; i < OtherPlayers.Length; i++)
        {
            Vector3 toPlayer = OtherPlayers[i].transform.position - transform.position;
            toPlayer = Normalise(toPlayer);

            float dot = Dot(transform.forward, toPlayer);
            float angle = Mathf.Acos(dot);
            angle *= Mathf.Rad2Deg;

            if (angle < minAngle)
            {
                minAngle = angle;
                closest = OtherPlayers[i];
            }
        }


        return closest;
    }

    void DrawVectors()
    {
        //loop through each player
        foreach (SoccerPlayer player in OtherPlayers)
        {
            // draw a vector for the other players that are not the current player
            foreach (SoccerPlayer otherPlayer in OtherPlayers)
            {
                if (player != otherPlayer)
                {
                    //taking the directional vector between each otherPlayer and the player
                    Vector3 vecDir = otherPlayer.transform.position - player.transform.position;

                    //draw a black ray from each player to otherPlayer
                    Debug.DrawRay(player.transform.position, vecDir, Color.black);
                }
            }
        }
    }

    void Update()
    {
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.blue);

        if (IsCaptain)
        {
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

            DrawVectors();

            SoccerPlayer targetPlayer = FindClosestPlayerDot();
            targetPlayer.GetComponent<Renderer>().material.color = Color.green;

            foreach (SoccerPlayer other in OtherPlayers.Where(t => t != targetPlayer))
            {
                other.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}


