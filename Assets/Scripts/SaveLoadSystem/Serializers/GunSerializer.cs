using Items;
using SaveLoadSystem.DTO;

namespace SaveLoadSystem.Serializers {

  public class GunSerializer {
    public GunData Serialize(Gun gun) {
      var gunData = new GunData();
      gunData.gunType = gun.GetGunType();
      gunData.damage = gun.GetDamagePoints();
      gunData.ammoCount = gun.GetAmmoCount();
      gunData.fireRate = gun.GetFireRate();
      gunData.ammoLimit = gun.GetAmmoLimit();
      return gunData;
    }

    public Gun Deserialize(GunData gunData) {
      var gun = new Gun(gunData.gunType, gunData.fireRate, gunData.damage, gunData.ammoCount, gunData.ammoLimit);
      return gun;
    }
  }

}
