using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
  
  public interface IGunSlotUi {
    void ChangeAmmoCount(int count);
    void SetGunImageAndActivateListener(Sprite gunImage);
    void RemoveGunImageAndDeactivateListener();
    void SetGunComponent(GunComponent gunComponent);
  }
}