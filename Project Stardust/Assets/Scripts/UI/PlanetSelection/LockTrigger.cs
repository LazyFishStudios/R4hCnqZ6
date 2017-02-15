using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetSelection
{
    public class LockTrigger : MonoBehaviour
    {
        public PlanetSelectionSide planetSide;
        public Vector3 lockPointForCamera;

        public enum PlanetSelectionSide
        {
            Right,
            Left
        }
    }
}