using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RndColourBehaviourScript : MonoBehaviour {
	float green = 0.5f;
	int direction = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text>().color = new Color( 0.8f, green, 0.05f, 1.0f );
		if(green > 0.8f)
		{
			direction = -1;
		}
		else if(green < 0.5f)
		{
			direction = 1;
		}

		green = green + 0.01f*direction;
	}
}
