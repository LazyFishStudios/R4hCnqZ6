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
      factoryViewsController.ViewToCreate = slot.card.Type;
      return cardViewFactory.Create();
    }
  }

  public class CardViewsFactoryController
  {
    public CardType ViewToCreate;
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
      CardView newCardView = null;
      switch (viewController.ViewToCreate)
      {
        case (CardType.UNIT):
          {
            newCardView = _container.InstantiatePrefabResourceForComponent<UnitCardView>("CardViews/UnitCardView", viewController.slot);
            break;
          }

        case (CardType.INSTANT):
          {
            newCardView = _container.InstantiatePrefabResourceForComponent<InstantCardView>("CardViews/InstantCardView", viewController.slot);
            break;
          }
      }

      return newCardView;
    }
  }
}
