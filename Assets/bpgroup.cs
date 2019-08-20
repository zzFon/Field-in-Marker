using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEditor.Sprites ;
public class tucheng : MonoBehaviour {
	//public GameObject Gmenue;
	public GameObject btnObj ;
	public GameObject caidan;
	public Sprite   expan;
	public Sprite  back;
	Button btn;
	bool isshow=false ;
	// Use this for initialization
	void Start () {
		caidan.SetActive (isshow);
		btn = btnObj.GetComponent<Button>();
		btn.onClick.AddListener(delegate ()
			{
				isshow=!isshow;
				caidan.SetActive (isshow);
				if (isshow)
				{
					btn.GetComponent<Image>().sprite=expan ;
				}
				else {
					btn.GetComponent<Image>().sprite=back;
				}
			});
	}

	// Update is called once per frame
	void Update () {

	}
}