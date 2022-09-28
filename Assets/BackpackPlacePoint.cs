using System;
using System.Collections;
using System.Collections.Generic;
using Autohand;
using UnityEngine;

public class BackpackPlacePoint : PlacePoint
{
    public override void Place(Grabbable placeObj)
    {
        base.Place(placeObj);
        placeObj.transform.parent = transform;
    }

    public override void Remove(Grabbable placeObj)
    {
        base.Remove(placeObj);
        placeObj.transform.parent = null;
    }
}
