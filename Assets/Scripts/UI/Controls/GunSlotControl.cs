using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Controls {

  public class GunSlotControl : MonoBehaviour, IGunSlotUi {
    public void ChangeAmmoCount(int count) {
      _ammoText.text = count.ToString();
    }

    public void SetGunComponent(GunComponent gunComponent) {
      _playerGunComponent = gunComponent;
    }

    public void SetGunImageAndActivateListener(Sprite gunImage) {
      _gunImage.sprite = gunImage;
      _dropButton.onClick.AddListener(_playerGunComponent.RemoveToInventoryOrDrop);
      _dropButton.interactable = true;
      _dropButton.enabled = true;
    }

    public void RemoveGunImageAndDeactivateListener() {
      _gunImage.sprite = null;
      _dropButton.onClick.RemoveListener(_playerGunComponent.RemoveToInventoryOrDrop);
      _dropButton.interactable = false;
      _dropButton.enabled = false;
    }

    private void Start() {
      _ammoText = gameObject.GetComponent<Text>();
      _dropButton = gameObject.GetComponent<Button>();
      _gunImage = gameObject.GetComponent<Image>();
    }

    private Text _ammoText;
    private Button _dropButton;
    private Image _gunImage;
    private GunComponent _playerGunComponent;
  }
}
