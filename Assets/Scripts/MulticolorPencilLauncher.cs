using PencilGame;
using System;
using UnityEngine;

[RequireComponent(typeof(Chameleon))]
public class MulticolorPencilLauncher : PencilLauncher
{
    public Chameleon chameleon;

    protected override void Start()
    {
        base.Start();
        chameleon = GetComponent<Chameleon>();
        chameleon.Change();
    }

    protected override void OnLaunching()
    {
        base.OnLaunching();
        chameleon.Change();
    }

    protected override Pencil InstantiatePencil()
    {
        Pencil pen = base.InstantiatePencil();

        try
        {
            pen.GetComponent<MulticolorPencilLogic>().skin = chameleon.skin;

        }
        catch (NullReferenceException ex)
        {
            Debug.LogError("MulticolorPencilLogic component is missing at Pencil");
        }

        return pen;
    }
}
