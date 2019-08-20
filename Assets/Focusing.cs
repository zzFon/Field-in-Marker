using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Focusing : MonoBehaviour {

	private string label;
	private float touchduration;
	private Touch touch;

	void Start ()
	{
		if (Input.touchCount > 0)
		{
			touchduration += Time.deltaTime;
			touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Ended && touchduration < 0.2f)
			{
				StartCoroutine("SingleOrDouble");
			}
		}
		else
		{
			touchduration = 0;
		}
	}

	void Update () {

		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	IEnumerator SingleOrDouble()
	{
		yield return new WaitForSeconds(0.3f);
		if (touch.tapCount == 1)
		{
			Debug.Log("Single");
			OnSingleTapped();
		}
		else if (touch.tapCount == 2)
		{
			StopCoroutine("SingleOrDouble");//否则会触发两次Double Touch
			Debug.Log("Double");
			OnDoubleTapped();
		}
	}

	private void OnSingleTapped()
	{
		TriggerAutoFocus();
		label = "Tap the Screen!";
	}

	private void OnDoubleTapped()
	{
		label = "Double Tap the Screen!";
	}

	public void TriggerAutoFocus()
	{
		StartCoroutine(TriggerAutoFocusAndEnableContinuousFocusIfSet());
	}

	private IEnumerator TriggerAutoFocusAndEnableContinuousFocusIfSet()
	{
		CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
		yield return new WaitForSeconds(1.0f);
		CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
	}

	void OnGUI()
	{
		GUI.Label(new Rect(10, 0, 100, 100), "-&-C*-Z*-D*-&->" + label);
	}
}
