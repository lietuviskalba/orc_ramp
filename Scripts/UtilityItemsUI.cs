using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UtilityItemsUI : MonoBehaviour
{
    private GameObject bagCD;

    private Image imgBagCd;

    private float bagCd = 0;
    private bool isBagPressed;

    void Start()
    {
        bagCD = transform.GetChild(1).gameObject; // Get the Bag cooldown
        imgBagCd = bagCD.transform.GetChild(0).gameObject.GetComponent<Image>(); // Get the img in child
        bagCd = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().bagSpawnRate;
    }

    void Update()
    {
        try
        {
            BagCooldown();
        }
        catch
        {
            Debug.LogWarning("You need to connect the public prefab");
        }
    }

    private void BagCooldown()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Add touch input
        {
            SetImgProperties(true, 0, Color.gray);
        }

        if (isBagPressed == true)
        {
            imgBagCd.fillAmount += 1f / bagCd * Time.deltaTime; // Fill img over time

            if (imgBagCd.fillAmount >= 1)
            {
                SetImgProperties(false, 1, Color.white);
            }
        }
    }
    private void SetImgProperties(bool btnState, float fill, Color color)
    {
        isBagPressed = btnState;
        imgBagCd.fillAmount = fill;
        imgBagCd.color = color;
    }
}
