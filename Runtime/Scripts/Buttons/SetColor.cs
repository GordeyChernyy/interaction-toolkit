using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Interaction
{
    public class SetColor : MonoBehaviour
    {
        public Color color;

        Color initColor;

        public string colorProperty = "_Color";

        Material _material;
        Material material { get => _material == null ? _material = GetComponent<Renderer>().material : _material; }

        // Start is called before the first frame update
        void Start()
        {
            initColor = color;
            material.SetColor(colorProperty, color);
        }

        public void ToInit()
        {
            material.SetColor(colorProperty, initColor);
        }

        public void ToColor(Color color)
        {
            material.SetColor(colorProperty, color);
        }
    }
}