using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandlerGUI : MonoBehaviour
{
  InputManager _ih;
  Text DebugText;
  void Start()
  {
    _ih = FindObjectOfType<InputManager>();
    DebugText = GetComponent<Text>();
  }

  private void Update()
  {
    DebugText.text = _ih.ToString();
  }
}