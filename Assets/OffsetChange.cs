using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffsetChange : MonoBehaviour {

	public Slider dSlider;
	public Toggle AdjustX;
	public Toggle AdjustY;
	public Toggle AdjustZ;

	public Toggle SetSource;
	public Toggle SetSink;
	public Toggle SetVortex;
	public Toggle SetUniform;
	public Toggle SetEmitter;

	public void ChangeOffset()
	{
		float sx = 0.0f;
		float sy = 0.0f;
		float sz = 0.0f;

		// get initial value
		GameObject axis = GameObject.Find ("ssource");
		if (SetSource.isOn == true) 
		{
			axis = GameObject.Find ("ssource");
			sx = GlobalVariable.SourceDx;	
			sy = GlobalVariable.SourceDy;
			sz = GlobalVariable.SourceDz;
		} 
		else if (SetSink.isOn == true) 
		{
			axis = GameObject.Find ("ssink");
			sx = GlobalVariable.SinkDx;	
			sy = GlobalVariable.SinkDy;
			sz = GlobalVariable.SinkDz;	
		}
		else if (SetVortex.isOn == true) 
		{
			axis = GameObject.Find ("vvortex");
			sx = GlobalVariable.VortexDx;
			sy = GlobalVariable.VortexDy;
			sz = GlobalVariable.VortexDz;
		} 
		else if (SetUniform.isOn == true)
		{
			axis = GameObject.Find ("uuniform");
			sx = GlobalVariable.UniformDx;	
			sy = GlobalVariable.UniformDy;
			sz = GlobalVariable.UniformDz;
		} 
		else if (SetEmitter.isOn == true) 
		{
			axis = GameObject.Find ("eemitter");
			sx = GlobalVariable.EmitterDx;	
			sy = GlobalVariable.EmitterDx;
			sz = GlobalVariable.EmitterDx;
		}

		// read from slider
		if (AdjustX.isOn == true) 
		{
			sx = 0.3f*dSlider.value;
		}
		else if (AdjustY.isOn == true)
		{
			sy = 0.3f*dSlider.value;
		}
		else if (AdjustZ.isOn == true)
		{
			sz = 0.3f*dSlider.value;
		}

		// save values to global
		axis.transform.localPosition = new Vector3 (0, 0, sz);	
		if (SetSource.isOn == true)
		{
			GlobalVariable.SourceDx = sx;	
			GlobalVariable.SourceDy = sy;
			GlobalVariable.SourceDz = sz;	
		} 
		else if (SetSink.isOn == true) 
		{
			GlobalVariable.SinkDx = sx;	
			GlobalVariable.SinkDy = sy;
			GlobalVariable.SinkDz = sz;	
		} 
		else if (SetVortex.isOn == true) 
		{
			GlobalVariable.VortexDx = sx;
			GlobalVariable.VortexDx = sy;
			GlobalVariable.VortexDx = sz;
		} 
		else if (SetUniform.isOn == true) 
		{
			GlobalVariable.UniformDx = sx;	
			GlobalVariable.UniformDy = sy;
			GlobalVariable.UniformDz = sz;
		} 
		else if (SetEmitter.isOn == true) 
		{
			GlobalVariable.EmitterDx = sx;	
			GlobalVariable.EmitterDx = sy;
			GlobalVariable.EmitterDx = sz;
		}

		// refresh
		axis.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
		axis.transform.localPosition = new Vector3 (sx, sy, sz); 
		axis.transform.localRotation = Quaternion.identity;
		axis.transform.Rotate (new Vector3 (90, 180, 180));

	}
}
