using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class CardViewsFactory
  {
    [Inject]
    BaseCardViewFactory cardViewFactory;

    [Inject]
    CardViewsFactoryController factoryViewsController;

    public CardView CreateView(Slot slot)
    {
      factoryViewsController.slot = slot.slot;
      factoryViewsController.CardToCreate = slot.card;
      return cardViewFactory.Create();
    }
  }

  public class CardViewsFactoryController
  {
    public Card CardToCreate;
    public Transform slot;
  }

  public class BaseCardViewFactory : Factory<CardView>
  {

  }

  public class CardViewFactoryInternal : IFactory<CardView>
  {
    [Inject]
    DiContainer _container;

    [Inject]
    CardViewsFactoryController viewController;

    [Inject]
    Transform CanvasTransform;

    public CardView Create()
    {
      switch (viewController.CardToCreate.Type)
      {
        case (CardType.UNIT):
          {
            UnitCardView newCardView = _container.InstantiatePrefabResourceForComponent<UnitCardView>("CardViews/UnitCardView", viewController.slot);
            newCardView.UpdateDisplayedValues(viewController.CardToCreate as UnitCard);
            return newCardView;
          }

        case (CardType.INSTANT):
          {
            InstantCardView newCardView = _container.InstantiatePrefabResourceForComponent<InstantCardView>("CardViews/InstantCardView", viewController.slot);
            newCardView.UpdateDisplayedValues(viewController.CardToCreate as InstantCard);
            return newCardView;
          }
      }
      Debug.LogError("Unknown cart type, can not create view: "+viewController.CardToCreate.Type);

      return null;
    }
  }
}
