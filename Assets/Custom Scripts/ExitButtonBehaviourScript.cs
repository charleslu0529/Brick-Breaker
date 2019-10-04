using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonBehaviourScript : MonoBehaviour {

	public Button ExitButton;

	// Use this for initialization
	void Start () {
		Button btn = ExitButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TaskOnClick(){
		Application.Quit();
	}
}
