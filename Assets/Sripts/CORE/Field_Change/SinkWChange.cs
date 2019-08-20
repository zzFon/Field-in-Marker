using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinkWChange : MonoBehaviour {

	//public GameObject cube;
	public Slider SinkSlider;

	public void ChangeSinkW()
	{
		/*cube.transform.localScale = new Vector3(2.0f*SinkSlider.value,
			                                    2.0f*SinkSlider.value,
			2.0f*SinkSlider.value);*/
		GlobalVariable.SinkW = 2.0f * SinkSlider.value;
	}

	/*void Start()
	{
		cube.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
	}*/
}