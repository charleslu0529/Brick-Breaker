using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitToMenuBehaviourScript : MonoBehaviour {

	public Button ExitButton;

	// Use this for initialization
	void Start () {
		Button btn = ExitButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("escape"))
		{
			SceneManager.LoadScene("MainMenuScene");
		}
	}

	void TaskOnClick(){
		SceneManager.LoadScene("MainMenuScene");
	}
}
