using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class PopupPrefab : MonoBehaviour
{
    public TMP_Text nameInfo;
    public TMP_Text pointsInfo;
    public TMP_Text addressInfo;

    [SerializeField] private Button closeButton;

    void Start()
    {
        closeButton.onClick.AddListener(DestroyObject);
    }

    private void OnEnable()
    {
        gameObject.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f),0.001f);
        gameObject.transform.DOScale(new Vector3(1, 1, 1),0.5f); 
    }

    private void DestroyObject()
    {
        Destroy(gameObject, 0.6f);
        gameObject.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f),0.5f); 
    }

}
