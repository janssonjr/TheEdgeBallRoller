using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    public Rigidbody ball;
    public Rigidbody2D ball2d;
    public RigidBodyType ballType;
    public GameManager gm;


    // Update is called once per frame
    void Update () {
        //Debug.Log(ball.velocity.z);
	}

    public void AddForceToBall()
    {

        float velocityZ = -5.5f;
        if(ballType == RigidBodyType.RB3D)
        {
            if (ball.velocity.z < velocityZ)
            {
                ball.velocity = Vector3.zero;
            }
            else if (ball.velocity.z >= velocityZ)
            {
                ball.velocity = new Vector3(0f, 0f, gm.ballForce);
            }
        }
        else
        {
            if (ball2d.velocity.y < velocityZ)
            {
                ball2d.velocity = Vector2.zero;
            }
            else if (ball2d.velocity.y >= velocityZ)
            {
                ball2d.velocity = new Vector2(0f, gm.ballForce);
            }
        }

        //ball.AddForce(new Vector3(0f, 0f,  + (-1 * ball.velocity.y)));
    }
}
