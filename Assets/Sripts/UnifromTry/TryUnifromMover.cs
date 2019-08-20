using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryUnifromMover : MonoBehaviour {

	private Rigidbody rb;
	private float speed;
	private float normal;
	Vector3 L = new Vector3(1,0,0);

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void Update()
	{
		speed = 0.03f;
		normal = Vector3.Magnitude(L);
		rb.velocity = (L/normal)*speed;
	}
}
