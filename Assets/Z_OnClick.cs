using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Z_OnClick : MonoBehaviour {

	public Toggle SourceToggle;
	public Toggle SinkToggle;
	public Toggle VortexToggle;
	public Toggle UniformToggle;
	public Toggle EmitterToggle;
	public Slider dSlider;
	public Toggle AdjustZ;

	public void ChangeZAxisToggle()
	{
		if (AdjustZ.isOn == true) 
		{
			if (SourceToggle.isOn == true)
				dSlider.value = GlobalVariable.SourceDz;
			else if (SinkToggle.isOn == true)
				dSlider.value = GlobalVariable.SinkDz;
			else if (VortexToggle.isOn == true)
				dSlider.value = GlobalVariable.VortexDz;
			else if (UniformToggle.isOn == true)
				dSlider.value = GlobalVariable.UniformDz;
			else if (EmitterToggle.isOn == true)
				dSlider.value = GlobalVariable.EmitterDz;
		} 
	}
}
