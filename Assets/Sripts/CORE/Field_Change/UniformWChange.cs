using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UniformWChange : MonoBehaviour {

	//public GameObject cube;
	public Slider aSlider;
	public Slider sigmaSlider;
	public Toggle UniformToggle;

	public void ChangeUniformW()
	{
		if (UniformToggle.isOn == true)
		{
			GlobalVariable.UniformA = aSlider.value;
			GlobalVariable.UniformSigma = sigmaSlider.value;
			GlobalVariable.UniformW = 2.0f * GlobalVariable.UniformA * Mathf.Exp(1.0f/Mathf.Pow(GlobalVariable.UniformSigma,2));
		}
	}
}
