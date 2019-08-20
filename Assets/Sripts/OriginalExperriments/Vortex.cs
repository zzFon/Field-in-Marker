using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : MonoBehaviour {

	private Rigidbody rb;
	public float tumble;
	//public float x,y,z;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		Vector3 vec = new Vector3 (0,1,0);
		rb.angularVelocity = vec*tumble;
	}
}
