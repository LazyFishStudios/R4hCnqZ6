using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
  Camera mainCamera;
  public event Action<GameObject, Vector2> OnSelectedObject;
  public event Action<GameObject, Vector2> OnDropObject;
  public event Action<GameObject, Vector3> OnDragStart;
  public event Action<GameObject, Vector3> OnDrag;
  public event Action<GameObject> OnDragEnd;
  public event Action<GameObject> OnLongHold;

  private GameObject CurrentSelectedObject = null;

  private float DragThreshold = 0.02f;
  private float LongHoldThreshold = 1f;
  private float HoldTime = 0;
  private bool isLongHold = false;
  private Vector2 _potentialDragStartPosition;
  private Vector2 _currentDragPosition;
  private Vector2 _dragEndPosition;

  private float distanceToCamera;
  bool mouseButtonHold;
  bool isDraging;

  float Distance;
  private void Start()
  {
    mainCamera = Camera.main;
  }

  void Update()
  {
    Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    bool hitSuccess = Physics.Raycast(cameraRay, out hit);
    Debug.DrawRay(cameraRay.origin, cameraRay.direction * 100, Color.red);

    if (Input.GetMouseButtonDown(0))
    {
      mouseButtonHold = true;

      if (hitSuccess)
      {
        CurrentSelectedObject = hit.transform.gameObject;
        Debug.Log("Hit: " + hit.transform.name);
        Vector3 h = hit.point - mainCamera.transform.position;
        distanceToCamera = Vector3.Dot(h, mainCamera.transform.forward);
        _potentialDragStartPosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        HoldTime = 0;
        Debug.Log("s: " + _potentialDragStartPosition);
        if (OnSelectedObject != null)
        {
          OnSelectedObject(hit.transform.gameObject, Input.mousePosition);
        }
      }
    }


    if (Input.GetMouseButtonUp(0))
    {
      if (OnDropObject != null)
        OnDropObject(CurrentSelectedObject, Input.mousePosition);
      CurrentSelectedObject = null;
      mouseButtonHold = false;
      if (isDraging)
      {
        isDraging = false;
        if (OnDragEnd != null) OnDragEnd(CurrentSelectedObject);
      }
      isLongHold = false;
      HoldTime = 0;
    }

    if (mouseButtonHold && CurrentSelectedObject != null)
    {
      _currentDragPosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);
      HoldTime += Time.deltaTime;
    //  Debug.Log("c: " + _currentDragPosition);
      Distance = Vector2.Distance(_potentialDragStartPosition, _currentDragPosition);

      if (Distance > DragThreshold && isLongHold == false && isDraging == false)
      {
        isDraging = true;
        if (OnDragStart != null)
        {
          Vector3 p = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCamera));
          OnDragStart(CurrentSelectedObject, p);
        }
      }

      if(HoldTime > LongHoldThreshold && isDraging == false && isLongHold == false)
      {
        isLongHold = true;
        if (OnLongHold != null) OnLongHold(CurrentSelectedObject);
      }
    }

    if(isDraging)
    {
      if (OnDrag != null)
      {
        Vector3 p = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCamera));
        OnDrag(CurrentSelectedObject, p);
      }
    }
  }

  public override string ToString()
  {
    string n = (CurrentSelectedObject == null)? "null": CurrentSelectedObject.name;
    
    return "IsMouseDown: " + mouseButtonHold + " IsDraging: " + isDraging + " LastHitName: " + n+" LongHold: "+isLongHold;
  }
}