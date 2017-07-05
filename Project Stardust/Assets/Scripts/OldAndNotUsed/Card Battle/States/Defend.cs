using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardBattle
{
	[CreateAssetMenu(fileName = "Defend", menuName = "States/Defend", order = 1)]
	public class DefendState : TurnState
	{
		public override void BeginState() { m_stateTimer = 5.0f; }

		public override void UpdateState()
		{
			m_stateTimer -= Time.deltaTime;
			if (m_stateTimer < 0.0f)
				Component.FindObjectOfType<GameManager>().NextState();
		}

		private float m_stateTimer;
	}
}