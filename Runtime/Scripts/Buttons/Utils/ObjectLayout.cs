using EasyButtons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Interaction
{
    public class ObjectLayout : MonoBehaviour
    {
        public List<GameObject> objects;
        public float space = 0.2f;

        public enum Axis { x, y, z };

        public Axis axis;

        [Button]
        public void Layout()
        {
            if (objects.Count == 0) objects = GetAllChilds();
            Vector3 t = Vector3.zero;
            int i = 0;
            foreach (var obj in objects)
            {
                t = i == 0 ? obj.transform.localPosition : t;
                float x = axis != Axis.x ? t.x : t.x + i * space;
                float y = axis != Axis.y ? t.y : t.y + i * space;
                float z = axis != Axis.z ? t.z : t.z + i * space;

                obj.transform.localPosition = new Vector3(x, y, z);
                i++;
            }
        }

        public List<GameObject> GetAllChilds()
        {
            List<GameObject> list = new List<GameObject>();
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                list.Add(gameObject.transform.GetChild(i).gameObject);
            }
            return list;
        }
    }
}