using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour {

	public Transform TransformPlayer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("a"))
		{
			if(TransformPlayer.position.x < -8.25f)
			{

			}
			else if(Input.GetKey("d"))
			{

			}
			else
			{
				TransformPlayer.Translate(Vector3.left * Time.deltaTime * 15);
			}
			
		}
		if(Input.GetKey("d"))
		{
			if(TransformPlayer.position.x > 8.25f)
			{

			}
			else if(Input.GetKey("a"))
			{
				
			}
			else
			{
				TransformPlayer.Translate(Vector3.right * Time.deltaTime * 15);
			}
			
		}
	}
}
