using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UniformWChange : MonoBehaviour {

	//public GameObject cube;
	public Slider UniformSlider;

	public void ChangeUniformW()
	{
		/*cube.transform.localScale = new Vector3(2.0f*UniformSlider.value,
			                                    2.0f*UniformSlider.value,
			2.0f*UniformSlider.value);*/
		GlobalVariable.UniformW = 2.0f * UniformSlider.value;
	}

	/*void Start()
	{
		cube.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
	}*/
}
