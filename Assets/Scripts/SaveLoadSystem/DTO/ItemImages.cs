using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem.DTO {

  public class ItemImages : MonoBehaviour {
    public SortedDictionary<string, GameObject> gunsImages;
    public SortedDictionary<string, GameObject> outfitImages;
    public GameObject ammoImage;
    public GameObject medKitImage;
    public GameObject meatImage;
    public string[] gunTypes;
    public GameObject[] guns;

    private void Start() {
      gunsImages = new SortedDictionary<string, GameObject>();
      for (int i = 0; i < gunTypes.Length; ++i) {
        gunsImages.Add(gunTypes[i], guns[i]);
      }
    }


  }

}
