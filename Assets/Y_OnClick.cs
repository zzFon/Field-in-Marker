using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Y_OnClick : MonoBehaviour {

	public Toggle SourceToggle;
	public Toggle SinkToggle;
	public Toggle VortexToggle;
	public Toggle UniformToggle;
	public Toggle EmitterToggle;
	public Slider dSlider;
	public Toggle AdjustY;

	public void ChangeYAxisToggle()
	{
		if (AdjustY.isOn == true) 
		{
			if (SourceToggle.isOn == true)
				dSlider.value = GlobalVariable.SourceDy;
			else if (SinkToggle.isOn == true)
				dSlider.value = GlobalVariable.SinkDy;
			else if (VortexToggle.isOn == true)
				dSlider.value = GlobalVariable.VortexDy;
			else if (UniformToggle.isOn == true)
				dSlider.value = GlobalVariable.UniformDy;
			else if (EmitterToggle.isOn == true)
				dSlider.value = GlobalVariable.EmitterDy;
		} 
	}
}
