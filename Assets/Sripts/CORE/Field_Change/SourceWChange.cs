using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SourceWChange : MonoBehaviour {

	//public GameObject cube;
	public Slider SourceSlider;

	public void ChangeSourceW()
	{
		/*cube.transform.localScale = new Vector3(2.0f*SourceSlider.value,
			                                    2.0f*SourceSlider.value,
			2.0f*SourceSlider.value);*/
		GlobalVariable.SourceW = 2.0f * SourceSlider.value;
	}

	/*void Start()
	{
		cube.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
	}*/
}