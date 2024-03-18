using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClientPrefab : MonoBehaviour
{
    public TMP_Text clientId;
    public TMP_Text clientLabel;

    [SerializeField] private ApiCall apiInfo;

    [SerializeField] private Button clientButton;
    [SerializeField] private GameObject prefab;
    [SerializeField] private PopupPrefab prefabInfo;
    [SerializeField] private Transform popupParent;
    void Start()
    {
        GameObject obj = GameObject.Find("Manager");
        apiInfo = obj.GetComponent<ApiCall>();
        popupParent = GameObject.Find("PopupParent").transform;
        clientButton = GetComponent<Button>();
        clientButton.onClick.AddListener(GetInfo);
    }
     

    void GetInfo()
    {
        int idValue = int.Parse(clientId.text);
        GameObject spawnedPrefab = Instantiate(this.prefab, popupParent);
        prefabInfo = spawnedPrefab.GetComponent<PopupPrefab>(); 

        if (idValue >= 1 && idValue <= apiInfo.names.Count)
        {
            int index = idValue - 1; // Adjusting for zero-based index
            prefabInfo.nameInfo.text = apiInfo.names[index];
            prefabInfo.pointsInfo.text = apiInfo.points[index].ToString();
            prefabInfo.addressInfo.text = apiInfo.addresses[index];
        }
        else
        {
             SetDefaultValues();
        }
    }

    public void SetDefaultValues()
    {
        prefabInfo.nameInfo.text = "Default Name";
        prefabInfo.pointsInfo.text = "Default points";
        prefabInfo.addressInfo.text = "Default address";
    }
}
