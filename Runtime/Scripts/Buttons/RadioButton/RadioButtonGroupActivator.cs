using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Interaction;
using System.Linq;

[RequireComponent(typeof(RadioButtonGroup))]
public class RadioButtonGroupActivator : MonoBehaviour
{
    RadioButtonGroup _group;
    RadioButtonGroup group { get => _group == null ? _group = GetComponent<RadioButtonGroup>() : _group; }

    [Tooltip("Enter numbers with spaces between them. When you select button with these tokens it will activate object if tokens not found target will be deactivated")]
    public string tokens;

    public GameObject target;

    int[] activeTokens
    {
        get
        {
            return tokens.Split(new char[] { ' ' })
            .Select(s =>
            {
                int i = 0;
                int.TryParse(s, out i);
                return i;
            })
            .ToArray();
        }
    }

    private void OnEnable()
    {
        group.onChange.AddListener(OnChange);
    }
    private void OnDisable()
    {
        group.onChange.RemoveListener(OnChange);
    }

    public void OnChange(int token)
    {
        bool isFound = false;

        foreach( var t in activeTokens)
        {
            if(t == token)
            {
                isFound = true;
            }
        }

        if (isFound)
        {
            target.SetActive(true);
        }
        else
        {
            target.SetActive(false);
        }
    }
}

