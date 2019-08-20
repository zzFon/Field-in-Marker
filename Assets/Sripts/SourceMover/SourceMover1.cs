using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceMover1 : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		Vector3 vec = new Vector3 (1,0,0);
		rb.velocity = vec*speed;
	}
}
