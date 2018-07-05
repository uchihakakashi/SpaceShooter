using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

	// Use this for initialization
	public float scrollSpeed;
	private Vector3 startPosition;
	void Start () {
		startPosition = transform.position;	
	}
	void Update(){
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, 30);
		transform.position = startPosition + Vector3.forward * newPosition;
	}
	
}
