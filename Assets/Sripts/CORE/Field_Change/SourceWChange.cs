using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SourceWChange : MonoBehaviour {

	//public GameObject cube;
	public Slider aSlider;
	public Slider sigmaSlider;
	public Toggle SourceToggle;

	public void ChangeSourceW()
	{
		if (SourceToggle.isOn == true)
		{
			GlobalVariable.SourceA = aSlider.value;
			GlobalVariable.SourceSigma = sigmaSlider.value;
			GlobalVariable.SourceW = 2.0f * GlobalVariable.SourceA * Mathf.Exp(1.0f/Mathf.Pow(GlobalVariable.SourceSigma,2));
		}
	}
}