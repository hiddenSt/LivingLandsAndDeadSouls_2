using UnityEngine;
using UnityEngine.UI;

namespace UI.Controls {

  public class CharacteristicsControl : MonoBehaviour {
    public Button setupButton;
    public Button closeButton;
    public GameObject characteristicsUi;
    private bool _closed;

    private void Start() {
      characteristicsUi.SetActive(false);
      _closed = true;
      setupButton.onClick.AddListener(OpenClose);
      closeButton.onClick.AddListener(OpenClose);
    }

    public void OpenClose() {
      if (_closed) {
        characteristicsUi.SetActive(true);
        _closed = false;
      } else {
        characteristicsUi.SetActive(false);
        _closed = true;
      }
    }
  }

}
