using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviourScript : MonoBehaviour {
	public Rigidbody2D BallRigidBody;
	public Transform TransformBall;
	public Transform TransformPaddle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(BallRigidBody.velocity.y == 0)
		{
			if(Input.GetKey("space"))
			{
				TransformBall.parent = null;

				int randomX = Random.Range(-4,4);

				while(randomX == 0)
				{
					randomX = Random.Range(-4,4);
				}

				BallRigidBody.velocity = new Vector3(randomX, 10, 0);
			}
		}

	}

	void OnCollisionEnter2D(Collision2D col) 
	{
		if(col.gameObject.tag == "dead zone")
		{
			GameBehaviourScript.instance.deadPlayer();
			Destroy(gameObject);
		}
	}
}
