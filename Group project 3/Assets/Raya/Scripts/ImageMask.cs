using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageMask : Image
{
    public override Material materialForRendering
    {
        get
        {
            Material result = base.materialForRendering;
            result.SetInt("_StencilComp", (int)UnityEngine.Rendering.CompareFunction.NotEqual);
            return result;
        }
    }
}