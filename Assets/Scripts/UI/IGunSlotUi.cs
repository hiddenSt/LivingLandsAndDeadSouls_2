using UnityEngine;

namespace UI {
  
  public interface IGunSlotUi {
    void ChangeAmmoCount(int count);
    void SetGunImageAndActivateListener(Sprite gunImage);
    void RemoveGunImageAndDeactivateListener();
  }
}