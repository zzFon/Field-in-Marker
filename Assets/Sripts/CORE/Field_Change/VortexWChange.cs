using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VortexWChange : MonoBehaviour {

	//public GameObject cube;
	public Slider aSlider;
	public Slider sigmaSlider;
	public Toggle VortexToggle;

	public void ChangeVortexW()
	{
		if (VortexToggle.isOn == true)
		{
			GlobalVariable.VortexA = aSlider.value;
			GlobalVariable.VortexSigma = sigmaSlider.value;
			GlobalVariable.VortexW = 2.0f * GlobalVariable.VortexA * Mathf.Exp(1.0f/Mathf.Pow(GlobalVariable.VortexSigma,2));
		}
	}
}
