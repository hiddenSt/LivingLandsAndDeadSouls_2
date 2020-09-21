using HealthFight;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
  public class EndGameController : MonoBehaviour {
    private void Start() {
      _playerHealth = GameObject.Find("Player").GetComponent<HealthComponent>();
      _playerHealthBar = GameObject.Find("PlayerHealthBar").GetComponent<HealthBar>();
    }

    private void Update() {
      if (endofGame) {
        _delay -= Time.deltaTime;

        if (_delay <= 0) {
          var sounds = GameObject.Find("Sounds");
          for (var i = 1; i < sounds.transform.childCount; i++)
            sounds.transform.GetChild(i).GetComponent<AudioSource>().Stop();

          Debug.Log("Before");
          SaveLoadSystem.SaveSystem.DeleteSaves();
          Debug.Log("Between");
          SceneManager.LoadScene("Menu");
          Debug.Log("After");
        }

        return;
      }

      if (_playerHealth != null || _playerHealth.health > 0)
        return;

      endofGame = true;
      endGameCanvas.SetActive(true);
      _playerHealthBar.SetSize(0);
    }

    //dataMembers
    public GameObject endGameCanvas;

    private HealthComponent _playerHealth;
    private HealthBar _playerHealthBar;
    private float _delay = 4f;
    private bool endofGame = false;
  }
} //end of namespace Menu