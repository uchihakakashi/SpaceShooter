using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SimpleTouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler{
	public float smoothing;
	private Vector2 origin;
	private Vector2 direction;
	private Vector2 smoothDirection;
	private int pointerId;
	private bool touched;
	private Vector2 currentPos;
	public void OnPointerDown(PointerEventData data){
		if(!touched){
			touched = true;
			pointerId = data.pointerId;
			origin = data.position;
		}
	}
	public void OnDrag(PointerEventData data){
		if (data.pointerId == pointerId){
			currentPos = data.position;
			
			Vector2 directionDraw = currentPos - origin;
			
			direction = directionDraw.normalized;
			Debug.Log(direction);
		}
		
	}
	public void OnPointerUp(PointerEventData data){
		if(data.pointerId == pointerId){
			direction = Vector2.zero;
			touched = false;
		}
	}
	public Vector2 GetDirection(){
		smoothDirection = Vector2.MoveTowards(smoothDirection, direction, smoothing);
		//smoothDirection = direction;
		return smoothDirection;
	}
	public float getMagnitude(){
		return Vector2.MoveTowards(smoothDirection, direction, smoothing).magnitude;
	}
	public Vector2 getCurrentPos(){
		return currentPos;
	}
}
