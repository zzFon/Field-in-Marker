using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S : MonoBehaviour {

	private float offset1,offset2;
	public GameObject T;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (CreateT());
	}
	
	IEnumerator CreateT()
	{
		yield return new WaitForSeconds (0);
		while (true)
		{
			/*offset1 = Random.Range (-0.01f, 0.01f);
			offset2 = Random.Range (-0.01f, 0.01f);*/
			offset1 = Random.Range (-0.05f, 0.05f);
			offset2 = Random.Range (-0.05f, 0.05f);
			Instantiate (T, new Vector3 (0 + offset1, 0, 0 + offset2), new Quaternion (45, 45, 45, 0));
			//yield return new WaitForSeconds (0.1f);
			yield return new WaitForSeconds (0.5f);
		}
	}
}
