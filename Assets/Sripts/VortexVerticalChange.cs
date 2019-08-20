using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VortexVerticalChange : MonoBehaviour {

	public GameObject cube;
	public Toggle VortexVertical;

	public void ChangeVortexVertical()
	{
		if (VortexVertical.isOn == true)
			cube.transform.localScale = new Vector3 (2.0f, 2.0f, 2.0f);
		else if (VortexVertical.isOn == false)
			cube.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
	}

	void Start()
	{
		cube.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
	}
}