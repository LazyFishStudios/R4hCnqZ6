using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class DefendingPlayer : PlayerModel
  {
    public DefendingPlayer()
    {
      Debug.Log("DefendingPlayer ctor()");
    }

    private int _lives = 30;
    public int Lives
    {
      get
      {
        return _lives;
      }
      set
      {
        _lives = value;
        Debug.Log("Lives: " + _lives);
      }
    }
  }

}