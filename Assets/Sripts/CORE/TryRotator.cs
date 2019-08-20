using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryRotator : MonoBehaviour {

	private float AngularSpeed;

	public void ChangeAngular()
	{
		GameObject AngularCube =  GameObject.Find("AngularCube");
		AngularSpeed = AngularCube.transform.localScale.x;
	}

	void Start()
	{
		GameObject AngularCube =  GameObject.Find("AngularCube");
		AngularSpeed = AngularCube.transform.localScale.x;
	}

	void Update () 
	{
		//transform.Rotate (new Vector3 (15, 30, 45) * *Time.deltaTime);
		transform.Rotate (new Vector3 (15, 30, 45) * AngularSpeed *Time.deltaTime);
	}
}
