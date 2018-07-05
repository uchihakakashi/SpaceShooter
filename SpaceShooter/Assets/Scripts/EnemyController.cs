using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public GameObject shot;
	// Use this for initialization
	public GameObject shotPawn;
	public float fireRate = 1.5f;
	public float delay = 1.0f;
	void Start(){
		InvokeRepeating("Fire", delay, fireRate);
	}

	void Fire(){
		Instantiate(shot, shotPawn.transform.position, shotPawn.transform.rotation);
			GetComponent<AudioSource>().Play();
	}
}
