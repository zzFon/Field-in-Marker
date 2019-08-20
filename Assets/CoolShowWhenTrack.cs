using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CoolShowWhenTrack : MonoBehaviour, ITrackableEventHandler{

	private GameObject showParticle;
	private bool isShowFirst;
	#region UNTIY_MONOBEHAVIOUR_METHODS
	// Use this for initialization
	void Start () 
	{
		isShowFirst = true;

		//showParticle = GameObject.Find ("showParticle");
		//startShowEffect ();

		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	#endregion // UNTIY_MONOBEHAVIOUR_METHODS
	// ### start about track ###
	#region PRIVATE_MEMBER_VARIABLES
	private TrackableBehaviour mTrackableBehaviour;
	#endregion // PRIVATE_MEMBER_VARIABLES
	#region PUBLIC_METHODS
	/// <summary>
	/// Implementation of the ITrackableEventHandler function called when the
	/// tracking state changes.
	/// </summary>
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		// Debug.Log ("newStatus1" + newStatus);
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			OnTrackingFound();  
		}
		else
		{
			OnTrackingLost();
		}
	}
	#endregion // PUBLIC_METHODS
	#region PRIVATE_METHODS
	private void OnTrackingFound()
	{
		Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found111");

	}
	private void OnTrackingLost()
	{
		Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost111");
	}
	#endregion // PRIVATE_METHODS
}
