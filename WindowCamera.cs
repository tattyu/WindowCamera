using UnityEngine;
using System.Collections;

// 任意の領域をウインドウでくり抜くカメラ.
// 別の領域をそのウインドウ内に描画するわけではない.
public class WindowCamera : MonoBehaviour {

	public float baseHResolution = 1136.0f;

	public Vector2 pos = new Vector2(0,0);
	public float width = 100.0f;
	public float height = 100.0f;

	void Awake(){
		Camera cam = GetComponent<Camera>();

		cam.orthographicSize = height * 0.5f;

		Vector3 tr = transform.localPosition;
		tr.y = -height * 0.5f + pos.y;
		tr.x = width * 0.5f + pos.x;
		transform.localPosition = tr;

		float scl = baseHResolution/Screen.height;

		float baseWResolution = Screen.width * scl; 
		float w = width / baseWResolution;
		float h = height / baseHResolution;
		Vector2 vpos = pos;
		vpos.x = ((baseWResolution*0.5f) + pos.x) / baseWResolution;
		vpos.y = (baseHResolution - ((baseHResolution*0.5f) - pos.y + height)) / baseHResolution;
		cam.rect = new Rect( vpos.x, vpos.y, w, h );

	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
