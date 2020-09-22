using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Controls {

  public class OutfitSlotControl : MonoBehaviour, IOutfitSlotUi {
    public OutfitComponent playerOutfitComponent;
    private Button _dropButton;
    private Image _outfitImage;
    
    public void SetOutfitImageAndActivateListener(Sprite outfitUi) {
      _dropButton.onClick.AddListener(RemoveOutfitImageAndDeactivateListener);
      _outfitImage.sprite = outfitUi;
      _dropButton.interactable = true;
    }

    public void RemoveOutfitImageAndDeactivateListener() {
      _dropButton.interactable = false;
      _outfitImage.sprite = null;
      playerOutfitComponent.RemoveToInventoryOrDrop();
      _dropButton.onClick.RemoveListener(RemoveOutfitImageAndDeactivateListener);
    }

    private void Start() {
      _dropButton = gameObject.GetComponent<Button>();
      _outfitImage = gameObject.GetComponent<Image>();
      playerOutfitComponent.SetOutfitSlotUi(this);
      _dropButton.interactable = false;
    }
  }

}