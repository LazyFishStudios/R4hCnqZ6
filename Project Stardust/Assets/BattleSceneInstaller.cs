using UnityEngine;
using Zenject;

namespace StarDust
{
  public class BattleSceneInstaller : MonoInstaller<BattleSceneInstaller>
  {
    public override void InstallBindings()
    {
      Container.Bind<CardsModel>().AsSingle();
    }
  }
}