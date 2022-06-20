using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Clase estática que contiene los distintos eventos que pueden lanzarse en el juego
public static class GameEvents
{

    /**** Ejemplo de evento sin parámetros
     *
     * 
     * public static UnityEvent [[EventName]] = new UnityEvent();
     * 
     */

    /**** Ejemplo de evento con parámetros específicos
     * 
     * 
     * 1 --> Creo la clase a la que pertenecerá el evento
     * 
     * public class [[MyEventType]] : UnityEvent<[[param_type]]>
     * 
     * 2 --> Creo el evento
     * 
     * public static [[MyEventType]] [[EventName]] = new [[MyEventType]]();
     * 
     */

    /**** Ejemplo de evento con parámetros especificados por una clase
     * 
     * 
     * 1 --> Creo la clase que contendrá los parámetros
     * 
     * public class [[MyEventType]]Data 
     * {
     * 
     *     int _param1;
     *     float _param2;
     *     
     *     public [[MyEventType]]Data(int param1, float param2)
     *     {
     *         _param1 = param1;
     *         _param2 = param2;
     *     }
     * }
     * 
     * 2 --> Creo la clase a la que pertenecerá el evento
     * 
     * public class [[MyEventType]] : UnityEvent<[[MyEventType]]Data>{};
     * 
     * 
     * 3 --> Creo el evento
     * 
     * public static [[MyEventType]] [[EventName]] = new [[MyEventType]]();
     * 
     */

    public static BoolEvent CombatEvent = new BoolEvent();
    public static StringEvent LoadScene =  new StringEvent();
    public static StringEvent LoadSceneAsync = new StringEvent();
    public static StringEvent OnLoadSceneMoment = new StringEvent();
    public static BoolEvent eDialogue = new BoolEvent();
    public static IntEvent ShowDialog = new IntEvent();
    public static StringEvent ShowScreenText = new StringEvent();
    public static GameStateChange ChangeGameState = new GameStateChange();
    public static BoolEvent ToggleSFX = new BoolEvent();
    public static BoolEvent ToggleOST = new BoolEvent();
    public static BoolEvent CanInteract = new BoolEvent();



    public class StringEvent : UnityEvent<string> { };
    public class StringListEvent : UnityEvent<List<string>> { };
    public class IntEvent : UnityEvent<int> { };

    public class GameStateChange : UnityEvent<GameStates> { };
    public class BoolEvent : UnityEvent<bool> { };
}
