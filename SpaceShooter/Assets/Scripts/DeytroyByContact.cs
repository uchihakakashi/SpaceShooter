using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeytroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	private GameController gameController;
	public int scoreValue;
	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		else
		{
			Debug.Log("Cannot find game Controller Script");
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary")
		{
			return;
		}
		if (other.tag == "Enemy")
		{
			return;
		}
		
		if (other.tag == "player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		Instantiate(explosion, transform.position, transform.rotation);
		gameController.addScore(scoreValue);
		
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
