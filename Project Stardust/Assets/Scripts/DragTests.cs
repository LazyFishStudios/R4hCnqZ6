using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTests : MonoBehaviour 
{
  InputManager inputManager;
  void Start()
  {
    inputManager = FindObjectOfType<InputManager>();
    inputManager.OnLongHold += _im_OnLongHold;
    inputManager.OnDrag += _im_OnDrag;
  }

  private void _im_OnDrag(GameObject target, Vector3 newWorldPosition)
  {
    if (ReferenceEquals(target, gameObject))
    {
      transform.position = newWorldPosition;
    }
  }

  private void _im_OnLongHold(GameObject obj)
  {
    if(ReferenceEquals(obj, gameObject))
    {
      GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
  }
}