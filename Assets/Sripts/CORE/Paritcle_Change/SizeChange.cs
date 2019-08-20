using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeChange : MonoBehaviour {

	public Slider SizeSlider;

	public void ChangeSize()
	{
		GlobalVariable.Size = 0.4f + 1.6f * SizeSlider.value;
	}
}
