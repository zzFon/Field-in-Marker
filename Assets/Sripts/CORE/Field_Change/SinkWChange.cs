using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinkWChange : MonoBehaviour {

	//public GameObject cube;
	public Slider aSlider;
	public Slider sigmaSlider;
	public Toggle SinkToggle;

	public void ChangeSinkW()
	{
		if (SinkToggle.isOn == true)
		{
			GlobalVariable.SinkA = aSlider.value;
			GlobalVariable.SinkSigma = sigmaSlider.value;
			GlobalVariable.SinkW = 2.0f * GlobalVariable.SinkA * Mathf.Exp(1.0f/Mathf.Pow(GlobalVariable.SinkSigma,2));
		}
	}
}