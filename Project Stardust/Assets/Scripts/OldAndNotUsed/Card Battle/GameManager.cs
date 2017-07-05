using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardBattle
{
	// Manager class for core game logic - split logic into classes as appropriate, this is just a conventient place to store/access them
	// Should be usable for single/multiplayer, and for both attacking and defending
	public class GameManager : MonoBehaviour
	{
		// Use this for initialization
		void Start()
		{
			m_currentState = m_states[0];
		}

		// Update is called once per frame
		void Update()
		{
			m_currentState.UpdateState();
		}

		public void EndTurnPressed()
		{
			m_currentState.EndTurnPressed();
		}

		public void NextState()
		{
			m_currentState.EndState();
			var nextStateIndex = m_states.LastIndexOf(m_currentState) + 1;
			if (nextStateIndex < m_states.Count)
			{
				m_currentState = m_states[nextStateIndex];
			}
			else
			{
				m_currentRound++;
				GameObject.Find("Canvas/Turn Counter").GetComponent<UnityEngine.UI.Text>().text = "Round\n" + m_currentRound;
				m_currentState = m_states[0];
			}
			m_currentState.BeginState();
		}

		public List<TurnState> m_states = new List<TurnState>();
		public TurnState m_currentState;
		private int m_currentRound = 1;
	}
}