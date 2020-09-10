using Menu;
using UnityEngine;

namespace Characteristics {
  public class AllParameters : MonoBehaviour {
    public float Experience;
    public int Level = 1;
    public float ToNextLevelExp = 100;
    public int Strength;
    public int Health;
    public int Skill;
    public int FreePoints;
    
    private GameObject _valueSniper;
    private GameObject _personName;
    private GameObject _valueHealth;
    private GameObject _valueFreePoints;
    private GameObject _valueLevel;
    private GameObject _valueStrength;
    private Component _val3Ue;
    private string _playerName;
    private Canvas _canvas;
    private bool _infoOpen = false;
    
    public void AddExperience(float exp) {
      if (Experience + exp >= ToNextLevelExp) {
        Experience = Experience + exp - ToNextLevelExp;
        Level += 1;
        FreePoints += 2;
        ToNextLevelExp *= 1.5f;
        Update();
      }
      else {
        Experience += exp;
        Update();
      }
    }

    public void Display() {
      _personName.GetComponent<UnityEngine.UI.Text>().text = _playerName;
      _valueLevel.GetComponent<UnityEngine.UI.Text>().text=Level.ToString();
      _valueFreePoints.GetComponent<UnityEngine.UI.Text>().text=FreePoints.ToString();
      _valueStrength.GetComponent<UnityEngine.UI.Text>().text=Strength.ToString();
      _valueHealth.GetComponent<UnityEngine.UI.Text>().text=Health.ToString();
      _valueSniper.GetComponent<UnityEngine.UI.Text>().text=Skill.ToString();
    }

    public void Start() {
      Experience = 0;
      switch (GameObject.Find("ParametersManager").GetComponent<ParameterManager>().characterI) {
        case 0:
          _playerName = "Dick Clarque";
          break;
        case 1:
          _playerName = "Hu Lee";
          break;
        case 2:
          _playerName = "Vitali Tsal";
          break; 
      }
      _personName = GameObject.Find("Person name");
      _valueFreePoints = GameObject.Find("ValueFreePoints");
      _valueLevel = GameObject.Find("ValueLevel");
      _valueHealth = GameObject.Find("ValueHealth");
      _valueStrength = GameObject.Find("ValueStrength");
      _valueSniper = GameObject.Find("ValueSniper");
      _canvas = GetComponent<Canvas>();
      _canvas.enabled = false;
    }

    public void Update() {
      if (!Input.GetKeyDown(KeyCode.I)) return;
      if (_canvas.enabled) {
        _canvas.enabled = false;
      }
      else {
        Display();
        _canvas.enabled = true;
      }
    }
  }
}
