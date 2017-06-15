using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputHandler : MonoBehaviour
{
  public event Action OnSwipeUp;
  public event Action OnSwipeDown;

  Vector2 _dragStartPosition;
  Vector2 _dragEndPosition;
  Camera _mainCam;

  private void Start()
  {
    _mainCam = Camera.main;
  }

  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
   //   Debug.Log("button pressed");
      _dragStartPosition = _mainCam.ScreenToViewportPoint(Input.mousePosition);
    }

    if (Input.GetMouseButtonUp(0))
    {
  //    Debug.Log("button released");
      _dragEndPosition = _mainCam.ScreenToViewportPoint(Input.mousePosition);
      CheckForSwipe();
    }
  }

  private void CheckForSwipe()
  {
  //  Debug.Log("button released");
  //  Debug.Log("s: " + _dragStartPosition + " e: " + _dragEndPosition + " diff : ");
    float xdiff = _dragEndPosition.x - _dragStartPosition.x;
    float ydiff = _dragEndPosition.y - _dragStartPosition.y;

    // if horizontal swipe is bigger than vertical than it is not a swipe:
    if (Mathf.Abs(xdiff) > Mathf.Abs(ydiff)) return;
    if (ydiff > 0.1f)
    {
      Debug.Log("Swipe Up()");
      if (OnSwipeUp != null) OnSwipeUp();
    }
    if (ydiff < -0.1f)
    {
      Debug.Log("Swipe Down()");
      if (OnSwipeDown != null) OnSwipeDown();
    }
  }
}
