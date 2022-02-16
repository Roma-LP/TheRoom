using UnityEngine;

public class ArrayElementTitleAttribute : PropertyAttribute
{
    public string[] Varname;

    public ArrayElementTitleAttribute(params string[] ElementTitleVar) => Varname = ElementTitleVar;
}
