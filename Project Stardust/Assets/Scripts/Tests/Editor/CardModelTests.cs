using Zenject;
using NUnit.Framework;
using StarDust;

[TestFixture]
public class CardModelTests : ZenjectUnitTestFixture
{
  [SetUp]
  public void Bindings()
  {
    Container.Bind<CardsModel>().AsSingle();
  }

  [Test]
  public void NoCardsOnStart()
  {
    CardsModel _cardsModel = Container.Resolve<CardsModel>();
    Assert.That(_cardsModel.NumberOfCardOnHand, Is.EqualTo(0));
  }

  [Test]
  public void AddCard()
  {
    CardsModel _cardsModel = Container.Resolve<CardsModel>();
    _cardsModel.AddTopCardFromDeckToHand();
    Assert.That(_cardsModel.NumberOfCardOnHand, Is.EqualTo(1));
    _cardsModel.AddTopCardFromDeckToHand();
    Assert.That(_cardsModel.NumberOfCardOnHand, Is.EqualTo(2));
  }
}