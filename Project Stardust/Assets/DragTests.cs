using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTests : MonoBehaviour
{
  Camera cam;
  Vector3 offset;
  Vector3 hitPosition;
  public GameObject probe;
  bool isDragging;
  public Transform hitObject;
  float dist;

  public void Mors()
  {
    Debug.Log("Mors");
  }

  private void Start()
  {
    cam = Camera.main;
  }



  private void Update()
  {
    Ray r = cam.ScreenPointToRay(Input.mousePosition);

    RaycastHit rh;
    bool hitSuccess = Physics.Raycast(r, out rh);
    if (hitSuccess)
    {
      hitObject = rh.transform;
      probe.transform.position = rh.point;
    }

    if (hitSuccess && Input.GetMouseButtonDown(0))
    {
      Debug.Log("Drag start");
      isDragging = true;
      offset = hitObject.transform.position - rh.point;
      // Get distance to camera:
      Vector3 h = rh.point - cam.transform.position;
      dist = Vector3.Dot(h, cam.transform.forward);
    }

    if (Input.GetMouseButtonUp(0))
    {
      Debug.Log("Drag end");
      isDragging = false;
    }
    Debug.DrawRay(r.origin, r.direction * 100, Color.red);
    Debug.DrawLine(rh.point, rh.point + offset, Color.yellow);

    if(isDragging)
    {
      Debug.Log("drag...");
      Vector3 p = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist));
      hitObject.transform.position = p + offset;
    }
  }
}