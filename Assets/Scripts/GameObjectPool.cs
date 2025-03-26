using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField]
    protected GameObject poolPrefab;

    [SerializeField]
    bool isParented = false;

    protected List<GameObject> objectPool = new();
    private int initialSize = 5;

    protected virtual void Start()
    {
        for (int i = 0; i < initialSize; i++)
        {
            Transform parentTransform = isParented ? transform : null;

            GameObject obj = Instantiate(poolPrefab, parentTransform);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject GetFirstObject()
    {
        GameObject firstObject = objectPool.FirstOrDefault(obj => !obj.activeInHierarchy);

        if (firstObject == null)
        {
            firstObject = Instantiate(poolPrefab);
            objectPool.Add(firstObject);
        }

        firstObject.SetActive(true);
        return firstObject;
    }
}
