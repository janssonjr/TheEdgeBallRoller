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

	public CircleCollider2D scoreCollider;

    Rigidbody rb;
	Rigidbody2D rb2d;
	float previousVelocity;

	CircleCollider2D myCollider;
    
    public bool haveSpawned = false;

    Vector3 startPos;

    private void Awake()
    {
        startPos = transform.localPosition;
		previousVelocity = -1;
        GetRigidbody();

    }

    void GetRigidbody()
    {
        if(rbType == RigidBodyType.RB2D)
        {
            rb2d = GetComponent<Rigidbody2D>();
			myCollider = GetComponent<CircleCollider2D>();
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

	private void OnCollisionExit2D(Collision2D collision)
	{

	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Lane")
		{
			gameObject.SetActive(false);
		}
	}

	void Update () {

		if(rb2d.velocity.y < 0f)
		{
			if(previousVelocity >= 0f)
			{
				previousVelocity = rb2d.velocity.y;
				GetLengthToScoreMiddle();
				//Debug.Log("Score!!");
			}
		}
		else
		{
			previousVelocity = rb2d.velocity.y;
		}

    }

	void GetLengthToScoreMiddle()
	{

		

		bool isCollidng = myCollider.IsTouching(scoreCollider);
		if (isCollidng == false)
			return;
		Debug.Log(isCollidng);

		Vector2 scoreCenter = scoreCollider.GetComponent<RectTransform>().anchoredPosition;
		Vector2 mineCenter = GetComponent<RectTransform>().anchoredPosition;
		Debug.DrawLine(scoreCenter, mineCenter);
		float length = (scoreCenter - mineCenter).magnitude;
		float combineRadius = Mathf.Abs(myCollider.radius + scoreCollider.radius);
		//Debug.Log("Length: " + length + " Radius: " + combineRadius);
		/*if (length > combineRadius)
		{
			return;
		}*/
		Debug.Log("Length: " + length + " combineRadius: " + combineRadius);
		int scoreAmount = (int)((1 - (length / (scoreCollider.radius * 2))) * 100);

		Debug.Log(scoreAmount);
	}

    
}
