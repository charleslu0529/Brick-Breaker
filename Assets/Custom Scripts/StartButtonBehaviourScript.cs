using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonBehaviourScript : MonoBehaviour {

	public Button StartButton;

	// Use this for initialization
	void Start () {
		Button btn = StartButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TaskOnClick(){
		SceneManager.LoadScene("PlayScene");
	}
}
