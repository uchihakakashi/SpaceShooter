using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour {

	public GameObject hazard;
	public GameObject hazard2;
	public GameObject hazard3;
	public GameObject hazard4;
	public Vector3 spawnValue;
	public int hazardCount;
	public float startWait;
	public float waveWait;
	public float spawnWait;
	public Text scoreText;
	public Text gameOverText;
	public Text restartText;
	private int score;
	private bool gameOver;
	private bool restart;

	public Button btnRestart;
	public Button btnExit;
	void Start()
	{
		score = 0;
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
		updateScore();
		StartCoroutine(SpawnWaves());
	}
	void Update(){
		if(restart)
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	public void onStartBtn(){
		Application.LoadLevel(Application.loadedLevel);
	}
	public void onQuitBtn(){
		Application.Quit();
	}
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while(true)
		{
			for(int i = 0; i < hazardCount; i++)
			{
				GameObject typeHazard = new GameObject();
				int choose = Random.Range(1,5);
				Debug.Log(choose);
				switch(choose){
					case 1: 
						typeHazard = hazard;
						break;
					case 2: 
						typeHazard = hazard2;
						break;
					case 3:
						typeHazard = hazard3;
						break;
					case 4:
						typeHazard = hazard4;
						break;
				}

				Vector3 spawnPosition = new Vector3(Random.Range(spawnValue.x, -(spawnValue.x)), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(typeHazard, spawnPosition, spawnRotation);
				if(gameOver){
					btnRestart.gameObject.SetActive(true);
					btnExit.gameObject.SetActive(true);
					restart = true;
					break;
				}
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
			/*if (gameOver){
				btnRestart.gameObject.SetActive(true);
				btnExit.gameObject.SetActive(true);
				//restartText.text = "Press 'R' to restart";
				
				break;
			}*/
			
		}
		
		
	}
	void updateScore()
	{
		scoreText.text = "Score: " + score;
	}
	public void addScore(int newScoreValue){
		score += newScoreValue;
		updateScore();
	}
	public void GameOver()
	{
		gameOverText.text = "GameOver";
		gameOver = true;
	}
	
}
