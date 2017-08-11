using Zenject;

namespace StarDust
{
  public class BattleSceneInstaller : MonoInstaller<BattleSceneInstaller>
  {
    public const string DefendingPlayerID = "DefendingPlayer";
    public UnitHolderView uhv;

    public override void InstallBindings()
    {
      Container.Bind<DefendingPlayer>().AsSingle().WithArguments(42);
      Container.Bind<GameLogic>().AsSingle();
      Container.Bind<CardsPanelView>().FromComponentInParents();//.WhenInjectedInto<CardView>();
      //Container.Bind<UnitHolderView>().FromComponentInHierarchy();
      Container.Bind<UnitHolderView>().WithId("Bottom").FromInstance(uhv);

      Container.BindInterfacesAndSelfTo<CardsModel>().AsTransient().WhenInjectedInto<DefendingPlayer>();
  //  Container.Bind<CardsModel>().WithId(DefendingPlayerID).FromResolveGetter<DefendingPlayer>(dp => dp.GetCardsModel);
      Container.Bind<CardsModel>().FromResolveGetter<DefendingPlayer>(dp => dp.GetCardsModel);
      string s = "d";
      Container.Bind<CardsModel>().WithId(s).FromResolveGetter<DefendingPlayer>(dp => dp.GetCardsModel);
      Container.Bind<InputManager>().FromComponentInHierarchy();
    }
  }
}