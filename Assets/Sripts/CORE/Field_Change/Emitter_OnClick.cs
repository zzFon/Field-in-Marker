using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Emitter_OnClick : MonoBehaviour {

	public Toggle EmitterToggle;
	public Slider aSlider;
	public Slider sigmaSlider;
	public Slider dSlider;
	public Toggle AdjustX;
	public Toggle AdjustY;
	public Toggle AdjustZ;

	public void ChangeEmitterToggle()
	{
		if (EmitterToggle.isOn == true) 
		{
			// Change Field Weight
			aSlider.value = GlobalVariable.EmitterA;
			sigmaSlider.value = GlobalVariable.EmitterSigma;
			if (AdjustX.isOn == true)
				dSlider.value = GlobalVariable.EmitterDx;
			else if (AdjustY.isOn == true)
				dSlider.value = GlobalVariable.EmitterDy;
			else if (AdjustZ.isOn == true)
				dSlider.value = GlobalVariable.EmitterDz;

			// Change Visibility of Coordinate indicator (for the time being, only compaticle with MulOrNot == 0)
			GlobalVariable.SourceCoordinate = 0.015f;
			GameObject cylinder = GameObject.Find ("ssource");
			cylinder.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);

			GlobalVariable.SinkCoordinate = 0.00f;
			GameObject sphere = GameObject.Find ("ssink");
			sphere.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);

			GlobalVariable.VortexCoordinate = 0.00f;
			GameObject cube = GameObject.Find ("vvortex");
			cube.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);

			GlobalVariable.UniformCoordinate = 0.00f;
			GameObject cylinder1 = GameObject.Find ("uuniform");
			cylinder1.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);

			GlobalVariable.EmitterCoordinate = 0.015f;
			GameObject sphere1 = GameObject.Find ("eemitter");
			sphere1.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
			transform.transform.localPosition = new Vector3 (0, 0, 0); 
			transform.transform.localRotation = Quaternion.identity;
			transform.transform.Rotate (new Vector3 (90, 180, 180));
		}
		else if (EmitterToggle.isOn == false) 
		{
			// Change Visibility of Coordinate indicator (for the time being, only compaticle with MulOrNot == 0)
			GlobalVariable.EmitterCoordinate = 0.00f;
			GameObject sphere1 = GameObject.Find ("eemitter");
			sphere1.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);
		}
	}
}
