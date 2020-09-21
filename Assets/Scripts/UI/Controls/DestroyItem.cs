using UnityEngine;
using System.Collections;


namespace InventorySystem {
  public class DestroyItem : MonoBehaviour {
    public GameObject _destroyPanel;
    private float doubleClickTimeLimit = 0.25f;

    protected void Start() {
      StartCoroutine(InputListener());
    }

    private IEnumerator InputListener() {
      while (enabled) {
        if (Input.GetMouseButtonDown(0))
          yield return ClickEvent();
        yield return null;
      }
    }

    private IEnumerator ClickEvent() {
      yield return new WaitForEndOfFrame();

      var count = 0f;
      while (count < doubleClickTimeLimit) {
        if (Input.GetMouseButtonDown(0)) {
          DoubleClick();
          yield break;
        }

        count += Time.deltaTime;
        yield return null;
      }

      SingleClick();
    }


    private void SingleClick() { }

    private void DoubleClick() {
      _destroyPanel = GameObject.Find("FakePanel");
      _destroyPanel.SetActive(true);
      _destroyPanel.GetComponent<DestroyingItem>().destroyingItem = gameObject;
    }
  }
}