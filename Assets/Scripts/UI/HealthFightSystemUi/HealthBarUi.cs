using HealthFight;
using UnityEngine;

namespace UI.HealthFightSystemUi {

  public class HealthBarUi : MonoBehaviour, IHealthUi {
    private float _healthPointsLimit = 100;
    private float _healthPoints;
    private Transform _bar;

    public void SetHealthPointsLimit(float points) {
      _healthPointsLimit = points;
      SetHealthPoints(_healthPoints);
    }

    public void SetHealthPoints(float points) {
      _healthPoints = points;
      _bar.localScale = new Vector3(_healthPoints/_healthPointsLimit, 1f);
      if (_healthPoints <= 0) {
        Destroy(gameObject);
      }
    }
    
    private void Awake() {
      _bar = transform.Find("Bar");
    }
  }

}