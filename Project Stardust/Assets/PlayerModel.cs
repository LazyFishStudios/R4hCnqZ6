using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarDust
{

  // Maybe in future this whole model while be moved to card model.
  public class PlayerModel
  {
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