using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uniform_OnClink : MonoBehaviour {

	//public GameObject cube;
	public Toggle UniformToggle;
	public Slider aSlider;
	public Slider sigmaSlider;
	public Slider dSlider;
	public Toggle AdjustX;
	public Toggle AdjustY;
	public Toggle AdjustZ;

	public void ChangeUniformToggle()
	{
		if (UniformToggle.isOn == true) 
		{
			// Change Field Weight
			aSlider.value = GlobalVariable.UniformA;
			sigmaSlider.value = GlobalVariable.UniformSigma;
			if (AdjustX.isOn == true)
				dSlider.value = GlobalVariable.UniformDx;
			else if (AdjustY.isOn == true)
				dSlider.value = GlobalVariable.UniformDy;
			else if (AdjustZ.isOn == true)
				dSlider.value = GlobalVariable.UniformDz;

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

			GlobalVariable.UniformCoordinate = 0.015f;
			GameObject cylinder1 = GameObject.Find ("uuniform");
			cylinder1.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
			cylinder1.transform.localPosition = new Vector3 (0, 0, 0); 
			cylinder1.transform.localRotation = Quaternion.identity;
			cylinder1.transform.Rotate (new Vector3 (90, 180, 180));

			GlobalVariable.EmitterCoordinate = 0.00f;
			GameObject sphere1 = GameObject.Find ("eemitter");
			sphere1.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);
		}
		else if (UniformToggle.isOn == false) 
		{
			// Change Visibility of Coordinate indicator (for the time being, only compaticle with MulOrNot == 0)
			GlobalVariable.UniformCoordinate = 0.00f;
			GameObject cylinder1 = GameObject.Find ("uuniform");
			cylinder1.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);
		}
	}
}

