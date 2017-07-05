using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class drag : MonoBehaviour, IDragHandler, IEndDragHandler
{
  Canvas c;
  RectTransform rt;
  Camera mainCamera;
  void Start()
  {
    rt = GetComponent<RectTransform>();
    mainCamera = Camera.main;
    c = FindObjectOfType<Canvas>();
  }
  public void OnDrag(PointerEventData eventData)
  {
    rt.anchoredPosition += eventData.delta*1/c.scaleFactor;
  }

  public void OnEndDrag(PointerEventData eventData)
  {
    Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    bool hitSuccess = Physics.Raycast(cameraRay, out hit);
    if(hitSuccess)
    {
      Debug.Log(hit.transform.gameObject);
      hit.transform.rotation = UnityEngine.Random.rotation;
      Destroy(gameObject);
    }
    else
    {
      rt.offsetMin = rt.offsetMax = Vector2.zero;
    }
    

  }

}
