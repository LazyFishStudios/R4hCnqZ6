using System.Collections.Generic;
using System;
using Zenject;

namespace StarDust
{
  public class CardsInstaller : MonoInstaller<CardsInstaller>
  {
    int i = 0;
    public override void InstallBindings()
    { 
      Container.BindFactory<Card, BaseCardFactory>().FromFactory<CardFactoryInternal>();
      Container.Bind<CardFactory>().AsSingle();
      Container.Bind<CardFactoryController>().AsSingle();
    }
  }
}