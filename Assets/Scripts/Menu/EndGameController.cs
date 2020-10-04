using HealthFight;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
  public class EndGameController : MonoBehaviour {
    private void Start() {
      _playerHealth = GameObject.Find("Player").GetComponent<HealthComponent>();
    }

    private void Update() {
      if (endofGame) {
        _delay -= Time.deltaTime;

        if (_delay <= 0) {
          var sounds = GameObject.Find("Sounds");
          for (var i = 1; i < sounds.transform.childCount; i++)
            sounds.transform.GetChild(i).GetComponent<AudioSource>().Stop();
          SceneManager.LoadScene("Menu");
        }
        return;
      }

      if (_playerHealth != null || !_playerHealth.IsDead())
        return;

      endofGame = true;
      endGameCanvas.SetActive(true);
    }

    //dataMembers
    public GameObject endGameCanvas;

    private HealthComponent _playerHealth;
    private float _delay = 4f;
    private bool endofGame = false;
  }
} //end of namespace Menu