using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class ModeControl : MonoBehaviour 
{

	public GameObject DirectorModeCanvas;
	//private int ConfigCount = 0;

	/*void Start()
	{
		StreamReader sr;
		string Particle = "";
		float ParticleSize = 0;
		float Speed = 0;
		float AngularSpeed = 0;

		var addr = System.IO.Path.Combine(Application.streamingAssetsPath, "para_SelectParticle.txt");
		sr = File.OpenText (addr);
		string t_Line;
		if ((t_Line = sr.ReadLine ()) != null)
		{
			Particle = t_Line;
			ConfigCount = ConfigCount + 1;
			print ("SelectParticle:");
			print (Particle);
		} 
		else 
		{
			print ("config NOT FOUND !");
		}
		sr.Close ();
		sr.Dispose ();

		addr = System.IO.Path.Combine(Application.streamingAssetsPath, "para_ParticleSize.txt");
		sr = File.OpenText (addr);
		if ((t_Line = sr.ReadLine ()) != null)
		{
			ParticleSize = float.Parse(t_Line);
			ConfigCount = ConfigCount + 1;
			print ("ParticleSize:");
			print (ParticleSize);
		} 
		else 
		{
			print ("config NOT FOUND !");
		}
		sr.Close ();
		sr.Dispose ();

		addr = System.IO.Path.Combine(Application.streamingAssetsPath, "para_Speed.txt");
		sr = File.OpenText (addr);
		if ((t_Line = sr.ReadLine ()) != null)
		{
			Speed = float.Parse (t_Line);
			ConfigCount = ConfigCount + 1;
			print ("Speed");
			print (Speed);
		} 
		else 
		{
			print ("config NOT FOUND !");
		}
		sr.Close ();
		sr.Dispose ();

		addr = System.IO.Path.Combine(Application.streamingAssetsPath, "para_AngularSpeed.txt");
		sr = File.OpenText (addr);
		if ((t_Line = sr.ReadLine ()) != null)
		{
			AngularSpeed = float.Parse (t_Line);
			ConfigCount = ConfigCount + 1;
			print ("AngularSpeed:");
			print (AngularSpeed);
		} 
		else 
		{
			print ("config NOT FOUND !");
		}
		sr.Close ();
		sr.Dispose ();
	}*/
			
	public Toggle DirectorModeToggle, AudienceModeToggle;
	void Update () 
    {
		if (DirectorModeToggle.isOn == true && AudienceModeToggle.isOn == false)// Director Mode
			DirectorModeCanvas.SetActive (true);
		else if (DirectorModeToggle.isOn == false && AudienceModeToggle.isOn == true)// Audience Mode
			DirectorModeCanvas.SetActive (false);
	}
}
