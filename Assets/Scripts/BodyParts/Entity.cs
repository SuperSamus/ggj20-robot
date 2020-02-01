using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Entity : MonoBehaviour
{
    public Rigidbody rb;
    public List<RobotPart> parts = new List<RobotPart>();

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetLinks();
        ReorderParts();
        CreateBoxCollider();
    }

    public void SetLinks()
    {
        foreach (var part in parts)
        {
            part.attachedToEntity = this;
        }
    }
    
    public void CheckProximity(RobotPart part)
    {
        var colliders = Physics.BoxCastAll(part.transform.position, Vector3.one * 4, Vector3.up);
        var entities = new List<Entity>();
        foreach(var collider in colliders)
        {
            var entity = collider.collider.gameObject.GetComponent<Entity>();
            if(entity != null && entity != this)
            {
                ReceiveOtherEntity(entity);
            }
        }
    }

    public void ReceiveOtherEntity(Entity entity)
    {
        foreach (var roboPart in entity.parts)
        {
            roboPart.transform.parent = transform;
            roboPart.GetComponent<RobotPart>().attachedToEntity = this;
            parts.Add(roboPart);
        }
        SetLinks();
        ReorderParts();
        CreateBoxCollider();
        entity.gameObject.SetActive(false);
    }

    public void RemoveRobotPart(RobotPart part)
    {
        Entity entity = part.attachedToEntity;
        if (part.attachedToEntity.parts.Count > 1)
        {
            RobotPart highestPart = part.attachedToEntity.parts[0];
            for (int i = 0; i < entity.parts.Count; i++)
            {
                if (part.attachedToEntity.parts[i].partNumber > highestPart.partNumber)
                {
                    highestPart = part.attachedToEntity.parts[i];
                }
            }
            RaycastHit hit;
            if (!Physics.Raycast(highestPart.transform.position, entity.transform.forward, 1f))
            {
                var from = highestPart.transform.position + gameObject.transform.forward;
                if (Physics.Raycast(from, from + Vector3.down * 10f, out hit, 10f))
                {
                    Debug.Log("Ho colpito: " + hit.transform.name);
                    part.transform.parent = null;
                    
                    var go = new GameObject();
                    go.SetActive(false);
                    var component = go.AddComponent<Entity>();
                    component.parts.Add(part);
                    go.AddComponent<BoxCollider>();
                    go.AddComponent<Rigidbody>().freezeRotation = true;
                    go.SetActive(true);
                    part.attachedToEntity = component;
                    part.transform.parent = go.transform;
                    parts.Remove(part);
                    CreateBoxCollider();
                    ReorderParts();
                    go.transform.position = hit.point + Vector3.up * 0.7f;
                }
                else
                {
                    Debug.Log("Can't puut it there");
                }
            }
        }
    }

    public void ReorderParts()
    {
        parts = parts.OrderBy(x => x.partNumber).ToList();
        for (int i = 0; i < parts.Count; i++)
        {
            parts[i].transform.position = transform.position + Vector3.up * i;
        }
    }

    public void CreateBoxCollider()
    {
        Debug.Log(parts.Count);
        var box = GetComponent<BoxCollider>();
        var size = parts.Count;
        var offset = (size - 1) / 2f;
        Debug.Log(offset);
        box.size = new Vector3(1, size, 1);
        box.center = new Vector3(0, offset, 0);

    }
}
