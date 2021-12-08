using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaFiltro : Interactable
{
    [SerializeField]
    int _pieza;
    bool _checked;

    public override void Interact()
    {
        GameProgressController.SetFiltro(_pieza, true);
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        GameEvents.ShowScreenText.Invoke("Obtenido: Filtro");
        Destroy(transform.root.gameObject);
    }
    private void Start()
    {
        base.Start();
    }
    private void Update()
    {
        if (!_checked)
        {
            _checked = true;
            if (!GameProgressController.IsPanelFixed())
            {
                FindObjectOfType<InteractablesController>().RemoveInteractable(this);
                Destroy(transform.root.gameObject);
            }
            else
            {
                if (GameProgressController.GetFiltro(_pieza))
                {
                    FindObjectOfType<InteractablesController>().RemoveInteractable(this);
                    Destroy(transform.root.gameObject);
                }
            }
        }
    }
}
