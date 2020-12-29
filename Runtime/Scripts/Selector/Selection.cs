using Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Interaction
{
    public class Selection : Selector
    {

        public override void Select(GameObject curHitObj)
        {
            var receiver = curHitObj.GetComponent<ISelectionReceiver>();
            if (receiver != null && receiver.isLockSelection) return;

            var curSelectable = curHitObj.GetComponent<ISelectable>();

            if (curSelectable != null) // if hit interactable
            {
                if (curSelectable == selectable) // if hit the same object 
                {
                    return;
                }
                else if (selectable != null) // if hit interactable before
                {
                    selectable.OnExit();
                    UpdateTarget(curHitObj, curSelectable);
                    return;
                }
                else // hit new object
                {
                    UpdateTarget(curHitObj, curSelectable);
                    return;
                }
            }
            else // hit not interactable
            {
                if (selectable != null)  // if hit interactable before
                {
                    Release();
                    return;
                }
            }
        }

        public void UpdateTarget(GameObject curHitObj, ISelectable curSelectable)
        {
            selectable = curSelectable;
            selectedObject = curHitObj;
            selectable.OnEnter();
            onObjSelect?.Invoke(curHitObj);
        }

        public override void Release()
        {
            if (selectable == null) return;

            if (selectedObject != null)
            {
                var r = selectedObject.GetComponent<ISelectionReceiver>();
                if (r != null && (r.isKeepSelectionOnLost || r.isLockSelection)) return;
            }

            selectable.OnExit();
            selectable = null;
            selectedObject = null;
            onObjRelease?.Invoke();
        }
    }
}