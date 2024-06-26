using PencilGame;
using System;
using UnityEngine;

[RequireComponent(typeof(Chameleon))]
public class MulticolorPencilLauncher : PencilLauncher
{
    public Chameleon chameleon;
    public float alpha = 0.6f;

    protected override void Start()
    {
        base.Start();
        chameleon = GetComponent<Chameleon>();
        chameleon.Change(alpha);
    }

    protected override void OnLaunching()
    {
        base.OnLaunching();
        chameleon.Change(alpha);
    }

    protected override Pencil InstantiatePencil()
    {
        Pencil pen = base.InstantiatePencil();

        try
        {
            Skin skin = chameleon.skin;
            skin.spriteColor.a = 1;
            pen.GetComponent<MulticolorPencilLogic>().skin = skin;

        }
        catch (NullReferenceException ex)
        {
            Debug.LogError("MulticolorPencilLogic component is missing at Pencil");
        }

        return pen;
    }
}
