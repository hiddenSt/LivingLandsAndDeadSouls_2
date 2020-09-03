using UnityEngine;
using System.Collections;
using InventorySystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DestroyItem : MonoBehaviour
{
    public GameObject _destroyPanel;
    private float doubleClickTimeLimit = 0.25f;

    protected void Start()
    {
        StartCoroutine(InputListener());
    }

// Update is called once per frame
    private IEnumerator InputListener() 
    {
        while(enabled)
        {
            if(Input.GetMouseButtonDown(0))
                yield return ClickEvent();
            yield return null;
        }
    }

    private IEnumerator ClickEvent()
    {
        yield return new WaitForEndOfFrame();

        float count = 0f;
        while(count < doubleClickTimeLimit)
        {
            if(Input.GetMouseButtonDown(0))
            {
                DoubleClick();
                yield break;
            }
            count += Time.deltaTime;
            yield return null;
        }
        SingleClick();
    }


    private void SingleClick()
    {
        GunSelect gunSelect;
        OutfitSelect outfitSelect;
        HealthBoost healthBoost;
        gunSelect = gameObject.GetComponent<GunSelect>();
        outfitSelect = gameObject.GetComponent<OutfitSelect>();
        healthBoost = gameObject.GetComponent<HealthBoost>();
        if (gunSelect != null)
        {
            gunSelect.Use();
        }
        else if (outfitSelect != null)
        {
            outfitSelect.Use();
        }
        else if (healthBoost != null)
        {
            healthBoost.Use();
        }
    }

    private void DoubleClick()
    {
        _destroyPanel = GameObject.Find("FakePanel");
        _destroyPanel.SetActive(true);
        _destroyPanel.GetComponent<DestroyingItem>().destroyingItem = gameObject;
    }
}