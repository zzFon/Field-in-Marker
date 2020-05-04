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
	public static float SourceA = 1.0f;
	public static float SourceSigma = 1.0f;
	public static float SourceW = 1.0f;// 1/2 = 50%
	public static float SourceDx = 0.0f; public static float SourceDy = 0.0f; public static float SourceDz = 0.0f;

	public static float SinkA = 1.0f;
	public static float SinkSigma = 1.0f;
	public static float SinkW = 1.0f;// 1/2 = 50%
	public static float SinkDx = 0.0f; public static float SinkDy = 0.0f; public static float SinkDz = 0.0f;

	public static float VortexA = 1.0f;
	public static float VortexSigma = 1.0f;
	public static float VortexW = 1.0f;// 1/2 = 50%
	public static float VortexDx = 0.0f; public static float VortexDy = 0.0f; public static float VortexDz = 0.0f;

	public static float UniformA = 1.0f;
	public static float UniformSigma = 1.0f;
	public static float UniformW = 1.0f;// 1/2 = 50%
	public static float UniformDx = 0.0f; public static float UniformDy = 0.0f; public static float UniformDz = 0.0f;

	public static float EmitterA = 1.0f;
	public static float EmitterSigma = 1.0f;
	public static float EmitterW = 1.0f;// 1/2 = 50%
	public static float EmitterDx = 0.0f; public static float EmitterDy = 0.0f; public static float EmitterDz = 0.0f;

	public static int VortexDirection = 2;// anti Clock Wise
	public static bool EmitterOnly = false;

	//Fields
	public static string[] sources;
	public static int num_sources = 0;
	public static string[] sinks;
	public static int num_sinks = 0;
	public static string[] vortexes;
	public static int num_vortexes = 0;
	public static string[] uniforms;
	public static int num_uniforms = 0;
	public static bool MulOrNot = false;
	public static string[] emitters;
	public static int num_emitters = 0;
	public static float SourceCoordinate = 0.015f;
	public static float SinkCoordinate = 0.00f;
	public static float VortexCoordinate = 0.00f;
	public static float UniformCoordinate = 0.00f;
	public static float EmitterCoordinate = 0.00f;
}
