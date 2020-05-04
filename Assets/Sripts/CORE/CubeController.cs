
using System.Collections;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System.Reflection;
//using UnityEditor;

/// <summary>
/// 实现IUserDefinedTargetEventHandler
/// </summary>
public class CubeController : MonoBehaviour, IUserDefinedTargetEventHandler
{
	//This class serves both as an augmentation definition for an ImageTarget in the editor as well as a tracked image target result at runtime
	//需要初始化成ImageTarget，imageTargetTemplate用于hold recognized Target
	public ImageTargetBehaviour imageTargetTemplate;

	//This Component can be used to create new ImageTargets at runtime. It can be configured to start scanning automatically or via a call from an external script. Registered event handlers will be informed of changes in the frame quality as well as new TrackableSources
	//用于将UserDefinedTargetBehaviour注册到incident system中，当frame changed会inform the system
	private UserDefinedTargetBuildingBehaviour targetBuildingBehaviour;

	//The ObjectTracker encapsulates methods to manage DataSets and provides access to the ImageTargetBuilder and TargetFinder classes
	//用于make DataSet，将new Target record到DataSet
	private ObjectTracker objectTracker;

	//DataSet，数据集，record了拍的Target
	private DataSet dataSet;

	//record Target的数目
	private int targetCounter = 0;

	//表示Target的Quality
	public ImageTargetBuilder.FrameQuality currentQuality;


	void Start()
	{
		targetBuildingBehaviour = GetComponent<UserDefinedTargetBuildingBehaviour>();

		//将class CubeController注册到事件system
		targetBuildingBehaviour.RegisterEventHandler(this);
	}
		
	/// 在Vuforia初始化完成后call
	public void OnInitialized()
	{
		// Returns the instance of the given tracker type See the Tracker base class for  a list of available tracker classes. This function will return null if the tracker  of the given type has not been initialized.
		objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();//有新的instance就返回，没有就null
		if (objectTracker != null)
		{
			//set up新的DataSet
			dataSet = objectTracker.CreateDataSet();
			//激活DataSet
			objectTracker.ActivateDataSet(dataSet);
		}
	}

	//TO DETECT THE QUALITY OF THE CURRENT FRAME
	public Text qualityText;
	public void OnFrameQualityChanged(ImageTargetBuilder.FrameQuality frameQuality)
	{
		currentQuality = frameQuality;
		if (currentQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_HIGH)
			qualityText.text = "Marker Quality: H";
		else if (currentQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_MEDIUM)
			qualityText.text = "Marker Quality: M";
		else
			qualityText.text = "Marker Quality: L";
	}

	/*public Text trackableText;
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		   newStatus == TrackableBehaviour.Status.TRACKED ||
		   newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) 
		{
			trackableText.text = "FOUND";
			//print ("FOUND");
		} 
		else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
		        newStatus == TrackableBehaviour.Status.NOT_FOUND) 
		{
			trackableText.text = "LOST";
			//print ("LOST");
		}
	}*/

/////////////////////////////////////////////////////////////////////////////////////////////////////
	/*void Update()
	{
		GameObject cylinder = GameObject.Find ("ppp");
		if (cylinder != null)
			Destroy (cylinder);
		cylinder = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
		cylinder.name = "ppp";

		cylinder.transform.localScale = new Vector3(0.02f,0.02f,0.02f);
		cylinder.transform.localPosition = new Vector3(0,0,0);
		cylinder.transform.localRotation = Quaternion.identity;
	}*/

	public ImageTargetBuilder builder;
	/// 此方法attached在button上，用于开始create新object（ImageTarget）并向事件system send new TrackableSource is available
	/// 注意，是开始create而不是this方法就能create好了，它需要和OnNewTrackableSource配合使用
	public void IBuildNewTarget()
	{
		//create新的target的名字,用于BuildNewTarget方法。上文create的是新的ImageTarget的名字，用于在Hierarchy里display
		//string targetName = string.Format(imageTargetTemplate.TrackableName + targetCounter);
		string targetName = string.Format(imageTargetTemplate.TrackableName + targetCounter);

		//This will start building a new target and report back to the event handlers as soon as a new TrackableSource is available.
		//create新object
		targetBuildingBehaviour.BuildNewTarget(targetName, imageTargetTemplate.GetSize().x);
	
		//builder.Build (targetName, 300);
	}

