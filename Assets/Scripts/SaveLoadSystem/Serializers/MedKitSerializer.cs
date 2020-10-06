using System.Collections;
using System.Collections.Generic;
using Items;
using SaveLoadSystem.DTO;
using UnityEngine;

namespace SaveLoadSystem.Serializers {

  public class MedKitSerializer {
    public MedKitData Serialize(MedKit medKit) {
      var medKitData = new MedKitData();
      medKitData.medKitType = medKit.GetMedKitType();
      medKitData.healthBoost = medKit.GetHealthPointsBoost();
      return medKitData;
    }

    public MedKit Deserialize(MedKitData medKitData) {
      var medKit = new MedKit(medKitData.medKitType, medKitData.healthBoost);
      return medKit;
    }
  }

}
