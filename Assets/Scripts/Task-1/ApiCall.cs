using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using DataUtils;

public class ApiCall : MonoBehaviour
{   
    public List<string> names;
    public List<string> addresses;
    public List<int> points;

    [SerializeField] private GameObject clientPrefab;

    [SerializeField] private Transform parent1;
    [SerializeField] private Transform parent2;
    [SerializeField] private Transform parent3;
    void Start()
    {
        StartCoroutine(GetRequest("https://qa.sunbasedata.com/sunbase/portal/api/assignment.jsp?cmd=client_data"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(string.Format("Failed to fetch data: {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Root dataInfo = JsonConvert.DeserializeObject<Root>(webRequest.downloadHandler.text);
                    PopulateClients(dataInfo.clients); 
                    PopulateData(dataInfo.data);
                    break;
            }
        } 
    }

    void PopulateClients(List<Client> clients)
    {
        foreach (var data in clients)
        {
            GameObject prefab = Instantiate(clientPrefab, parent1);
            prefab.GetComponent<ClientPrefab>().clientId.text = data.id.ToString();
            prefab.GetComponent<ClientPrefab>().clientLabel.text = data.label.ToString();
            GameObject prefab1 = Instantiate(clientPrefab, data.isManager ? parent2 : parent3);
            prefab1.GetComponent<ClientPrefab>().clientId.text = data.id.ToString();
            prefab1.GetComponent<ClientPrefab>().clientLabel.text = data.label.ToString();
        }
    }
    void PopulateData(Data data)
    {
        if (data != null)
        {
            ApiUtils.AddNonNullToList(names, data._1.name, data._2.name, data._3.name);
            ApiUtils.AddNonNullToList(addresses, data._1.address, data._2.address, data._3.address);
            points.Add(data._1.points);
            points.Add(data._2.points);
            points.Add(data._3.points);
        }
    }

}
