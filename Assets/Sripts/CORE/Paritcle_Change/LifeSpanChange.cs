using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSpanChange : MonoBehaviour {

	public Slider LifeSpanSlider;

	public void ChangeLifeSpan()
	{
		GlobalVariable.LifeSpan = 0.5f + 9.5f * LifeSpanSlider.value;
	}
}
