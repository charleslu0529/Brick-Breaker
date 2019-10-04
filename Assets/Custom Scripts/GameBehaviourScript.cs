using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehaviourScript : MonoBehaviour {

	public GameObject BrickObject;
	public GameObject PlayerPaddle;
	public GameObject BallObject;
	public GameObject CameraObject;
	public GameObject WallObject;
	public Transform TransformEmptyObject; 
	public Transform TransformBrick;
	public Transform TranformPaddle;
	public Text TopText;
	public Text MiddleText;
	public Vector3 StartingPos;
	public int TotalLines;
	public static GameBehaviourScript instance = null;
	int life = 5;
	bool isAlive = true;
	float sloMoTime = 3f;
	bool cleared = false;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}else if(instance != this)
		{
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		createBricks();
	}
	
	// Update is called once per frame
	void Update () {
		if(!isAlive)
		{
			if(life > 0)
			{
				Instantiate(PlayerPaddle, new Vector3(TranformPaddle.position.x,TranformPaddle.position.y, 0),Quaternion.identity);
				isAlive = true;
			}
		}

		if(GameObject.FindGameObjectsWithTag("brick").Length == 0)
		{
			
			sloMoTime -= Time.deltaTime;
			if(sloMoTime >= 0)
			{
				Time.timeScale = 0.5f;
			}else if(sloMoTime < 0){
				Time.timeScale = 1f;
				createBricks();
				Instantiate(BrickObject, new Vector3(StartingPos.x,StartingPos.y,0), Quaternion.identity);
				sloMoTime = 3f;
				life = 5;
				cleared = true;
			}
			
			
		}

		if(cleared)
		{
			TopText.text = "Congradulations!! You can carry on playing or press \"esc\" to exit";
		}

		if(life == 0 && !isAlive)
		{
			MiddleText.text = "You Lose \n Game Over. \n Press \"esc\" to exit.";
			Time.timeScale = 0;
		}

		if(Input.GetKey("escape"))
		{
			SceneManager.LoadScene("MainMenuScene");
		}
	}

	void createBricks()
	{

		Vector3 position = new Vector3(StartingPos.x + 1.2f,StartingPos.y,0);

		for(int j=0;j<(6 / TransformEmptyObject.localScale.x);j++)
			{
				Instantiate(BrickObject, position, Quaternion.identity);

				if(position.x < 7f)
				{
					position = new Vector3(position.x + 1.2f,position.y,0);
				}
			}
			
			position = new Vector3(StartingPos.x - 1.2f,position.y,0);

		for(int j=0;j<((7 / TransformEmptyObject.localScale.x)-1);j++)
		{
			Instantiate(BrickObject, position, Quaternion.identity);
			if(position.x > -7f)
			{
				position = new Vector3(position.x - 1.2f,position.y,0);
			}
		}

			position = new Vector3(StartingPos.x,position.y - 0.8f,0);

		for(int i=0;i<(TotalLines - 1);i++)
		{
			for(int j=0;j<(7 / TransformEmptyObject.localScale.x);j++)
			{
				Instantiate(BrickObject, position, Quaternion.identity);
				if(position.x < 7f)
				{
					position = new Vector3(position.x + 1.2f,position.y,0);
				}
			}
			
			position = new Vector3(StartingPos.x - 1.2f,position.y,0) ;

			for(int j=0;j<((7 / TransformEmptyObject.localScale.x)-1);j++)
			{
				Instantiate(BrickObject, position, Quaternion.identity);
				if(position.x > -7f)
				{
					position = new Vector3(position.x - 1.2f,position.y,0);
				}
			}

			position = new Vector3(StartingPos.x,position.y - 0.8f,0);
			
		}
	}

	public void deadPlayer()
	{
		isAlive = false;
		life = life - 1;
	}
}
