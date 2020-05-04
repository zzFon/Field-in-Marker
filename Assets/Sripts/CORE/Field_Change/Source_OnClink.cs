using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Source_OnClink : MonoBehaviour {

	//public GameObject cube;
	public Toggle SourceToggle;
	public Slider aSlider;
	public Slider sigmaSlider;
	public Slider dSlider;
	public Toggle AdjustX;
	public Toggle AdjustY;
	public Toggle AdjustZ;

	public void ChangeSourceToggle()
	{
		if (SourceToggle.isOn == true) 
		{
			// Change Field Weight
			aSlider.value = GlobalVariable.SourceA;
			sigmaSlider.value = GlobalVariable.SourceSigma;
			if (AdjustX.isOn == true)
				dSlider.value = GlobalVariable.SourceDx;
			else if (AdjustY.isOn == true)
				dSlider.value = GlobalVariable.SourceDy;
			else if (AdjustZ.isOn == true)
				dSlider.value = GlobalVariable.SourceDz;

			// Change Visibility of Coordinate indicator (for the time being, only compaticle with MulOrNot == 0)
			GlobalVariable.SourceCoordinate = 0.015f;
			GameObject cylinder = GameObject.Find ("ssource");
			cylinder.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
			cylinder.transform.localPosition = new Vector3 (0, 0, 0); 
			cylinder.transform.localRotation = Quaternion.identity;
			cylinder.transform.Rotate (new Vector3 (90, 180, 180));

			GlobalVariable.SinkCoordinate = 0.00f;
			GameObject sphere = GameObject.Find ("ssink");
			sphere.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);

			GlobalVariable.VortexCoordinate = 0.00f;
			GameObject cube = GameObject.Find ("vvortex");
			cube.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);

			GlobalVariable.UniformCoordinate = 0.00f;
			GameObject cylinder1 = GameObject.Find ("uuniform");
			cylinder1.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);

			GlobalVariable.EmitterCoordinate = 0.00f;
			GameObject sphere1 = GameObject.Find ("eemitter");
			sphere1.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);
		} 
		else if (SourceToggle.isOn == false) 
		{
			// Change Visibility of Coordinate indicator (for the time being, only compaticle with MulOrNot == 0)
			GlobalVariable.SourceCoordinate = 0.00f;
			GameObject cylinder = GameObject.Find ("ssource");
			cylinder.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);
		}
	}
}
