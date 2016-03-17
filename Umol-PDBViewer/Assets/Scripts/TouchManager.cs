using UnityEngine;
using System.Collections.Generic;

public class TouchManager : MonoBehaviour {

	public GameObject molecule;
	private int prevTouchCount;
	private int nowTouchCount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		nowTouchCount = Input.touchCount;

		if(prevTouchCount != 1 && nowTouchCount == 1) { OneTouchBegin(); }
		else if(prevTouchCount == 1 && nowTouchCount == 1) { OneTouching(); }
		else if(prevTouchCount == 1 && nowTouchCount != 1) { OneTouchEnd(); }
		else if(prevTouchCount != 2 && nowTouchCount == 2) { TwoTouchBegin(); }
		else if(prevTouchCount == 2 && nowTouchCount == 2) { TwoTouching(); }
		else if(prevTouchCount == 2 && nowTouchCount != 2) { TwoTouchEnd(); }

		prevTouchCount = nowTouchCount;
	}

	private void OneTouchBegin()
	{

	}

	private void OneTouching()
	{
		Touch touch = Input.GetTouch(0);
		molecule.transform.Rotate(new Vector3(touch.deltaPosition.y, touch.deltaPosition.x, 0));
	}

	private void OneTouchEnd()
	{

	}

	private void TwoTouchBegin()
	{

	}

	private void TwoTouching()
	{

	}

	private void TwoTouchEnd()
	{

	}
}