	public Toggle mul;
	void Update()
	{
		GlobalVariable.MulOrNot = mul.isOn;
	}

	//public Text countText;
	public Toggle SetSource, SetSink, SetVortex, SetUniform, SetEmitter;
	private int haveSource = 0,haveSink = 0,haveVortex = 0,haveUniform = 0,haveEmitter = 0;
	private Coroutine source_field;
	public GameObject Axis;
	public void OnNewTrackableSource(TrackableSource trackableSource)
	{
		targetCounter++;
		objectTracker.DeactivateDataSet(dataSet);
		ImageTargetBehaviour imageTargetCopy = Instantiate(imageTargetTemplate);
		//imageTargetCopy.gameObject.name = "new_Target" + targetCounter;

		dataSet.CreateTrackable(trackableSource, imageTargetCopy.gameObject);

		if (GlobalVariable.MulOrNot == false) 
		{
			if (SetSource.isOn == true)
			{//Set Source
				if (GlobalVariable.EmitterOnly == true) // Emitter Only
				{
					GameObject capsule;
					if (haveEmitter == 0) 
					{//the first SOURCE,then create SOURCE
						imageTargetCopy.gameObject.name = "Emitter_Field";// Name the Target( Target is also a GameObject!)

						capsule = GameObject.Instantiate(Axis);
						//capsule = GameObject.CreatePrimitive (PrimitiveType.Capsule);
						capsule.name = "eemitter";

						capsule.transform.parent = imageTargetCopy.transform;
						capsule.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
						capsule.transform.localPosition = new Vector3 (0, 0, 0); capsule.transform.Rotate (new Vector3 (90, 180, 180));
						//cylinder.transform.localPosition = imageTargetCopy.transform.position;
						//print (imageTargetCopy.transform.position.x+","+imageTargetCopy.transform.position.y+","+imageTargetCopy.transform.position.z);
						capsule.transform.localRotation = Quaternion.identity;
						//cylinder.transform.parent = imageTargetCopy.gameObject.transform;

						haveEmitter = 1;
					} 
					else if (haveEmitter == 1) 
					{//not the first SOURCE,then renew SOURCE
						GameObject ob = GameObject.Find ("Emitter_Field");
						ob.name = "Destroyed_Emitter_Field";// disconnect the old one
						imageTargetCopy.gameObject.name = "Emitter_Field";// Name the Target( Target is also a GameObject!)

						capsule = GameObject.Find ("eemitter");

						capsule.transform.parent = imageTargetCopy.transform;
						capsule.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
						capsule.transform.localPosition = new Vector3 (0, 0, 0); 
						capsule.transform.localRotation = Quaternion.identity; capsule.transform.Rotate (new Vector3 (90, 180, 180));
						//cylinder.transform.localPosition = imageTargetCopy.transform.position;
						//print (imageTargetCopy.transform.position.x+","+imageTargetCopy.transform.position.y+","+imageTargetCopy.transform.position.z);
					}
				}
				else if (GlobalVariable.EmitterOnly == false) // Source
				{
					GameObject cylinder;
					if (haveSource == 0) {//the first SOURCE,then create SOURCE
						imageTargetCopy.gameObject.name = "Source_Field";// Name the Target( Target is also a GameObject!)

						cylinder = GameObject.Instantiate(Axis);
						//cylinder = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
						cylinder.name = "ssource";

						cylinder.transform.parent = imageTargetCopy.transform;
						cylinder.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
						cylinder.transform.localPosition = new Vector3 (0, 0, 0);
						//cylinder.transform.localPosition = imageTargetCopy.transform.position;
						//print (imageTargetCopy.transform.position.x+","+imageTargetCopy.transform.position.y+","+imageTargetCopy.transform.position.z);
						cylinder.transform.localRotation = Quaternion.identity; cylinder.transform.Rotate (new Vector3 (90, 180, 180));
						//cylinder.transform.parent = imageTargetCopy.gameObject.transform;

						source_field = StartCoroutine (CreateSourceField ());//start coroutine
						haveSource = 1;
					} else if (haveSource == 1) {//not the first SOURCE,then renew SOURCE
						GameObject ob = GameObject.Find ("Source_Field");
						ob.name = "Destroyed_Source_Field";// disconnect the old one
						imageTargetCopy.gameObject.name = "Source_Field";// Name the Target( Target is also a GameObject!)

						cylinder = GameObject.Find ("ssource");

						cylinder.transform.parent = imageTargetCopy.transform;
						cylinder.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
						cylinder.transform.localPosition = new Vector3 (0, 0, 0); 
						cylinder.transform.localRotation = Quaternion.identity; cylinder.transform.Rotate (new Vector3 (90, 180, 180));
						//cylinder.transform.localPosition = imageTargetCopy.transform.position;
						//print (imageTargetCopy.transform.position.x+","+imageTargetCopy.transform.position.y+","+imageTargetCopy.transform.position.z);

						StopCoroutine (source_field);//end coroutine
						source_field = StartCoroutine (CreateSourceField ());//start a new coroutine
					}
				}
			}
			else if (SetSink.isOn == true) 
			{
				GameObject sphere;
				if (haveSink == 0)
				{ //the first SINK,then create SINK
					imageTargetCopy.gameObject.name = "Sink_Field";// Name the Target( Target is also a GameObject!)

					sphere = GameObject.Instantiate(Axis);
					//sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
					sphere.name = "ssink";

					sphere.transform.parent = imageTargetCopy.transform;
					sphere.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
					sphere.transform.localPosition = new Vector3 (0, 0, 0);
					sphere.transform.localRotation = Quaternion.identity; sphere.transform.Rotate (new Vector3 (90, 90, 180));

					haveSink = 1;
				} 
				else if (haveSink == 1)
				{ //not the first SINK,then renew SINK
					GameObject ob = GameObject.Find ("Sink_Field");
					ob.name = "Destroyed_Sink_Field";// disconnect the old one
					imageTargetCopy.gameObject.name = "Sink_Field";// Name the Target( Target is also a GameObject!)

					sphere = GameObject.Find ("ssink");

					sphere.transform.parent = imageTargetCopy.transform;
					sphere.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
					sphere.transform.localPosition = new Vector3 (0, 0, 0);
					sphere.transform.localRotation = Quaternion.identity; sphere.transform.Rotate (new Vector3 (90, 90, 180));
				}
			} 
			else if (SetVortex.isOn == true) 
			{
				GameObject cube;
				if (haveVortex == 0)
				{//the first VORTEX,then create VORTEX
					imageTargetCopy.gameObject.name = "Vortex_Field";// Name the Target( Target is also a GameObject!)

					cube = GameObject.Instantiate(Axis);
					//cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
					cube.name = "vvortex";

					cube.transform.parent = imageTargetCopy.transform;
					cube.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
					//cube.transform.localScale = new Vector3(0.00f,0.00f,0.00f);
					cube.transform.localPosition = new Vector3 (0, 0, 0);
					cube.transform.localRotation = Quaternion.identity; cube.transform.Rotate (new Vector3 (90, 90, 180));
					print ("vvortex");

					haveVortex = 1;
				} 
				else if (haveVortex == 1) 
				{//not the first VORTEX,then renew VORTEX
					GameObject ob = GameObject.Find ("Vortex_Field");
					ob.name = "Destroyed_Vortex_Field";// disconnect the old one
					imageTargetCopy.gameObject.name = "Vortex_Field";// Name the Target( Target is also a GameObject!)

					cube = GameObject.Find ("vvortex");
					cube.transform.parent = imageTargetCopy.transform;
					cube.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
					//cube.transform.localScale = new Vector3(0.00f,0.00f,0.00f);
					cube.transform.localPosition = new Vector3 (0, 0, 0);
					cube.transform.localRotation = Quaternion.identity; cube.transform.Rotate (new Vector3 (90, 90, 180));
					print ("vvortex");
				}
			} 
			else if (SetUniform.isOn == true)
			{
				GameObject cylinder;
				if (haveUniform == 0)
				{ //the first UNIFROM,then create UNIFORM
					imageTargetCopy.gameObject.name = "Uniform_Field";// Name the Target( Target is also a GameObject!)

					cylinder = GameObject.Instantiate(Axis);
					//cylinder = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
					cylinder.name = "uuniform";

					cylinder.transform.parent = imageTargetCopy.transform;
					cylinder.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
					//cylinder.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);
					cylinder.transform.localPosition = new Vector3 (0, 0, 0);
					cylinder.transform.localRotation = Quaternion.identity; cylinder.transform.Rotate (new Vector3 (90, 90, 180));
					//cylinder.transform.Rotate (0, 0, 90);

					haveUniform = 1;
				} 
				else if (haveUniform == 1) 
				{//not the first UNIFORM,then renew UNIFORM 
					GameObject ob = GameObject.Find ("Uniform_Field");
					ob.name = "Destroyed_Unfirom_Field";// disconnect the old one
					imageTargetCopy.gameObject.name = "Uniform_Field";// Name the Target( Target is also a GameObject!)

					cylinder = GameObject.Find ("uuniform");

					cylinder.transform.parent = imageTargetCopy.transform;
					cylinder.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
					//cylinder.transform.localScale = new Vector3 (0.00f, 0.00f, 0.00f);
					cylinder.transform.localPosition = new Vector3 (0, 0, 0);
					cylinder.transform.localRotation = Quaternion.identity; cylinder.transform.Rotate (new Vector3 (90, 90, 180));
					//cylinder.transform.Rotate (0, 0, 90);
				}
			}
			else if (SetEmitter.isOn == true) 
			{
				GameObject sphere;
				if (haveEmitter == 0)
				{ //the first SINK,then create SINK
					imageTargetCopy.gameObject.name = "Emitter_Field";// Name the Target( Target is also a GameObject!)

					sphere = GameObject.Instantiate(Axis);
					//sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
					sphere.name = "eemitter";

					sphere.transform.parent = imageTargetCopy.transform;
					sphere.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
					sphere.transform.localPosition = new Vector3 (0, 0, 0);
					sphere.transform.localRotation = Quaternion.identity; sphere.transform.Rotate (new Vector3 (90, 90, 180));

					haveEmitter = 1;
				} 
				else if (haveEmitter == 1)
				{ //not the first SINK,then renew SINK
					GameObject ob = GameObject.Find ("Emitter_Field");
					ob.name = "Destroyed_Emitter_Field";// disconnect the old one
					imageTargetCopy.gameObject.name = "Emitter_Field";// Name the Target( Target is also a GameObject!)

					sphere = GameObject.Find ("eemitter");

					sphere.transform.parent = imageTargetCopy.transform;
					sphere.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
					sphere.transform.localPosition = new Vector3 (0, 0, 0);
					sphere.transform.localRotation = Quaternion.identity; sphere.transform.Rotate (new Vector3 (90, 90, 180));
				}
			}
		} 
		else if (GlobalVariable.MulOrNot == true) 
		{
			if (SetSource.isOn == true) 
			{//Set Source
				GameObject cylinder;
				GlobalVariable.num_sources = GlobalVariable.num_sources + 1;
				imageTargetCopy.gameObject.name = "Source_Field" + GlobalVariable.num_sources;// Name the Target( Target is also a GameObject!)

				cylinder = GameObject.Instantiate(Axis);
				//cylinder = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
				cylinder.name = "ssource" + GlobalVariable.num_sources;

				cylinder.transform.parent = imageTargetCopy.transform;
				cylinder.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
				cylinder.transform.localPosition = new Vector3 (0, 0, 0);
				cylinder.transform.localRotation = Quaternion.identity; cylinder.transform.Rotate (new Vector3 (90, 90, 180));

				source_field = StartCoroutine (CreateSourceField ());//start coroutine
			}
			else if (SetSink.isOn == true) 
			{
				GameObject sphere;
				GlobalVariable.num_sinks = GlobalVariable.num_sinks + 1;
				imageTargetCopy.gameObject.name = "Sink_Field" + GlobalVariable.num_sinks;// Name the Target( Target is also a GameObject!)

				sphere = GameObject.Instantiate(Axis);
				//sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
				sphere.name = "ssink" + GlobalVariable.num_sinks;

				sphere.transform.parent = imageTargetCopy.transform;
				sphere.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
				sphere.transform.localPosition = new Vector3 (0, 0, 0);
				sphere.transform.localRotation = Quaternion.identity; sphere.transform.Rotate (new Vector3 (90, 90, 180));
			}
			else if (SetVortex.isOn == true) 
			{
				GameObject cube;
				GlobalVariable.num_vortexes = GlobalVariable.num_vortexes + 1;
				imageTargetCopy.gameObject.name = "Vortex_Field" + GlobalVariable.num_vortexes;// Name the Target( Target is also a GameObject!)

				cube = GameObject.Instantiate (Axis);
				//cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				cube.name = "vvortex" + GlobalVariable.num_vortexes;

				cube.transform.parent = imageTargetCopy.transform;
				cube.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
				cube.transform.localPosition = new Vector3 (0, 0, 0);
				cube.transform.localRotation = Quaternion.identity; cube.transform.Rotate (new Vector3 (90, 90, 180));
				//print ("vvortex");
			} 
			else if (SetUniform.isOn == true)
			{
				GameObject cylinder;
				GlobalVariable.num_uniforms = GlobalVariable.num_uniforms + 1;
				imageTargetCopy.gameObject.name = "Uniform_Field" + GlobalVariable.num_uniforms;// Name the Target( Target is also a GameObject!)

				cylinder = GameObject.Instantiate (Axis);
				//cylinder = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
				cylinder.name = "uuniform" + GlobalVariable.num_uniforms;

				cylinder.transform.parent = imageTargetCopy.transform;
				cylinder.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
				cylinder.transform.localPosition = new Vector3 (0, 0, 0);
				cylinder.transform.localRotation = Quaternion.identity; cylinder.transform.Rotate (new Vector3 (90, 90, 180));
				//cylinder.transform.Rotate (0, 0, 90);
			}
			else if (SetEmitter.isOn == true) 
			{
				GameObject sphere;
				GlobalVariable.num_emitters = GlobalVariable.num_emitters + 1;
				imageTargetCopy.gameObject.name = "Emitter_Field" + GlobalVariable.num_emitters;// Name the Target( Target is also a GameObject!)

				sphere = GameObject.Instantiate (Axis);
				//sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
				sphere.name = "eemitter" + GlobalVariable.num_emitters;

				sphere.transform.parent = imageTargetCopy.transform;
				sphere.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
				sphere.transform.localPosition = new Vector3 (0, 0, 0);
				sphere.transform.localRotation = Quaternion.identity; sphere.transform.Rotate (new Vector3 (90, 90, 180));
			}
		}
			
		objectTracker.ActivateDataSet(dataSet);
	}

