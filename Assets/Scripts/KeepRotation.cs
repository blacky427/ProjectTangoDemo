using UnityEngine;
using System.Collections;

public class KeepRotation : MonoBehaviour {

	public float speed = 50f;

	private void Update () {
		this.transform.localEulerAngles = new Vector3(0f, Time.time * speed, 0f);
	}
}
