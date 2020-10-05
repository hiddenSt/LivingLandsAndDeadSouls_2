using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem.DTO {

  public class LootUiData : MonoBehaviour {
    public SortedDictionary<string, GameObject> gunsImages;
    public SortedDictionary<string, GameObject> outfitImages;
    public GameObject ammoImage;
    public GameObject medKitImage;
    public GameObject meatImage;
    public string[] gunTypes;
    public GameObject[] guns;
    public string[] outfitsTypes;
    public GameObject[] outfitsImages;

    public GameObject separatedButton;
    public GameObject singleButton;

    private void Awake() {
      gunsImages = new SortedDictionary<string, GameObject>();
      for (int i = 0; i < gunTypes.Length; ++i) {
        gunsImages.Add(gunTypes[i], guns[i]);
      }

      outfitImages = new SortedDictionary<string, GameObject>();
      for (int i = 0; i < outfitsTypes.Length; ++i) {
        outfitImages.Add(outfitsTypes[i], outfitsImages[i]);
      }
    }


  }

}
