using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vortex_OnClink : MonoBehaviour {

	//public GameObject cube;
	public Toggle VortexToggle;
	public Slider aSlider;
	public Slider sigmaSlider;
	public Slider dSlider;
	public Toggle AdjustX;
	public Toggle AdjustY;
	public Toggle AdjustZ;

	public void ChangeVortexToggle()
	{
		if (VortexToggle.isOn == true) 
		{
			// Change Field Weight
			aSlider.value = GlobalVariable.VortexA;
			sigmaSlider.value = GlobalVariable.VortexSigma;
			if (AdjustX.isOn == true)
				dSlider.value = GlobalVariable.VortexDx;
			else if (AdjustY.isOn == true)
				dSlider.value = GlobalVariable.VortexDy;
			else if (AdjustZ.isOn == true)
				dSlider.value = GlobalVariable.VortexDz;

			// Change Visibility of Coordinate indicator (for the time being, only compaticle with MulOrNot == 0)
			GlobalVariable.SourceCoordinate = 0.00f;
			GameObject cylinder = GameObject.Find ("ssource");
			cylinder.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);

			GlobalVariable.SinkCoordinate = 0.00f;
			GameObject sphere = GameObject.Find ("ssink");
			sphere.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);

			GlobalVariable.VortexCoordinate = 0.015f;
			GameObject cube = GameObject.Find ("vvortex");
			cube.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
			cube.transform.localPosition = new Vector3 (0, 0, 0); 
			cube.transform.localRotation = Quaternion.identity;
			cube.transform.Rotate (new Vector3 (90, 180, 180));

			GlobalVariable.UniformCoordinate = 0.00f;
			GameObject cylinder1 = GameObject.Find ("uuniform");
			cylinder1.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);

			GlobalVariable.EmitterCoordinate = 0.00f;
			GameObject sphere1 = GameObject.Find ("eemitter");
			sphere1.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);
		}
		else if (VortexToggle.isOn == false) 
		{
			// Change Visibility of Coordinate indicator (for the time being, only compaticle with MulOrNot == 0)
			GlobalVariable.VortexCoordinate = 0.00f;
			GameObject cube = GameObject.Find ("vvortex");
			cube.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);
		}
	}
}
