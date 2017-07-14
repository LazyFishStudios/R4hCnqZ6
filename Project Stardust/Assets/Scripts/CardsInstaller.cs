using System.Collections.Generic;
using System;
using Zenject;
using UnityEngine;

namespace StarDust
{
  public class CardsInstaller : MonoInstaller<CardsInstaller>
  {
    // temporary hack for canvas transform reference:
    public Transform CanvasTransform;
    public Canvas c;

    public override void InstallBindings()
    {
      Container.BindFactory<Card, BaseCardFactory>().FromFactory<CardFactoryInternal>();
      Container.Bind<CardFactory>().AsSingle();
      Container.Bind<CardFactoryController>().AsSingle();

      //=== Card view bindings:

      // Ok, this works with [Inject]. I wonder if this is used when injected from factory???
      // First I will test this: _container.InstantiatePrefabResource in factory <== this is working!!
      // Container.Bind<UnitCardView>().FromComponentInNewPrefabResource("CardViews/UnitCardView").UnderTransformGroup("Canvas").AsTransient();
      // Container.Bind<InstantCardView>().FromComponentInNewPrefabResource("CardViews/InstantCardView").UnderTransformGroup("Canvas").AsTransient();
      Container.BindFactory<CardView, BaseCardViewFactory>().FromFactory<CardViewFactoryInternal>();
      Container.Bind<CardViewsFactory>().AsSingle();
      Container.Bind<CardViewsFactoryController>().AsSingle();
      Container.Bind<Transform>().FromInstance(CanvasTransform).WhenInjectedInto<CardViewFactoryInternal>();
      Container.Bind<Canvas>().FromInstance(c);

      Container.BindFactory<UnitView, UnitView.Factory>().FromComponentInNewPrefabResource("CardViews/UnitView").UnderTransformGroup("UnitHolder");
    }
  }
}