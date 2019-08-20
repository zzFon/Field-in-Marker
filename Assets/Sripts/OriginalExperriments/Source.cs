using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour {

	public GameObject T;
	public float offset1,offset2;

	void Start()
	{
		StartCoroutine (CreateField());
	}

	IEnumerator CreateField () 
	{
		yield return new WaitForSeconds (0);
		while (true)
		{
			offset1 = Random.Range (-0.07f, 0.07f);
			offset2 = Random.Range (-0.07f, 0.07f);
			Instantiate (T, new Vector3 (0 + offset1, 0, 0 + offset2), new Quaternion (45, 45, 45, 0));
			yield return new WaitForSeconds (0.1f);
		}
	}
}
