using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DropdownHandler : MonoBehaviour
{
    private TMP_Dropdown dropdown; 
    public GameObject[] panels;
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(dropdown);
        });
    }

    void DropdownValueChanged(TMP_Dropdown change)
    { 
        int selectedOptionIndex = change.value;
         
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].transform.DOScaleX(0.75f, 0.001f);
            panels[i].SetActive(i == selectedOptionIndex);
            panels[i].transform.DOScaleX(1, 0.25f); 
        }
    }


}
