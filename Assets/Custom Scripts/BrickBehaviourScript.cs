using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviourScript : MonoBehaviour {
	public GameObject BrickObject;
	public Transform TransformBrick;
	public ParticleSystem ParticleEffect;
	//public AudioSource HitSound;
	float green = 0.5f;
	int direction = 1;
	bool fade = false;
	float alpha = 1f;
	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<SpriteRenderer>().color = new Color( 0.8f, green, 0.05f, 1.0f );
		if(green > 0.8f)
		{
			direction = -1;
		}
		else if(green < 0.5f)
		{
			direction = 1;
		}

		green = green + 0.02f*direction;

		if(fade)
		{
			if(alpha < 0)
			{
				Destroy(gameObject);
				fade = false;
			}
			GetComponent<SpriteRenderer>().color = new Color( 0.8f, GetComponent<SpriteRenderer>().color.g, 0.05f, alpha );

			alpha = alpha - 0.075f;
		}
	}

	void OnCollisionEnter2D(Collision2D col) 
	{


		if(col.gameObject.tag == "ball")
		{
        	GetComponent<AudioSource>().Play();

        	fade = true;
        	
			ParticleSystem dieEffect = Instantiate(ParticleEffect,TransformBrick.position,Quaternion.identity) as ParticleSystem;
			dieEffect.Play();
		}
	}
}