using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceMover4 : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		Vector3 vec = new Vector3 (0,0,-1);
		rb.velocity = vec*speed;
	}
}
