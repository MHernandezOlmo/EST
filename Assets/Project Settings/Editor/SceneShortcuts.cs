using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneShortcuts : MonoBehaviour
{
    [MenuItem("Scenes/Configuration")]
    public static void OpenConfiguration()
    {
        LoadScene("Configuration");
    }

    [MenuItem("Scenes/MainMenu")]
    public static void OpenLore()
    {
        LoadScene("MainMenu");
    }

    [MenuItem("Scenes/Cinematic")]
    public static void OpenCinematic()
    {
        LoadScene("Cinematic");
    }

    [MenuItem("Scenes/Loading")]
    public static void OpenLoading()
    {
        LoadScene("Loading");
    }

    [MenuItem("Scenes/WorldSelector")]
    public static void OpenWorldSelector()
    {
        LoadScene("WorldSelector");
    }


    //LOMNICKY

    [MenuItem("Scenes/Worlds/Lomnicky/0-->LLegada de UV")]
    public static void OpenLlegadaDeUV()
    {
        LoadScene("Worlds/Lomnicky/Lomnicky_0_Llegada de UV");
    }
    [MenuItem("Scenes/Worlds/Lomnicky/1-->Estación teleférico")]
    public static void OpenEstacionTeleferico()
    {
        LoadScene("Worlds/Lomnicky/Lomnicky_1_Estacion teleferico");
    }

    [MenuItem("Scenes/Worlds/Lomnicky/2-->Sala LLegada")]
    public static void OpenSalaLlegada()
    {
        LoadScene("Worlds/Lomnicky/Lomnicky_2_Sala llegada");
    }
    [MenuItem("Scenes/Worlds/Lomnicky/3-->Sala contigua")]
    public static void OpenSalaContigua()
    {
        LoadScene("Worlds/Lomnicky/Lomnicky_3_Sala contigua");
    }
    [MenuItem("Scenes/Worlds/Lomnicky/4-->Sala Combate")]
    public static void OpenSalaCombate()
    {
        LoadScene("Worlds/Lomnicky/Lomnicky_4_Sala Combate");
    }

    [MenuItem("Scenes/Worlds/Lomnicky/5-->Sala Archivo")]
    public static void OpenSalaArchivo()
    {
        LoadScene("Worlds/Lomnicky/Lomnicky_5_Sala archivo");
    }
    [MenuItem("Scenes/Worlds/Lomnicky/6-->Sala Observacion SST")]
    public static void OpenSalaObservacion()
    {
        LoadScene("Worlds/Lomnicky/Lomnicky_6_Sala Observacion SST");
    }

    [MenuItem("Scenes/Worlds/Lomnicky/7-->Sala Escaleras")]
    public static void OpenSalaEscaleras()
    {
        LoadScene("Worlds/Lomnicky/Lomnicky_7_Sala escaleras");
    }

    [MenuItem("Scenes/Worlds/Lomnicky/8-->Sala Principal")]
    public static void OpenSalaPrincipal()
    {
        LoadScene("Worlds/Lomnicky/Lomnicky_8_Sala Principal");
    }
    [MenuItem("Scenes/Worlds/Lomnicky/9-->Sala Paso Azotea")]
    public static void OpenSalaPasoAzotea()
    {
        LoadScene("Worlds/Lomnicky/Lomnicky_9_Sala Paso Azotea");
    }
    [MenuItem("Scenes/Worlds/Lomnicky/10-->Azotea")]
    public static void OpenSalaAzotea()
    {
        LoadScene("Worlds/Lomnicky/Lomnicky_10_Azotea");
    }
    [MenuItem("Scenes/Worlds/Lomnicky/11-->Cúpula")]
    public static void OpenSalaCupula()
    {
        LoadScene("Worlds/Lomnicky/Lomnicky_11_Sala Cupula");
    }
    [MenuItem("Scenes/Worlds/Lomnicky/12-->Sala Secreta")]
    public static void OpenSalaSecreta()
    {
        LoadScene("Worlds/Lomnicky/Lomnicky_12_Sala Secreta");
    }

    //PicDuMidi

    [MenuItem("Scenes/Worlds/PicDuMidi/0-->Sala Paneles A C")]
    public static void OpenSalaPanelesAC()
    {
        LoadScene("Worlds/PicDuMidi/PicDuMidi_0_sala_paneles_a_c");
    }

    [MenuItem("Scenes/Worlds/PicDuMidi/1-->Puente Roto")]
    public static void OpenPuenteRoto()
    {
        LoadScene("Worlds/PicDuMidi/PicDuMidi_1_puente_roto");
    }

    [MenuItem("Scenes/Worlds/PicDuMidi/2-->Terraza Antena ")]
    public static void OpenTerrazaAntena()
    {
        LoadScene("Worlds/PicDuMidi/PicDuMidi_2_terraza_antena");
    }

    [MenuItem("Scenes/Worlds/PicDuMidi/3-->SalaHabilidad")]
    public static void OpenSalaHabilidad()
    {
        LoadScene("Worlds/PicDuMidi/PicDuMidi_3_sala_habilidad");
    }

    [MenuItem("Scenes/Worlds/PicDuMidi/4-->Zona Torreta")]
    public static void OpenZonaTorreta()
    {
        LoadScene("Worlds/PicDuMidi/PicDuMidi_4_zona_torreta");
    }

    [MenuItem("Scenes/Worlds/PicDuMidi/5-->Patio")]
    public static void OpenPatio()
    {
        LoadScene("Worlds/PicDuMidi/PicDuMidi_5_patio");
    }

    [MenuItem("Scenes/Worlds/PicDuMidi/6-->Sala Pieza D")]
    public static void OpenSalaPiezD()
    {
        LoadScene("Worlds/PicDuMidi/PicDuMidi_6_pieza_d");
    }

    [MenuItem("Scenes/Worlds/PicDuMidi/7-->Sotano Acceso Central")]
    public static void OpenSotanoaccesoCentral()
    {
        LoadScene("Worlds/PicDuMidi/PicDuMidi_7_sotano_acceso_central");
    }

    [MenuItem("Scenes/Worlds/PicDuMidi/8-->Exterior JeanRock")]
    public static void OpenExteriorJeanRock()
    {
        LoadScene("Worlds/PicDuMidi/PicDuMidi_8_exterior_jeanrock");
    }

    [MenuItem("Scenes/Worlds/PicDuMidi/9-->Sala Paneles D")]
    public static void OpenSalaPanelesD()
    {
        LoadScene("Worlds/PicDuMidi/PicDuMidi_9_paneles_d");
    }

    [MenuItem("Scenes/Worlds/PicDuMidi/10-->Sala A")]
    public static void OpenSalaA()
    {
        LoadScene("Worlds/PicDuMidi/PicDuMidi_10_sala_a");
    }

    [MenuItem("Scenes/Worlds/PicDuMidi/11-->DistribuidorSotano")]
    public static void OpenDistribuidorSotano()
    {
        LoadScene("Worlds/PicDuMidi/PicDuMidi_11_distribuidor_sotano");
    }

    [MenuItem("Scenes/Worlds/PicDuMidi/12-->Laberinto Sotano")]
    public static void OpenLaberintoSotano()
    {
        LoadScene("Worlds/PicDuMidi/PicDuMidi_12_laberinto_sotano");
    }

    [MenuItem("Scenes/Worlds/PicDuMidi/13-->Laboratorio")]
    public static void OpenLaboratorio()
    {
        LoadScene("Worlds/PicDuMidi/PicDuMidi_13_laboratory");
    }

    //EINSTEIN
    [MenuItem("Scenes/Worlds/Einstein/0-->Alrededores torre")]
    public static void OpenEinsteinAlrededoresTorre()
    {
        LoadScene("Worlds/Einstein/Einstein_0_alrededores_torre");
    }

    [MenuItem("Scenes/Worlds/Einstein/1-->Planta 0 Hall")]
    public static void OpenEinsteinPlanta0Hall()
    {
        LoadScene("Worlds/Einstein/Einstein_1_planta_0_hall");
    }

    [MenuItem("Scenes/Worlds/Einstein/2-->Planta 1")]
    public static void OpenEinsteinPlanta1()
    {
        LoadScene("Worlds/Einstein/Einstein_2_planta_1");
    }
    [MenuItem("Scenes/Worlds/Einstein/3-->Planta 1 Sala Archivo")]
    public static void OpenEinsteinPlanta1Archivo()
    {
        LoadScene("Worlds/Einstein/Einstein_3_planta_1_sala_archivo");
    }

    [MenuItem("Scenes/Worlds/Einstein/4-->Planta 2 Cúpula")]
    public static void OpenEinteinPlanta2Cupula()
    {
        LoadScene("Worlds/Einstein/Einstein_4_planta_2_cupula");
    }

    [MenuItem("Scenes/Worlds/Einstein/5-->Planta -1 Sótano")]
    public static void OpenEinsteinPlantaMenos1Sotano()
    {
        LoadScene("Worlds/Einstein/Einstein_5_planta_-1_sotano");
    }
    [MenuItem("Scenes/Worlds/Einstein/6-->Planta -1 Sala del Espectropolarímetro")]
    public static void OpenEinsteinPlantaMenos1Espectopolarimetro()
    {
        LoadScene("Worlds/Einstein/Einstein_6_planta-1_sala_del_espectropolarimetro");
    }

    [MenuItem("Scenes/Worlds/Einstein/7-->Planta 0 Almacén")]
    public static void OpenEinteinPlanta0Almacen()
    {
        LoadScene("Worlds/Einstein/Einstein_7_planta_0_almacen");
    }

    //SST
    [MenuItem("Scenes/Worlds/SST/0-->Residencia Roque")]
    public static void OpenSSTResidenciaRoque()
    {
        LoadScene("Worlds/SST/SST_0_residencia_roque");
    }

    [MenuItem("Scenes/Worlds/SST/1-->Exterior")]
    public static void OpenSSTExterior()
    {
        LoadScene("Worlds/SST/SST_1_exterior");
    }

    [MenuItem("Scenes/Worlds/SST/2-->Hall")]
    public static void OpenSSTHall()
    {
        LoadScene("Worlds/SST/SST_2_hall");
    }

    [MenuItem("Scenes/Worlds/SST/3-->Sala Máquinas")]
    public static void OpenSSTSalaMaquinas()
    {
        LoadScene("Worlds/SST/SST_3_sala_maquinas");
    }
     
    [MenuItem("Scenes/Worlds/SST/4-->Sala Observación")]
    public static void OpenSSTObservacion()
    {
        LoadScene("Worlds/SST/SST_4_sala_observacion");
    }

    [MenuItem("Scenes/Worlds/SST/5-->Cúpula")]
    public static void OpenSSTCupula()
    {
        LoadScene("Worlds/SST/SST_5_cupula");
    }
    [MenuItem("Scenes/Worlds/SST/6-->Laboratorio Pic du Midi")]
    public static void OpenSSTLaboratorioPicDuMidi()
    {
        LoadScene("Worlds/SST/SST_PicDuMidi_13_laboratory");
    }
    //GREGOR
    [MenuItem("Scenes/Worlds/Gregor/0-->Exterior")]
    public static void OpenGregorExterior()
    {
        LoadScene("Worlds/Gregor/Gregor_0_exterior");
    }

    [MenuItem("Scenes/Worlds/Gregor/1-->Base")]
    public static void OpenGregorSotano()
    {
        LoadScene("Worlds/Gregor/Gregor_1_sotano");
    }

    [MenuItem("Scenes/Worlds/Gregor/2-->Laseres")]
    public static void OpenGregorBase()
    {
        LoadScene("Worlds/Gregor/Gregor_2_laseres");
    }

    [MenuItem("Scenes/Worlds/Gregor/3-->Acuaticas 1")]
    public static void OpenGregorAcuaticas1()
    {
        LoadScene("Worlds/Einstein/Gregor_3_acuaticas");
    }

    //EST
    [MenuItem("Scenes/Worlds/EST/0-->Exteriores")]
    public static void OpenESTExteriores()
    {
        LoadScene("Worlds/EST/EST_exterior EST");
    }

    [MenuItem("Scenes/Worlds/EST/1-->Hall")]
    public static void OpenESTHall()
    {
        LoadScene("Worlds/EST/EST_hall");
    }

    [MenuItem("Scenes/Worlds/EST/2-->Galería")]
    public static void OpenESTGaleria()
    {
        LoadScene("Worlds/EST/EST_Galeria");
    }

    [MenuItem("Scenes/Worlds/EST/3-->PrimeraPlanta")]
    public static void OpenESTPrimeraPlanta()
    {
        LoadScene("Worlds/EST/EST_PrimeraPlanta");
    }

    [MenuItem("Scenes/Worlds/EST/4-->SegundaPlanta")]
    public static void OpenESTSegundaPlanta()
    {
        LoadScene("Worlds/EST/EST_SegundaPlanta");
    }

    [MenuItem("Scenes/Worlds/EST/5-->Cupula")]
    public static void OpenESTCupula()
    {
        LoadScene("Worlds/EST/EST_Cupula");
    }

    [MenuItem("Scenes/Worlds/EST/6-->CalibrarOA")]
    public static void OpenESTCalibrarOA()
    {
        LoadScene("Worlds/EST/EST_CalibrarOA");
    }

    [MenuItem("Scenes/Worlds/EST/7-->HRyAbrirCupula")]
    public static void OpenESTHRyAbrirCupula()
    {
        LoadScene("Worlds/EST/EST_HRyAbrirCupula");
    }

    [MenuItem("Scenes/Worlds/EST/8-->SalaCorrrientesAireM1M2")]
    public static void OpenESTSalaCorrrientesAireM1M2()
    {
        LoadScene("Worlds/EST/EST_SalaCorrrientesAireM1M2");
    }

    [MenuItem("Scenes/Worlds/EST/9-->RefrigeranteM3aM6")]
    public static void OpenESTRefrigeranteM3aM6()
    {
        LoadScene("Worlds/EST/EST_RefrigeranteM3aM6");
    }

    [MenuItem("Scenes/Worlds/EST/10-->SalaGenerador")]
    public static void OpenESTSalaGenerador()
    {
        LoadScene("Worlds/EST/EST_SalaGenerador");
    }


    public static void LoadScene(string name)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) //Si el usuario quiere guardar la escena, guardar
        {
            EditorSceneManager.OpenScene("Assets/Scenes/" + name + ".unity");
        }
    }

    public static void LoadArea(string area)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) //Si el usuario quiere guardar la escena, guardar
        {
            EditorSceneManager.OpenScene("Assets/Scenes/Areas/" + area + ".unity");
        }
    }
}
