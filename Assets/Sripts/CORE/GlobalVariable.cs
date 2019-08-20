using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariable : MonoBehaviour 
{
	//Particle Parameters             Calculate the Initial Value for the Sliders
	public static float Size = 0.6f;// 0.6/(0.4+1.6) = 30%
	public static float Speed = 0.02f;// 0.02/0.08 = 25%
	public static float AngularSpeed = 6.0f;// 6/10 = 60%
	public static float LifeSpan = 3.0f;// 6/10 = 60%
	public static float WaitTime = 0.2f;// 0.2/0.5 = 40%

	//Field Parameters                Calculate the Initial Value for the Sliders
	public static float SourceW = 1.0f;// 1/2 = 50%
	public static float SinkW = 1.0f;// 1/2 = 50%
	public static float VortexW = 1.0f;// 1/2 = 50%
	public static float UniformW = 1.0f;// 1/2 = 50%
	public static int VortexDirection = 2;// anti Clock Wise
}
