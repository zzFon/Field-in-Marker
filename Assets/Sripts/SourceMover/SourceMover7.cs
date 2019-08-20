using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceMover7 : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		Vector3 vec = new Vector3 (0.707f,0,-0.707f);
		rb.velocity = vec*speed;
	}
}
