using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngularChange : MonoBehaviour {

	//public GameObject cube;
	public Slider AngularSlider;

	public void ChangeAngular()
	{
		/*cube.transform.localScale = new Vector3(10.0f*AngularSlider.value,
			                                    10.0f*AngularSlider.value,
			                                    10.0f*AngularSlider.value);*/
		GlobalVariable.AngularSpeed = 10.0f * AngularSlider.value;
	}

	/*void Start()
	{
		cube.transform.localScale = new Vector3 (6.0f, 6.0f, 6.0f);
	}*/
}
