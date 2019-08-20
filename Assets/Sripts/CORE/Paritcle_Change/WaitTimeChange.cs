using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitTimeChange : MonoBehaviour {
	
	public Slider WaitTimeSlider;

	public void ChangeWaitTime()
	{
		GlobalVariable.WaitTime = 0.01f + 0.49f * WaitTimeSlider.value;
	}
}
