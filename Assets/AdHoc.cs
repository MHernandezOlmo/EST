using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdHoc : MonoBehaviour
{
    void Awake()
    {
        GameProgressController.LomnickyTornadoSkill  = true ;
        GameProgressController.LomnickyFuse  = true ;
        GameProgressController.LomnickyMotor  = true ;
        GameProgressController.LomnickyClosedCeiling  = true ;
        GameProgressController.LomnickyCountdown  = true ;
        GameProgressController.LomnickyPuzzleFlareHunters  = true;
        GameProgressController.LomnickyRecopiledDataAdvice  = true;
        GameProgressController.LomnickyPuzzleLayers  = true ;
        GameProgressController.LomnickySolved  = true ;
    }

}
