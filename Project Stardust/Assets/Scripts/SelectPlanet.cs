using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectPlanet : MonoBehaviour
{
  enum SwipeState
  {
    SWIPE_IN_PROGRESS,
    WAITING_FOR_SWIPE
  }

  Camera _mainCamera;
  InputHandler _inputHandler;
  Vector3 _cameraStartPosition;
  Vector3 _cameraEndPosition;
  Quaternion _cameraStartRotation;
  Quaternion _cameraEndRotation;
  float _swipeProgress;

  SwipeState _state;

  [SerializeField]
  Transform[] _lookAtplanetPositions;

  int _selectedPlanetIndex = 0;
  public float swipDuration = 1;
  [SerializeField]
  AnimationCurve _cameraSpeed;
  
  [SerializeField]
  VerticalLayoutGroup _vlg;

  void Start()
  {
    _mainCamera = Camera.main;
    Debug.Log(name);
    _inputHandler = FindObjectOfType<InputHandler>();
  
    _mainCamera.transform.position = _lookAtplanetPositions[_selectedPlanetIndex].position;
    _state = SwipeState.WAITING_FOR_SWIPE;
    AddEventListeners();
  }


  private void Update()
  {
    if (_state == SwipeState.SWIPE_IN_PROGRESS)
      UpdateCameraPosition();
  }

  private void OnDestroy()
  {
    RemoveEventListeners();
  }
  void AddEventListeners()
  {
    _inputHandler.OnSwipeUp += _inputHandler_OnSwipeUp;
    _inputHandler.OnSwipeDown += _inputHandler_OnSwipeDown;
  }

  void RemoveEventListeners()
  {
    _inputHandler.OnSwipeUp += _inputHandler_OnSwipeUp;
    _inputHandler.OnSwipeDown += _inputHandler_OnSwipeDown;
  }

  private void _inputHandler_OnSwipeDown() // Go to next planet
  {
    if (_state == SwipeState.SWIPE_IN_PROGRESS) return;
    if (_selectedPlanetIndex == _lookAtplanetPositions.Length - 1) return;
    _cameraStartPosition = _lookAtplanetPositions[_selectedPlanetIndex].position;
    _cameraStartRotation = _lookAtplanetPositions[_selectedPlanetIndex].rotation;
    _selectedPlanetIndex++;

    _cameraEndPosition = _lookAtplanetPositions[_selectedPlanetIndex].position;
    _cameraEndRotation = _lookAtplanetPositions[_selectedPlanetIndex].rotation;
    _swipeProgress = 0;
    _state = SwipeState.SWIPE_IN_PROGRESS;
  }


  private void _inputHandler_OnSwipeUp() // Go to prev planet
  {
    if (_state == SwipeState.SWIPE_IN_PROGRESS) return;
    if (_selectedPlanetIndex == 0) return;
    _cameraStartPosition = _lookAtplanetPositions[_selectedPlanetIndex].position;
    _cameraStartRotation = _lookAtplanetPositions[_selectedPlanetIndex].rotation;
    _selectedPlanetIndex--;
    _cameraEndPosition = _lookAtplanetPositions[_selectedPlanetIndex].position;
    _cameraEndRotation = _lookAtplanetPositions[_selectedPlanetIndex].rotation;
    _swipeProgress = 0;
    _state = SwipeState.SWIPE_IN_PROGRESS;
  }

  private void UpdateCameraPosition()
  {
    _swipeProgress += Time.deltaTime / swipDuration;
    
    _mainCamera.transform.position = Vector3.Lerp(_cameraStartPosition, _cameraEndPosition, _cameraSpeed.Evaluate(_swipeProgress));
    _mainCamera.transform.rotation = Quaternion.Lerp(_cameraStartRotation, _cameraEndRotation, _cameraSpeed.Evaluate(_swipeProgress));
     //  Debug.Log("progress: " + _swipeProgress + " start: " + _cameraStartPosition + " end: " + _cameraEndPosition + " campos: " + newCamPos);
     
   if (_swipeProgress >= 1f)
    {
      _state = SwipeState.WAITING_FOR_SWIPE;
      _vlg.childAlignment = (_selectedPlanetIndex % 2 != 0) ? TextAnchor.MiddleLeft : TextAnchor.MiddleRight;
    }
  }

  // button function:
  public void OnBattleButtonPressed()
  {
    Debug.Log("selected planet index: " + _selectedPlanetIndex);
  }
}