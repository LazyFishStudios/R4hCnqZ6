using UnityEngine;
using Zenject;
using StarDust;

public class UIInstaller : MonoInstaller<UIInstaller>
{
  public PlayerTypes PlayerType;

  public override void InstallBindings()
  {
    Debug.Log("UIInstaller bindings " + gameObject.name);
    if (PlayerType == PlayerTypes.ATTACKING)
    {
      Container.Bind<PlayerModel>().To<AttackingPlayerModel>().FromResolve();
    }
    else
    {
      Container.Bind<PlayerModel>().To<DefendingPlayerModel>().FromResolve();
    }
    Container.Bind<CardsModel>().FromResolveGetter<PlayerModel>(dp => dp.GetCardsModel);
  }
}