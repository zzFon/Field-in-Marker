using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class TryAllMover : MonoBehaviour {

	//private Transform SourceTransform,SinkTransform,VortexTransform,UniformTransform;
	//public int source_enable = 0;public int sink_enable = 0;
	//public int vortex_enable = 0;public int uniform_enable = 0;

	private Rigidbody rb;
	private float original_scale_x,original_scale_y,original_scale_z;
	private float source_dis,sink_dis,vortex_dis,uniform_dis;

	private float lifeTime, bornTime, lifeSpan;
	private float speed;

	private float source_w = 0;
	private float sink_w = 0;
	private float vortex_w = 0;
	private float uniform_w = 0;
	private float w = 0;
	private float source_f, sink_f, vortex_f, uniform_f;
	public void ChangeSize()
	{
		//GameObject SizeCube =  GameObject.Find("SizeCube");//size
		//gameObject.transform.localScale = SizeCube.transform.localScale;
		//GameObject LifeCube =  GameObject.Find("LifeCube");//LifeSpan
		//lifeSpan = LifeCube.transform.localScale.x;
		lifeSpan = GlobalVariable.LifeSpan;
		/*GameObject SizeCube = GameObject.Find ("SizeCube");//size factor
		float tx = SizeCube.transform.localScale.x*original_scale_x;
		float ty = SizeCube.transform.localScale.y*original_scale_y;
		float tz = SizeCube.transform.localScale.z*original_scale_z;
		gameObject.transform.localScale = new Vector3 (tx, ty, tz);*/
		float tx = GlobalVariable.Size * original_scale_x;
		float ty = GlobalVariable.Size * original_scale_y;
		float tz = GlobalVariable.Size * original_scale_z;
		gameObject.transform.localScale = new Vector3 (tx,ty,tz);
		//GameObject SpeedCube =  GameObject.Find("SpeedCube");//speed
		//speed = SpeedCube.transform.localScale.x;
		/*GameObject SourceWCube =  GameObject.Find("SourceWCube");//sourceW 
		source_f = SourceWCube.transform.localScale.x;
		GameObject SinkWCube =  GameObject.Find("SinkWCube");//sinkW 
		sink_f = SinkWCube.transform.localScale.x;
		GameObject VortexWCube =  GameObject.Find("VortexWCube");//vortexW 
		vortex_f = VortexWCube.transform.localScale.x;
		GameObject UniformWCube =  GameObject.Find("UniformWCube");//sinkW 
		uniform_f = UniformWCube.transform.localScale.x;*/
	}

	void Start()
	{
		
		rb = GetComponent<Rigidbody> ();//rb.velocity = new Vector3(0.0f,0.0f,0.0f);
		original_scale_x = gameObject.transform.localScale.x;
		original_scale_y = gameObject.transform.localScale.y;
		original_scale_z = gameObject.transform.localScale.z;

		bornTime = Time.fixedTime;
		//GameObject LifeCube =  GameObject.Find("LifeCube");//LifeSpan
		//lifeSpan = LifeCube.transform.localScale.x;
		lifeSpan = GlobalVariable.LifeSpan;

		//GameObject SizeCube =  GameObject.Find("SizeCube");//size
		//gameObject.transform.localScale = SizeCube.transform.localScale;
		/*GameObject SizeCube = GameObject.Find ("SizeCube");//size factor
		float tx = SizeCube.transform.localScale.x*original_scale_x;
		float ty = SizeCube.transform.localScale.y*original_scale_y;
		float tz = SizeCube.transform.localScale.z*original_scale_z;
		gameObject.transform.localScale = new Vector3 (tx, ty, tz);*/
		float tx = GlobalVariable.Size * original_scale_x;
		float ty = GlobalVariable.Size * original_scale_y;
		float tz = GlobalVariable.Size * original_scale_z;
		gameObject.transform.localScale = new Vector3 (tx,ty,tz);
		//GameObject SpeedCube =  GameObject.Find("SpeedCube");//speed
		//speed = SpeedCube.transform.localScale.x;
		/*GameObject SourceWCube =  GameObject.Find("SourceWCube");//sourceW 
		source_f = SourceWCube.transform.localScale.x;
		GameObject SinkWCube =  GameObject.Find("SinkWCube");//sinkW 
		sink_f = SinkWCube.transform.localScale.x;
		GameObject VortexWCube =  GameObject.Find("VortexWCube");//vortexW 
		vortex_f = VortexWCube.transform.localScale.x;
		GameObject UniformWCube =  GameObject.Find("UniformWCube");//sinkW 
		uniform_f = UniformWCube.transform.localScale.x;*/
	}

	void Update()
	{
		lifeTime = Time.fixedTime;
		if (lifeTime - bornTime >= lifeSpan)
			Destroy (gameObject);

		rb.velocity = new Vector3(0.0f,0.0f,0.0f);
		//Vector3 field = new Vector3(0.0f,0.0f,0.0f);
		source_w = 0;
		sink_w = 0;
		vortex_w = 0;
		uniform_w = 0;
		w = 0;
		GameObject source = GameObject.Find("ssource");
		if (source != null) 
		{
			MeshRenderer mrsource = source.GetComponent<MeshRenderer> ();
			if (mrsource.isVisible) 
			{
				print("Source FOUND");
				source_dis = Vector3.Distance (rb.position, source.transform.position);
				source_w = 1.0f / source_dis;

				Vector3 vecc = source_w * SourceVec (source);
				//rb.velocity = rb.velocity + vecc * source_f;
				rb.velocity = rb.velocity + vecc * GlobalVariable.SourceW;
				//Vector3 acc = source_w * SourceVec (source);
				//w = w + source_w * source_f;
				w = w + source_w * GlobalVariable.SourceW;
			}
		}
		GameObject sink = GameObject.Find ("ssink");
		if (sink != null) 
		{
			MeshRenderer mrsink = sink.GetComponent<MeshRenderer> ();
			if (mrsink.isVisible) 
			{
				print("Sink FOUND");
				sink_dis = Vector3.Distance (rb.position, sink.transform.position);
				sink_w = 2.0f / sink_dis;
				//sink_w = (5.0f / sink_dis);

				if(sink_dis <= 0.008)
					Destroy (gameObject);

				Vector3 vecc = sink_w * SinkVec (sink);
				//rb.velocity = rb.velocity + vecc * sink_f;
				rb.velocity = rb.velocity + vecc * GlobalVariable.SinkW;
				//Vector3 acc = sink_w * SinkVec (sink);
				//w = w + sink_w * sink_f;
				w = w + sink_w * GlobalVariable.SinkW;
			}
		}
		GameObject vortex = GameObject.Find("vvortex");
		if (vortex != null) 
		{
			MeshRenderer mrvortex = vortex.GetComponent<MeshRenderer> ();
			if (mrvortex.isVisible)
			{
				print("Vortex FOUND");
				vortex_dis = Vector3.Distance (rb.position, vortex.transform.position);
				vortex_w = 3.0f / vortex_dis;
				//vortex_w = 10.0f / vortex_dis;

				Vector3 vecc = vortex_w * VortexVec (vortex);
				//rb.velocity = rb.velocity + vecc * vortex_f;
				rb.velocity = rb.velocity + vecc * GlobalVariable.VortexW;
				//Vector3 acc = vortex_w * VortexVec (vortex);
				//w = w + vortex_w * vortex_f;
				w = w + vortex_w * GlobalVariable.VortexW;
			}
	    }
		GameObject uniform = GameObject.Find ("uuniform");
		if (uniform != null) 
		{
			MeshRenderer mruniform = uniform.GetComponent<MeshRenderer> ();
			if (mruniform.isVisible) 
			{
				print("Uniform FOUND");
				uniform_dis = Vector3.Distance (rb.position, uniform.transform.position);
				uniform_w = 3.0f / uniform_dis;

				Vector3 vecc = uniform_w * UniformVec (uniform);
				//rb.velocity = rb.velocity + vecc * uniform_f;
				rb.velocity = rb.velocity + vecc * GlobalVariable.UniformW;
				//Vector3 acc = uniform_w * UniformVec (uniform);
				//w = w + uniform_w * uniform_f;
				w = w + uniform_w * GlobalVariable.UniformW;
			}
		}
		/**/
		//speed = 0.1f;
		if (w != 0)
		{
			rb.velocity = (rb.velocity / w) * GlobalVariable.Speed;
			//field = (field/w)*speed;
			//rb.AddForce(field);
			//print ("ax = "+field.x+",ay = "+field.y+",az = "+field.z);
			//print(rb.velocity.x+","+rb.velocity.y+","+rb.velocity.z);
			//ROTATE
			/*GameObject AngularCube =  GameObject.Find("AngularCube");
			float AngularSpeed = 1000*AngularCube.transform.localScale.x;*/
			transform.Rotate (new Vector3 (rb.velocity.x,rb.velocity.y,rb.velocity.z) * 1000 *GlobalVariable.AngularSpeed *Time.deltaTime);
		}
	}
	
	Vector3 SourceVec(GameObject source)//3D
	{
		Vector3 source_vec = rb.position-source.transform.position;
		source_vec = source_vec / Vector3.Magnitude (source_vec);
		return source_vec;
	}

	Vector3 SinkVec(GameObject sink)//3D
	{
		Vector3 sink_vec = rb.position-sink.transform.position;
		sink_vec = -1 * sink_vec / Vector3.Magnitude (sink_vec);
		return sink_vec;
	}

	Vector3 VortexVec(GameObject vortex)//3D
	{
		//GameObject cube = GameObject.Find ("VortexVerticalCube");
		Vector3 n = new Vector3(0,1,0);
		if(/*cube.transform.localScale.x == 1.0f*/GlobalVariable.VortexDirection == 1)
		{
			//clock wise
			n = new Vector3(0,1,0);
		}
		else if(/*cube.transform.localScale.x == 2.0f*/GlobalVariable.VortexDirection == 2)
		{
			//n = new Vector3(0,0,-1);
			//anti clock wise
			n = new Vector3(0,-1,0);
		}
		Vector3 o = vortex.transform.position;
		Vector3 p = rb.position;

		Vector3 numerator = p-o-(Vector3.Dot(n,(p-o)))*n;
		Vector3 vortex_vec = numerator / Vector3.Magnitude (numerator);
		vortex_vec = Vector3.Cross (vortex_vec, n);

		return vortex_vec;
	}

	Vector3 UniformVec(GameObject uniform)//3D
	{
		GameObject unf = GameObject.Find ("Uniform_Field");
	
		// calculate the direction vector of the UNIFORM field using the cylinder's rotation
		/*float angleX = unf.transform.rotation.eulerAngles.x;
		float angleY = unf.transform.rotation.eulerAngles.y;
		float angleZ = unf.transform.rotation.eulerAngles.z;*/
		Vector3 ang = GetInspectorRotationValueMethod (unf.transform);
		float tx = Mathf.Cos (ang.y/180*Mathf.PI);
		float ty = 0; // only considered 2D field
		float tz = -1 * Mathf.Sin (ang.y/180*Mathf.PI);
		Vector3 uniform_vec = new Vector3(tx,ty,tz);

		// Normalize the direction vector
		uniform_vec = uniform_vec / Vector3.Magnitude (uniform_vec);

		//print (ang.x+","+ang.y+","+ang.z);
		//print (uniform_vec.x+","+uniform_vec.y+","+uniform_vec.z);

		return uniform_vec;
	}

	//get rotation on Inspector
	public Vector3 GetInspectorRotationValueMethod(Transform transform)
	{
		System.Type transformType = transform.GetType();
		PropertyInfo m_propertyInfo_rotationOrder = transformType.GetProperty("rotationOrder", BindingFlags.Instance | BindingFlags.NonPublic);
		object m_OldRotationOrder = m_propertyInfo_rotationOrder.GetValue(transform, null);
		MethodInfo m_methodInfo_GetLocalEulerAngles = transformType.GetMethod("GetLocalEulerAngles", BindingFlags.Instance | BindingFlags.NonPublic);
		object value = m_methodInfo_GetLocalEulerAngles.Invoke(transform, new object[] { m_OldRotationOrder });
		string temp = value.ToString();
		//
		temp = temp.Remove(0, 1);
		temp = temp.Remove(temp.Length - 1, 1);
		//
		string[] tempVector3;
		tempVector3 = temp.Split(',');
		//
		Vector3 vector3 = new Vector3(float.Parse(tempVector3[0]), float.Parse(tempVector3[1]), float.Parse(tempVector3[2]));
		return vector3;
	}
}
