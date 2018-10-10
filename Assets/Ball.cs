using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RigidBodyType
{
    RB2D,
    RB3D
}

public class Ball : MonoBehaviour {

    public RigidBodyType rbType;

    Vector2 mousePosDown;
    Vector2 mousePosUp;
    Rigidbody rb;
    Rigidbody2D rb2d;

    
    public bool haveSpawned = false;

    Vector3 startPos;

    private void Awake()
    {
        startPos = transform.localPosition;
        GetRigidbody();

    }

    void GetRigidbody()
    {
        if(rbType == RigidBodyType.RB2D)
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
        else
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void ResetVelocity()
    {
        if (rbType == RigidBodyType.RB2D)
        {
            rb2d.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void ResetBall()
    {
        haveSpawned = false;
        transform.localPosition = startPos;
        if (rb == null && rb2d == null)
            GetRigidbody();
        ResetVelocity();
    }

    public void Spawn()
    {
        haveSpawned = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Lava"))
        {
            gameObject.SetActive(false);
        }
    }

    void Update () {
    }

    
}
