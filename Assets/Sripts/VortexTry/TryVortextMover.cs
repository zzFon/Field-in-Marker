using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryVortextMover : MonoBehaviour {

	private Rigidbody rb;
	private float speed;
	private float normal;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void Update()
	{
		Vector3 o = new Vector3 (0, 0, 0);
		Vector3 p = new Vector3 (rb.position.x, rb.position.y, rb.position.z);
		Vector3 n = new Vector3 (0,1,0);

		Vector3 numerator = p - o - (Vector3.Dot (n, (p - o))) * n;
		normal = Vector3.Magnitude(numerator);

		speed = 0.05f;
		rb.velocity = (Vector3.Cross(numerator,n)/normal)*speed;
	}
}
