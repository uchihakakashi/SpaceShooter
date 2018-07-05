using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float minX, maxX, minZ, maxZ;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotPawn;
	public SimpleTouchPad touchpad;
	public SimpleTouchAreaButton areaButton;
	public float fireRate; 
	float nextFire;
	private Quaternion calibrationgQuaternion;
	void Start(){
		CalibrateAccelermeter();
	}
	void Update(){
		if(areaButton.CanFire () && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotPawn.position, shotPawn.rotation);
			GetComponent<AudioSource>().Play();
		}
		
	}
	//Used to calibrate the Input.acceleration input
	void CalibrateAccelermeter(){
		Vector3 accelerationSnapshot = Input.acceleration;
		Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot);
		calibrationgQuaternion = Quaternion.Inverse(rotateQuaternion);
	}
	Vector3 FixAcceleration(Vector3 acceleration){
		Vector3 fixedAcceleration = calibrationgQuaternion * acceleration;
		return fixedAcceleration;
	}
	void FixedUpdate()
	{
		//float moveHorizontal = Input.GetAxis("Horizontal");
		//float moveVertical = Input.GetAxis("Vertical");
		//Vector3 accelerationRaw = Input.acceleration;
		//Vector3 acceleration = FixAcceleration(accelerationRaw);
		//Vector2 direction = touchpad.GetDirection();
		//Vector3 movement = new Vector3(direction.x, 0.0f, direction.y);
		if(Input.touchCount > 0){
			Debug.Log("touching....");
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved){
				Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
				transform.position = Vector3.Lerp(transform.position, touchedPos, 7* Time.deltaTime);
			}
		}
		//GetComponent<Rigidbody>().velocity = movement * speed;
		

		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.minX, boundary.maxX),
			0.0f,
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.minZ, boundary.maxZ)
		);
		//Debug.Log(GetComponent<Rigidbody>().position);
		GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x*tilt);
	}
}
