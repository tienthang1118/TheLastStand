using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<PooledObjectInfo> ObjectPools = new List<PooledObjectInfo>();
    private GameObject objectPoolEmptyHolder;
    private static GameObject particleSystemsEmpty;
    private static GameObject gameObjectsEmpty;

    public enum PoolType
    {
        ParticleSystem,
        GameObject,
        None
    }
    public static PoolType PoolingType;

    private void Awake()
    {
        SetupEmpties();
    }
    private void SetupEmpties()
    {
        objectPoolEmptyHolder = new GameObject("Pooled Objects");

        particleSystemsEmpty = new GameObject("Particle Efects");
        particleSystemsEmpty.transform.SetParent(objectPoolEmptyHolder.transform);

        gameObjectsEmpty = new GameObject("GameObjects");
        gameObjectsEmpty.transform.SetParent(objectPoolEmptyHolder.transform);

    }
    public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation, PoolType poolType = PoolType.None)
    {
        PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == objectToSpawn.name);
        if(pool == null)
        {
            pool = new PooledObjectInfo() { LookupString = objectToSpawn.name };
            ObjectPools.Add(pool);
        }
        GameObject spawnableObj = pool.InactiveObjects.FirstOrDefault();
        if(spawnableObj == null)
        {
            GameObject parentObject = SetParentObject(poolType);
            spawnableObj = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
            if(parentObject != null)
            {
                spawnableObj.transform.SetParent(parentObject.transform);
            }
        }
        else
        {
            spawnableObj.transform.position = spawnPosition;
            spawnableObj.transform.rotation = spawnRotation;
            pool.InactiveObjects.Remove(spawnableObj);
            spawnableObj.SetActive(true);
        }
        return spawnableObj;
    }
    public static GameObject SpawnObject(GameObject objectToSpawn, Transform parentTransform)
    {
        PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == objectToSpawn.name);
        if (pool == null)
        {
            pool = new PooledObjectInfo() { LookupString = objectToSpawn.name };
            ObjectPools.Add(pool);
        }
        GameObject spawnableObj = pool.InactiveObjects.FirstOrDefault();
        if (spawnableObj == null)
        {
            spawnableObj.transform.SetParent(parentTransform);
        }
        else
        {
            pool.InactiveObjects.Remove(spawnableObj);
            spawnableObj.SetActive(true);
        }
        return spawnableObj;
    }
    public static void ReturnObjectToPool(GameObject obj)
    {
        string goName = obj.name.Substring(0, obj.name.Length - 7);
        PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == goName);
        if(pool == null)
        {
            Debug.LogWarning("Trying to release an object that is not pooled: " + obj.name);
        }
        else
        {
            obj.SetActive(false);
            pool.InactiveObjects.Add(obj);
        }
    }
    private static GameObject SetParentObject(PoolType poolType)
    {
        switch(poolType)
        {
            case PoolType.ParticleSystem:
                return particleSystemsEmpty;
            case PoolType.GameObject:
                return gameObjectsEmpty;
            case PoolType.None:
                return null;
            default:
                return null;
        };
    }
}

public class PooledObjectInfo
{
    public string LookupString;
    public List<GameObject> InactiveObjects = new List<GameObject>();
}