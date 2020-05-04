using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmitterWChange : MonoBehaviour {

	// Use this for initialization
	public Slider aSlider;
	public Slider sigmaSlider;
	public Toggle EmitterToggle;

	public void ChangeEmitterW()
	{
		if (EmitterToggle.isOn == true)
		{
			GlobalVariable.EmitterA = aSlider.value;
			GlobalVariable.EmitterSigma = sigmaSlider.value;
			GlobalVariable.EmitterW = 2.0f * GlobalVariable.EmitterA * Mathf.Exp(1.0f/Mathf.Pow(GlobalVariable.EmitterSigma,2));
		}
	}
}
