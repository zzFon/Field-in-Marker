using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sink_OnClink : MonoBehaviour {

	//public GameObject cube;
	public Toggle SinkToggle;
	public Slider aSlider;
	public Slider sigmaSlider;
	public Slider dSlider;
	public Toggle AdjustX;
	public Toggle AdjustY;
	public Toggle AdjustZ;

	public void ChangeSinkToggle()
	{
		if (SinkToggle.isOn == true) 
		{
			// Change Field Weight
			aSlider.value = GlobalVariable.SinkA;
			sigmaSlider.value = GlobalVariable.SinkSigma;
			if (AdjustX.isOn == true)
				dSlider.value = GlobalVariable.SinkDx;
			else if (AdjustY.isOn == true)
				dSlider.value = GlobalVariable.SinkDy;
			else if (AdjustZ.isOn == true)
				dSlider.value = GlobalVariable.SinkDz;

			// Change Visibility of Coordinate indicator (for the time being, only compaticle with MulOrNot == 0)
			GlobalVariable.SourceCoordinate = 0.000f;
			GameObject cylinder = GameObject.Find ("ssource");
			cylinder.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);

			GlobalVariable.SinkCoordinate = 0.015f;
			GameObject sphere = GameObject.Find ("ssink");
			sphere.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
			sphere.transform.localPosition = new Vector3 (0, 0, 0); 
			sphere.transform.localRotation = Quaternion.identity;
			sphere.transform.Rotate (new Vector3 (90, 180, 180));

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
		else if (SinkToggle.isOn == false) 
		{
			// Change Visibility of Coordinate indicator (for the time being, only compaticle with MulOrNot == 0)
			GlobalVariable.SinkCoordinate = 0.00f;
			GameObject sphere = GameObject.Find ("ssink");
			sphere.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);
		}
	}
}
