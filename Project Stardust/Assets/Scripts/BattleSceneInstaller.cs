using Zenject;

namespace StarDust
{
  public class BattleSceneInstaller : MonoInstaller<BattleSceneInstaller>
  {
    public UnitHolderView TopPlayerUnitHolderView;
    public UnitHolderView BottomPlayerUnitHolderView;

    public override void InstallBindings()
    {
      Container.Bind<DefendingPlayerModel>().AsSingle();
      Container.Bind<AttackingPlayerModel>().AsSingle();
      Container.Bind<CardsModel>().AsTransient().WhenInjectedInto<PlayerModel>();
      
      Container.Bind<GameLogic>().AsSingle();
      Container.Bind<CardsPanelView>().FromComponentInParents();

      //Container.Bind<UnitHolderView>().FromComponentInHierarchy(); // In game we will have 2 so this won't work now.
      Container.Bind<UnitHolderView>().FromComponentInHierarchy(); // In game we will have 2 so this won't work now.
      Container.Bind<UnitHolderView>().WithId("Bottom").FromInstance(BottomPlayerUnitHolderView);
      Container.Bind<UnitHolderView>().WithId("Top").FromInstance(TopPlayerUnitHolderView);

      /* 
        This must be moved to specific GameObject installer. Here we do not know what PlayerModel is. PlayerModel can be attacking player or defending player depending on context.
        This should be used for example in UI which on game begin we don't know if top/bottom ui is attacking/defending player.
       */ 
      // Container.Bind<CardsModel>().FromResolveGetter<PlayerModel>(dp => dp.GetCardsModel); 
      Container.Bind<InputManager>().FromComponentInHierarchy();

    }
  }
}