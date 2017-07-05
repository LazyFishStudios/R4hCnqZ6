using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardBattle
{
	public class TurnState : ScriptableObject
	{

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		public virtual void BeginState() { }
		public virtual void UpdateState() { }
		public virtual void EndState() { }

		public virtual void EndTurnPressed() { }
	}
}