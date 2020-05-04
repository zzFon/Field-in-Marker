using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class X_OnClick : MonoBehaviour {

	public Toggle SourceToggle;
	public Toggle SinkToggle;
	public Toggle VortexToggle;
	public Toggle UniformToggle;
	public Toggle EmitterToggle;
	public Slider dSlider;
	public Toggle AdjustX;

	public void ChangeXAxisToggle()
	{
		if (AdjustX.isOn == true) 
		{
			if (SourceToggle.isOn == true)
				dSlider.value = GlobalVariable.SourceDx;
			else if (SinkToggle.isOn == true)
				dSlider.value = GlobalVariable.SinkDx;
			else if (VortexToggle.isOn == true)
				dSlider.value = GlobalVariable.VortexDx;
			else if (UniformToggle.isOn == true)
				dSlider.value = GlobalVariable.UniformDx;
			else if (EmitterToggle.isOn == true)
				dSlider.value = GlobalVariable.EmitterDx;
		} 
	}
}
