using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour 
{
	void Start () 
	{
    float width = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
    float size = 2f;
    transform.localScale = Vector3.one * (width / size);
  }
}