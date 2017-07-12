using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class CardsPanelView : MonoBehaviour
  {
    [Inject]
    CardsModel _cardsModel;

    [Inject]
    CardFactory cardFactory;

    void Start()
    {
      UnitCard c = cardFactory.CreateCardByName<UnitCard>(CardListNames.BattleCruiser);
      c.OnCardPlayed();
      Debug.Log(c.Description);

      Card i1 = cardFactory.CreateRancomCard();
      Debug.Log(i1.Description);

    }
  }
}