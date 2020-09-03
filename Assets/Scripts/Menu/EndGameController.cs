using System.Collections;
using System.Collections.Generic;
using HealthFight;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class EndGameController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            _playerHealth = GameObject.Find("Player").GetComponent<HealthComponent>();
            _playerHealthBar = GameObject.Find("PlayerHealthBar").GetComponent<HealthBar>();
        }

        // Update is called once per frame
        void Update()
        {
            if (endofGame)
            {
                _delay -= Time.deltaTime;
                if (_delay <= 0)
                {
                    GameObject sounds = GameObject.Find("Sounds");
                    for (int i = 1; i < sounds.transform.childCount; i++)
                    {
                        sounds.transform.GetChild(i).GetComponent<AudioSource>().Stop();
                    }
                    Debug.Log("Before");
                    SaveLoadSystem.SaveSystem.DeleteSaves();
                    Debug.Log("Between");
                    SceneManager.LoadScene("Menu");
                    Debug.Log("After");
                }
                return;
            }
            if (_playerHealth != null ||_playerHealth.health > 0)
                return;
            endofGame = true;
            //_playerHealth.gameObject.SetActive(false);
            endGameCanvas.SetActive(true);
            _playerHealthBar.SetSize(0);
        }

        //dataMembers
        public GameObject endGameCanvas;

        private HealthComponent _playerHealth;
        private HealthFight.HealthBar _playerHealthBar;
        private float _delay = 4f;
        private bool endofGame = false;
    }
}//end of namespace Menu
