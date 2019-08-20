	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	private Rigidbody rb;
	void Update () 
	{
		transform.Rotate (new Vector3 (Random.Range(-180,180), Random.Range(-180,180), Random.Range(-180,180)) * 2*Time.deltaTime);
	}
}
