using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Instance : Entity
{
    public float Speed;

    public Weapon weapon;

    protected Vector3 Target;

    protected void Start()
    {
        weapon = gameObject.GetComponentInChildren<Weapon>();
    }

    new void Update()
    {
        base.Update();
    }

    // Instances can move
    protected virtual void Move()
    {
        throw new System.NotImplementedException();
    }

    public T FindNearestByTag<T>(string tag,float maxDistance = float.PositiveInfinity) where T : MonoBehaviour
    {
        var objects = GameObject.FindGameObjectsWithTag(tag);

        if (objects != null)
        {
            List<T> selectedObjects = new List<T>();
            foreach (var item in objects)
            {
                if(item.TryGetComponent<T>(out var component))
                    selectedObjects.Add(component);
            }

            return FindNearests<T>(selectedObjects, maxDistance);
        }
        return null;
    }

    public T FindNearestByType<T>(float maxDistance = float.PositiveInfinity) where T : MonoBehaviour
    {
        var objects = GameObject.FindObjectsOfType<T>();
        return null;
    }

    protected T FindNearests<T>(List<T> objects,float maxDistance = float.PositiveInfinity) where T : MonoBehaviour
    {
        if(objects.Count == 0)
            return null;

        T nearestObject = null;
        foreach (T item in objects){
            var dist = Vector2.Distance(this.transform.position, item.transform.position);

            if (dist <= maxDistance)
            {
                if(nearestObject == null)
                {
                    nearestObject = item;
                }
                else
                {
                    var dist2 = Vector2.Distance(this.transform.position, nearestObject.transform.position);
                    nearestObject = dist < dist2? item: nearestObject;
                }
            }
        }
        return nearestObject;
    }

}