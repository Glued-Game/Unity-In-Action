using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public enum RotationAxes{
		MouseXandY = 0,
		MouseX = 1,
		MouseY = 2
	}
	public float speedXY = 5f; // mouse movement speed horizontal and vertical
	public RotationAxes axes = RotationAxes.MouseXandY;
	private float minVerticalY = -45f;
	private float maxVerticalY = 45f;
	private float _rotationX = 0; // declared for vertical angle

	// Update is called once per frame
	void Update () {
		if(axes == RotationAxes.MouseX){
			// horizontal rotation here
			transform.Rotate (0, Input.GetAxis("Mouse X")*speedXY, 0f);
			print ("move Horizontally");
		}
		else if(axes == RotationAxes.MouseY){
			// vertical rotation here
			_rotationX -= Input.GetAxis ("Mouse Y") * speedXY;
			_rotationX = Mathf.Clamp (_rotationX, minVerticalY, maxVerticalY);

			float _rotationY = transform.localEulerAngles.y;
			transform.localEulerAngles = new Vector3 (_rotationX, _rotationY, 0);
		}
		else{
			// both rhorizontal and vertical rotaion here
		}
	}
}
