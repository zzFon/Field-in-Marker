using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SourceEChange : MonoBehaviour {

	public Toggle EmitterOnlyToggle;

	public void ChangEmitter()
	{
		if (EmitterOnlyToggle.isOn == true)
			GlobalVariable.EmitterOnly = true;// Only Emitter no Particles
		else if (EmitterOnlyToggle.isOn == false)
			GlobalVariable.EmitterOnly = false;// with Particles
	}
}
