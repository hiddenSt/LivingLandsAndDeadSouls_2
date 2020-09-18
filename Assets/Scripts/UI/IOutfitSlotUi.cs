using Player;
using UnityEngine.UI;

namespace UI {

  public interface IOutfitSlotUi {
    void SetOutfitImageAndActivateListener(Image outfitImage);
    void RemoveOutfitImageAndDeactivateListener();
    void SetOutfitComponent(OutfitComponent outfitComponent);
  }
}
