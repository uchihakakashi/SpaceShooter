using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeystroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		// Deystroy everything that leave the trigger
		Destroy(other.gameObject);
	}
}
