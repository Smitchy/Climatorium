using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Prefabs.Interactions.Interactables;
using VRTK.Prefabs.Interactions.Interactors;
using Zinnia.Data.Collection.List;
using Zinnia.Tracking.Collision.Active;

public class ActionTrigger : MonoBehaviour
{

    private List<InteractableFacade> interactableFacades = new List<InteractableFacade>();

    public void ObjectAction()
    {
        if (interactableFacades.Count > 0)
        {
            foreach(InteractableFacade interactor in interactableFacades)
            {
                interactor.gameObject.GetComponent<IAction>().DoAction();
            }
        }
    }

    public void AddInteractor(InteractableFacade interactor)
    {
        interactableFacades.Add(interactor);
    }

    public void RemovedeInteractor(InteractableFacade interactor)
    {
        interactableFacades.Remove(interactor);
    }
}
