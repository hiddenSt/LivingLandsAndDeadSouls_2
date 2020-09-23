using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Controls {

  public class OutfitSlotControl : MonoBehaviour, IOutfitSlotUi {
    public OutfitComponent playerOutfitComponent;
    private Button _dropButton;
    private Image _outfitImage;
    
    public void SetOutfitImageAndActivateListener(Sprite outfitImage) {
      _outfitImage.sprite = outfitImage;
      _outfitImage.enabled = true;
      _dropButton.interactable = true;
      _dropButton.enabled = true;
      Debug.Log(":::" + _outfitImage.sprite);
      _dropButton.onClick.AddListener(playerOutfitComponent.RemoveToInventoryOrDrop);
    }

    public void RemoveOutfitImageAndDeactivateListener() {
      _dropButton.interactable = false;
      _outfitImage.enabled = false;
      _outfitImage.sprite = null;
      _dropButton.onClick.RemoveListener(playerOutfitComponent.RemoveToInventoryOrDrop);
    }

    private void Start() {
      _dropButton = gameObject.GetComponent<Button>();
      _outfitImage = gameObject.GetComponent<Image>();
      playerOutfitComponent.SetOutfitSlotUi(this);
    }
  }

}