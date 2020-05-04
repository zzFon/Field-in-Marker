using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour {

	public GameObject clone;


	    public float speed = 5;
	    public float jumpSpeed = 10f;
	    public float luodi = 15;
	    private Vector3 movePos = Vector3.zero;
	    public CharacterController controller;
	    private LineRenderer line;
	    Vector3[] path;
	    private float time = 0;
	    List<Vector3> pos=new List<Vector3> ();
	    void Awake()
	    {
		              path = pos.ToArray();//初始化
		              line = clone.GetComponent<LineRenderer>();//获得该物体上的LineRender组件
		              line.SetColors(Color.blue, Color.red);//设置颜色
		              line.SetWidth(0.2f, 0.1f);//设置宽度
		    }
	    void Update()
	    {
		        time += Time.deltaTime;
		        if (time>0.1)//每0.1秒绘制一次
			        {
			            time = 0;
			            pos.Add(transform.position);//添加当前坐标进链表
			            path = pos.ToArray();//转成数组
			        }
		        if (controller.isGrounded)//判断人物是否落地
			        {
			            movePos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			            movePos = transform.TransformDirection(movePos);
			            movePos *= speed;
			            if (Input.GetButton("Jump")) { 
				                movePos.y = jumpSpeed;
				              }
			        }
		        movePos.y -= luodi * Time.deltaTime;
		        controller.Move(movePos * Time.deltaTime);
		        if (path.Length!=0)//有数据时候再绘制
			        {
			            line.SetVertexCount(path.Length);//设置顶点数      
			            line.SetPositions(path);//设置顶点位置
			        }
		            
		     
		    }
}
