﻿using Components;
using DataTransferObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
  public class PauseMenu : MonoBehaviour {
    public void OnGamePause() {
      Time.timeScale = 0;
      pausePanel.SetActive(true);
    }

    public void OnGameResume() {
      Time.timeScale = 1;
      pausePanel.SetActive(false);
    }

    public void OnGameExit() {
      OnGameResume();
      var parameterManager = GameObject.Find("ParametersManager").GetComponent<ParameterManager>();
      parameterManager.Precipitation = 1;
      parameterManager.RockValue = 4;
      parameterManager.BuildingValue = 8;
      parameterManager.ForestValue = 3;
      parameterManager.SizeOfForest = 10;
      parameterManager.CharacterI = 0;
      parameterManager.HostileCharVal = 92;
      parameterManager.NeutralCharVal = 128;
      parameterManager.StartSeason = 0;
      var saver = gameObject.GetComponent<GameSaver>();
      saver.Save();
      SceneManager.LoadScene("Menu");
    }

    //data members
    public GameObject pausePanel;
  }
}