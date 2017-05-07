using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonBehavior : MonoBehaviour, IPointerClickHandler
{

    public System.Action buttonClicked;
    public void Start() { 
        gameObject.SetActive(false);
    }
    public void ShowButton()
    {
        gameObject.SetActive(true);
    }

    public void OnPointerClick(PointerEventData data)
    {
        gameObject.SetActive(false);
        if (buttonClicked != null)
        {
            
            buttonClicked.Invoke();
        }
    }
}