	// SOURCE EDITION 2.0
	public Toggle TwoDimension,ThreeDimension;
	private GameObject T;
	public Toggle SelectFlakes,SelectHearts,SelectStars,SelectNinjas,SelectFlowers,SelectLetters;
	public GameObject Heart,Flake,Star,Ninja,Flower;
	public GameObject LetterA,LetterB,LetterC,LetterD;
	public GameObject LetterX,LetterY,LetterZ;
	private float offset1,offset2,offset3;
	private float sx,sy,sz;
	public Toggle SourceVertical;//Normal Feild or Vertial Field
	IEnumerator CreateSourceField () 
	{
		if (GlobalVariable.MulOrNot == false)
		{
			yield return new WaitForSeconds (0);
			while (true) 
			{
				GameObject source = GameObject.Find ("ssource");

				MeshRenderer mr = source.gameObject.GetComponent<MeshRenderer> ();
				//print(mr.isVisible);
				if (source != null) {
					if (mr.isVisible) {
						print ("FOUND");

						sx = source.transform.position.x;
						sy = source.transform.position.y;
						sz = source.transform.position.z;
						if (TwoDimension.isOn == true) {   //2D field
							if (SourceVertical.isOn == false) { //Normal Field
								offset1 = Random.Range (-0.01f, 0.01f);//x
								offset2 = Random.Range (-0.01f, 0.01f);//z
								offset3 = 0;//y
							} else if (SourceVertical.isOn == true) {//Vertical Field
								offset1 = Random.Range (-0.01f, 0.01f);//x
								offset2 = 0;//z
								offset3 = Random.Range (-0.01f, 0.01f);//y
							}
						} else if (ThreeDimension.isOn == true) { //3D field(no difference between Normal and Vertical Field)
							offset1 = Random.Range (-0.01f, 0.01f);
							offset2 = Random.Range (-0.01f, 0.01f);
							offset3 = Random.Range (-0.01f, 0.01f);
						}

						if (SelectFlakes.isOn == true)
							T = Flake;
						else if (SelectHearts.isOn == true)
							T = Heart;
						else if (SelectStars.isOn == true)
							T = Star;
						else if (SelectNinjas.isOn == true)
							T = Ninja;
						else if (SelectFlowers.isOn == true)
							T = Flower;
						else if (SelectLetters.isOn == true) {
							int letter = Random.Range (1, 8);
							switch (letter) {
							case 1:
								T = LetterA;
								break;
							case 2:
								T = LetterB;
								break;
							case 3:
								T = LetterC;
								break;
							case 4:
								T = LetterD;
								break;
							case 5:
								T = LetterX;
								break;
							case 6:
								T = LetterY;
								break;
							case 7:
								T = LetterZ;
								break;
							default:
								T = LetterA;
								break;
							}
						}
						//GameObject AngularCube = GameObject.Find ("AngularCube");//是否自旋
						if (/*AngularCube.transform.localScale.x */ GlobalVariable.AngularSpeed == 0) {
							GameObject tt = Instantiate (T, new Vector3 (sx + offset1, sy + offset3, sz + offset2), new Quaternion (0, 0, 0, 0));
							tt.transform.Rotate (new Vector3 (90, 0, 0));
						} else
							Instantiate (T, new Vector3 (sx + offset1, sy + offset3, sz + offset2), new Quaternion (0, 0, 0, 0));
					} else
						print ("LOST");
					yield return new WaitForSeconds (GlobalVariable.WaitTime);
				}
			}
		} 
		else if (GlobalVariable.MulOrNot == true) 
		{
			yield return new WaitForSeconds (0);
			while (true)
			{
				for (int i = 1; i <= GlobalVariable.num_sources; i++) {
					GameObject source = GameObject.Find ("ssource"+i);

					MeshRenderer mr = source.gameObject.GetComponent<MeshRenderer> ();
					//print(mr.isVisible);
					if (source != null) {
						if (mr.isVisible) {
							print ("FOUND");

							sx = source.transform.position.x;
							sy = source.transform.position.y;
							sz = source.transform.position.z;
							if (TwoDimension.isOn == true) {   //2D field
								if (SourceVertical.isOn == false) { //Normal Field
									offset1 = Random.Range (-0.01f, 0.01f);//x
									offset2 = Random.Range (-0.01f, 0.01f);//z
									offset3 = 0;//y
								} else if (SourceVertical.isOn == true) {//Vertical Field
									offset1 = Random.Range (-0.01f, 0.01f);//x
									offset2 = 0;//z
									offset3 = Random.Range (-0.01f, 0.01f);//y
								}
							} else if (ThreeDimension.isOn == true) { //3D field(no difference between Normal and Vertical Field)
								offset1 = Random.Range (-0.01f, 0.01f);
								offset2 = Random.Range (-0.01f, 0.01f);
								offset3 = Random.Range (-0.01f, 0.01f);
							}

							if (SelectFlakes.isOn == true)
								T = Flake;
							else if (SelectHearts.isOn == true)
								T = Heart;
							else if (SelectStars.isOn == true)
								T = Star;
							else if (SelectNinjas.isOn == true)
								T = Ninja;
							else if (SelectFlowers.isOn == true)
								T = Flower;
							else if (SelectLetters.isOn == true) {
								int letter = Random.Range (1, 8);
								switch (letter) {
								case 1:
									T = LetterA;
									break;
								case 2:
									T = LetterB;
									break;
								case 3:
									T = LetterC;
									break;
								case 4:
									T = LetterD;
									break;
								case 5:
									T = LetterX;
									break;
								case 6:
									T = LetterY;
									break;
								case 7:
									T = LetterZ;
									break;
								default:
									T = LetterA;
									break;
								}
							}
							//GameObject AngularCube = GameObject.Find ("AngularCube");//是否自旋
							if (/*AngularCube.transform.localScale.x */ GlobalVariable.AngularSpeed == 0) {
								GameObject tt = Instantiate (T, new Vector3 (sx + offset1, sy + offset3, sz + offset2), new Quaternion (0, 0, 0, 0));
								tt.transform.Rotate (new Vector3 (90, 0, 0));
							} 
							else
								Instantiate (T, new Vector3 (sx + offset1, sy + offset3, sz + offset2), new Quaternion (0, 0, 0, 0));
						} else
							print ("LOST");
						yield return new WaitForSeconds (GlobalVariable.WaitTime);
					}
				}
			}
		}
	}
////////////////////////////////////////////////////////////////////////////////////////////////////////
}