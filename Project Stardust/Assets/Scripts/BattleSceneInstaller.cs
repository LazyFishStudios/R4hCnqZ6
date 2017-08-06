using Zenject;

namespace StarDust
{
  public class BattleSceneInstaller : MonoInstaller<BattleSceneInstaller>
  {
    public const string DefendingPlayerID = "DefendingPlayer";

    public override void InstallBindings()
    {
      Container.Bind<DefendingPlayer>().AsSingle();
      Container.Bind<GameLogic>().AsSingle();
      Container.Bind<CardsPanelView>().FromComponentInHierarchy();
      Container.Bind<UnitHolderView>().FromComponentInHierarchy();

      Container.BindInterfacesAndSelfTo<CardsModel>().AsTransient().WhenInjectedInto<DefendingPlayer>();
  //  Container.Bind<CardsModel>().WithId(DefendingPlayerID).FromResolveGetter<DefendingPlayer>(dp => dp.GetCardsModel);
      Container.Bind<CardsModel>().FromResolveGetter<DefendingPlayer>(dp => dp.GetCardsModel);
      Container.Bind<CardsModel>().WithId("d").FromResolveGetter<DefendingPlayer>(dp => dp.GetCardsModel);
    }
  }
}