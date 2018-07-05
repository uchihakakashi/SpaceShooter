using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

	// Use this for initialization
	public int lifeTime;
	void Start () {
		Destroy(gameObject, lifeTime);
	}
	
}
