using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Cam : MonoBehaviour {

	void Start()
	{
		var vuforia = VuforiaARController.Instance;
		vuforia.RegisterVuforiaStartedCallback (OnVuforiaStarted);
		vuforia.RegisterOnPauseCallback (OnPaused);
	}

	private void OnVuforiaStarted()
	{
		bool focusModeSet = CameraDevice.Instance.SetFocusMode (
			CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);

		if (!focusModeSet) {
			Debug.Log ("Failed to se auto focus");
		}
	}

	private void OnPaused(bool paused)
	{
		if (!paused) 
		{
			CameraDevice.Instance.SetFocusMode (
				CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
		}
	}
}
