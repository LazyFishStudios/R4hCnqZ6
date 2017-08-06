using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class EntryPoint : MonoBehaviour
  {
    [Inject]
    DefendingPlayer _defendingPlayer;

    void Start()
    {

    }
  }
}