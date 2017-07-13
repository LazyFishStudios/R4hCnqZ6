using Zenject;

namespace StarDust
{
  public class BattleSceneInstaller : MonoInstaller<BattleSceneInstaller>
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<CardsModel>().AsSingle();
      Container.Bind<PlayerModel>().AsSingle();
      Container.Bind<CardsPanelView>().FromComponentInHierarchy();
      Container.Bind<UnitHolderView>().FromComponentInHierarchy();
    }
  }
}