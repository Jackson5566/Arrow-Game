using PencilGame;
using UnityEngine;

public class FPSController : PerssistanService<FPSController>
{
    protected override void Awake()
    {
        base.Awake();

        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }
}
