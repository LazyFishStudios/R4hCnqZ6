//using System.Collections.Generic;
//using UnityEngine;

//namespace PlanetSelection
//{
//    public class Camera : MonoBehaviour
//    {
//        public SelectedLevel selectedLevel;
//        public float scrollDistance;
//        public float smoothLockSpeed;

//        private Vector2 _startSwipePosition;
//        //private float _lastFullSwipe;
//        //private float _startSwipeTime;
//        //private bool _translating;
//        private bool _moving;
//        private float _destination;
//        private LockTrigger _currentLockTrigger;
//        private float _velocity;

//        public void Update()
//        {
//            if (Input.touchCount == 0)
//                return;

//            Touch touch = Input.GetTouch(0);

//            if (touch.phase == TouchPhase.Began)
//            {
//                _startSwipePosition = touch.position;
//                //_startSwipeTime = Time.time;
//                //_translating = false;
//                _moving = true;
//                selectedLevel.Hide();
//            }

//            if (touch.phase == TouchPhase.Moved)
//            {
//                var delta = touch.deltaPosition / touch.deltaTime;
//                float swipeVertical = delta.y;
//                float swipe = swipeVertical * scrollDistance * Time.deltaTime;

//                _destination = transform.position.z + swipe;
//                transform.position = new Vector3(transform.position.x, transform.position.y, _destination);
//            }

//            if (touch.phase == TouchPhase.Ended)
//            {
//                _moving = false;
//                /*_translating = true;

//                float swipeVertical = _startSwipePosition.y - touch.position.y;
//                float swipe = swipeVertical * 100 / Screen.height;
//                swipe = swipe / (Time.time - _startSwipeTime) * Time.deltaTime;
//                _lastFullSwipe = swipe;*/
//            }

//        }

//        private void OnTriggerEnter(Collider other)
//        {
//            var lockTrigger = other.GetComponent<LockTrigger>();
//            if (lockTrigger != null)
//            {
//                _currentLockTrigger = lockTrigger;
//            }
//        }

//        public void LateUpdate()
//        {
//            if (!_moving && _currentLockTrigger != null)
//            {
//                if (transform.position.z != _currentLockTrigger.lockPointForCamera.z)
//                {

//                    var newZ = Mathf.SmoothDamp(transform.position.z, _currentLockTrigger.lockPointForCamera.z, ref _velocity, smoothLockSpeed);
//                    Debug.Log(newZ);
//                    transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
//                }

//                if(Mathf.Abs(transform.position.z - _currentLockTrigger.lockPointForCamera.z) < 1f)
//                {
//                    selectedLevel.ShowPlanetUI(_currentLockTrigger);
//                }
//            }
//            /*if (_translating)
//            {
//                transform.position += new Vector3(0, 0, _lastFullSwipe);
//                _lastFullSwipe = _lastFullSwipe * 0.98f;
//                if (Mathf.Abs(_lastFullSwipe) < 0.1f)
//                    _translating = false;
//            }*/
//        }
//    }
//}