using HealthFight;
using SaveLoadSystem.LoadSystem.Loaders;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
  public class EndGameController : MonoBehaviour, IHealthEventSubscriber {
    public GameObject endGameCanvas;
    private float _delay = 40f;
    
    public void EntityIsDead(Vector3 position, int originId) {
      _delay = 4f;
      endGameCanvas.SetActive(true);
      while (_delay > 0) {
        _delay -= Time.deltaTime;
      } 
      var sounds = GameObject.Find("Sounds");
      for (var i = 1; i < sounds.transform.childCount; i++)
        sounds.transform.GetChild(i).GetComponent<AudioSource>().Stop();
      var playerSaves = new PlayerLoader("Player.data");
      playerSaves.DeleteSaves();
      SceneManager.LoadScene("Menu");
    }
  }
}