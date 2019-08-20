using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VortexDChange : MonoBehaviour {

	public Toggle DirectionToggle;

	public void ChangeVortexD()
	{
		if (DirectionToggle.isOn == true)
			GlobalVariable.VortexDirection = 1;// clock wise
		else if (DirectionToggle.isOn == false)
			GlobalVariable.VortexDirection = 2;// anti clock wise
	}
}
