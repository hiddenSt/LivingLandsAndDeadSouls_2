using UnityEngine;

namespace UI {
  
  public interface IOutfitSlotUi {
    void SetOutfitImageAndActivateListener(Sprite outfitUi);
    void RemoveOutfitImageAndDeactivateListener();
  }
}