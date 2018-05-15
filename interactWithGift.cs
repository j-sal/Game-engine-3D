using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactWithGift : MonoBehaviour {
    public Canvas gui;

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
            print("was destroyed");
            gui.GetComponent<guibehavior>().UpdateGUI();
        }
    }

}
