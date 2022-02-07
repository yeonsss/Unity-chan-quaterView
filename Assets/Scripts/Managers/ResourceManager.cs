using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // 리소스를 통합관리하기 위한 매니저
    public T Load<T>(string path) where T : Object
    {
        
        if (typeof(T) == typeof(GameObject))
        {
            string name = path;
            int idx = name.LastIndexOf('/');
            if(idx >= 0)
            {
                name = name.Substring(idx + 1);
            }

            GameObject go = Managers.Pool.GetOriginal(name);
            if (go != null)
            {
                return go as T;
            }
        }
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        //1. 오리지널 이미 들고있다면 바로 사용
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if (original == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        // 2. 혹시 풀링된 애가 있을까?
        if (original.GetComponent<Poolable>() != null)
        {
            Debug.Log("i find pool");
            return Managers.Pool.Pop(original, parent).gameObject;
        }

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;

        //int idx = go.name.IndexOf("(Clone)");
        //if (idx > 0)
        //{
        //    go.name = go.name.Substring(0, idx);
        //}

        return go;
    }

    public void Destory(GameObject go)
    {
        if (go == null)
        {
            Debug.Log($"Failed to Destroy");
            return;
        }

        // 만약 풀링이 필요한 친구라면 풀링 매니저한테 위탁
        Poolable poolable = go.GetComponent<Poolable>();
        if (poolable != null )
        {
            Managers.Pool.Push(poolable);
            return;
        }

        Object.Destroy(go);
    }
}
