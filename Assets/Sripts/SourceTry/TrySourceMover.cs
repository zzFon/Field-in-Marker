using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrySourceMover : MonoBehaviour {

	private Rigidbody rb;
	private float sx, sy, sz;
	private float px, py, pz;
	private float normal;
	private float speed;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void Update()
	{
		sx = 0;
		sy = 0;
		sz = 0;
		px = rb.position.x;
		py = rb.position.y;
		pz = rb.position.z;

		Vector3 vel = new Vector3 (px-sx,py-sy,pz-sz);
		normal = Mathf.Sqrt (
			(px-sx)*(px-sx)+
			(py-sy)*(py-sy)+
			(pz-sz)*(pz-sz));
			
		speed = 0.01f;
		rb.velocity = (vel / normal)*speed;
	}
}
