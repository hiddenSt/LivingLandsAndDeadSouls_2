using Components.Player;
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
      _dropButton.onClick.AddListener(playerOutfitComponent.RemoveToInventoryOrDrop);
    }

    public void RemoveOutfitImageAndDeactivateListener() {
      _outfitImage.sprite = null;
      _outfitImage.enabled = false;
      _dropButton.onClick.RemoveListener(playerOutfitComponent.RemoveToInventoryOrDrop);
      _dropButton.interactable = false;
      _dropButton.enabled = false;
    }

    public void SetUp() {
      playerOutfitComponent.SetOutfitSlotUi(this);
      _dropButton = gameObject.GetComponent<Button>();
      _outfitImage = gameObject.GetComponent<Image>();
    }
  }

}