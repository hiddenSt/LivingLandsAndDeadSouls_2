using Player;
using UnityEngine;
using UnityEngine.Serialization;
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

    public void SetGunComponent(GunComponent gunComponent) {
      playerGunComponent = gunComponent;
    }

    public void SetGunImageAndActivateListener(Sprite gunImage) {
      _gunImage.sprite = gunImage;
      _dropButton.onClick.AddListener(playerGunComponent.RemoveToInventoryOrDrop);
      _dropButton.interactable = true;
      _dropButton.enabled = true;
    }

    public void RemoveGunImageAndDeactivateListener() {
      _gunImage.sprite = null;
      _dropButton.onClick.RemoveListener(playerGunComponent.RemoveToInventoryOrDrop);
      _dropButton.interactable = false;
      _dropButton.enabled = false;
    }

    private void Start() {
      playerGunComponent.SetGuSlotUi(this);
      _dropButton = gameObject.GetComponent<Button>();
      _gunImage = gameObject.GetComponent<Image>();
    }
  }
}