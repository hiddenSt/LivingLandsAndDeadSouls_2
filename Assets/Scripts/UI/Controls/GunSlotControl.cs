using Components.Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Controls {
  
  public class GunSlotControl : MonoBehaviour, IGunSlotUi {
    public GunComponent playerGunComponent;
    public Text ammoText;
    
    private Button _dropButton;
    private Image _gunImage;
    
    public void ChangeAmmoCount(int count) {
      ammoText.text = count.ToString();
    }

    public void SetGunImageAndActivateListener(Sprite gunImage) {
      _gunImage.sprite = gunImage;
      _gunImage.enabled = true;
      _dropButton.interactable = true;
      _dropButton.enabled = true;
      _dropButton.onClick.AddListener(playerGunComponent.RemoveToInventoryOrDrop);
    }

    public void RemoveGunImageAndDeactivateListener() {
      _gunImage.sprite = null;
      _gunImage.enabled = false;
      _dropButton.onClick.RemoveListener(playerGunComponent.RemoveToInventoryOrDrop);
      _dropButton.interactable = false;
      _dropButton.enabled = false;
    }

    public void Setup() {
      playerGunComponent.SetGunSlotUi(this);
      _dropButton = gameObject.GetComponent<Button>();
      _gunImage = gameObject.GetComponent<Image>();
    }
  }
}