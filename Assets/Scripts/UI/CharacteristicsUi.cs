using Components.Player;
using DataTransferObjects;
using UnityEngine;
using UnityEngine.UI;

namespace UI {

  public class CharacteristicsUi : MonoBehaviour, ICharacteristicsUi {
    public Text freePointsText;
    public Text damageBuffText;
    public Text healthLimitText;
    public Text characterName;
    private CharacteristicsComponent _playerCharacteristics;

    public void SetFreePoints(int points) {
      freePointsText.text = points.ToString();
    }

    public void SetDamageBuffPoints(int points) {
      damageBuffText.text = points.ToString();
    }

    public void SetHealthLimitPoints(int points) {
      healthLimitText.text = points.ToString();
    }

    public void AddHealthLimit() {
      _playerCharacteristics.BuffHealthLimit();
    }

    public void AddDamageBuff() {
      _playerCharacteristics.BuffHealthLimit();
    }

    public void SetUp(CharacteristicsComponent playerCharacteristics) {
      _playerCharacteristics = playerCharacteristics;
      characterName.text = ParameterManager.instance.characterName;
    }
  }

}
