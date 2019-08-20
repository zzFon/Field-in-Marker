using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedChange : MonoBehaviour {

	public Slider SpeedSlider;

	public void ChangeSpeed()
	{
		GlobalVariable.Speed = 0.10f * SpeedSlider.value;
	}
}
