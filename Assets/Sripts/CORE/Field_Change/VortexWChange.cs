using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VortexWChange : MonoBehaviour {

	//public GameObject cube;
	public Slider VortexSlider;

	public void ChangeVortexW()
	{
		/*cube.transform.localScale = new Vector3(2.0f*VortexSlider.value,
			                                    2.0f*VortexSlider.value,
			                                    2.0f*VortexSlider.value);*/
		GlobalVariable.VortexW = 2.0f * VortexSlider.value;
	}

	/*void Start()
	{
		cube.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
	}*/
}
