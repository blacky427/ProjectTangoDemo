using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Tango;

public class ARContrller : MonoBehaviour {

	public TangoPointCloud TangoPC;
	public Camera ARCamera;
	public GameObject Marker;
	public GameObject ARObject;
	public Button PlaceBtn;

	private void Awake(){
		ARObject.SetActive(false);
		PlaceBtn.onClick.AddListener(() => OnPlaceBtnClick());
	}

	public void OnPlaceBtnClick(){
		ARObject.SetActive(true);
		ARObject.transform.position = Marker.transform.position;
		ARObject.transform.eulerAngles = Marker.transform.eulerAngles;
	}

	private void Update () {
		SetMarker();
	}

	private void SetMarker(){
		Vector3 centerPos = Vector3.zero;
		Plane centerPlane = new Plane();
		Vector2 centerScreenPos = new Vector2(Screen.width / 2f, Screen.height / 2f);
		if(TangoPC.FindPlane(ARCamera, centerScreenPos, out centerPos, out centerPlane)){
			Marker.transform.position = centerPos;
			Marker.transform.up =  centerPlane.normal;
		}
	}

}
