using UnityEngine;

namespace UI {
  
  public interface IOutfitSlotUi {
    void SetOutfitImageAndActivateListener(Sprite outfitImage);
    void RemoveOutfitImageAndDeactivateListener();
  }
}