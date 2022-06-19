using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspect : MonoBehaviour
{
    public AspectData data;
    public SpriteRenderer spriteRenderer;
    public Connection connection;

    private Camera _camera;
    private Encounter _encounter;
    private Vector3 _destination;

    private void Awake()
    {
        spriteRenderer.sprite = data.icon;
        _camera = Camera.main;
        connection = Connection.GetMainConnection();
        _encounter = GameManager.GetCurrentChapter().GetEncounter();
    }

    private void FixedUpdate()
    {
        transform.position += (_destination - transform.position) * 0.05f;
    }

    public void SetAspect(AspectData newData)
    {
        data = newData;
        spriteRenderer.sprite = data.icon;
    }

    public AspectData GetAspectData()
    {
        return data;
    }

    public void MoveToPositionAroundPoint(Vector3 centerPoint, float radiousAround, float angleInDegrees)
    {
        Vector3 destination = Vector3.up * radiousAround;
        destination = Quaternion.Euler(0, 0, angleInDegrees) * destination;
        destination = destination + centerPoint;

        _destination = destination;
    }
    
    private void OnMouseDown()
    {
        connection.StartConnection(transform.position, data.name, transform);
        SignalLinkIsBroken();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            connection.EndConnection(transform.position, data.name, transform);
        }
    }

    private void OnMouseEnter()
    {
        TooltipSystem.Show(data.name, data.description);
    }

    private void OnMouseExit()
    {
        TooltipSystem.Hide();
    }

    private void OnDestroy()
    {
        TooltipSystem.Hide();
    }

    private void SignalLinkIsBroken()
    {
        _encounter.LinkIsBroken();
    }
}
