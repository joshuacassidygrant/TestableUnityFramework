﻿using System.Collections;
using System.Collections.Generic;
using TofuConfig;
using TofuCore.Events;
using TofuCore.Player;
using TofuCore.ResourceModule;
using TofuPlugin.UI;
using UnityEngine;
using UnityEngine.UI;

public class UIResourceModuleVialDisplay : TofuUiBase
{
    public EventKey EventKey;
    public int OwnerGlopId;
    public IResourceModule Module;

    public Transform Inner;
    public Image Fill;
    private Material InnerMaterial;
    public float MaxScale;

    private void Start()
    {
        if (EventKey != EventKey.None)
        {
            BindServiceContext();
            BindEventListener();
        }
        Fill = Inner.gameObject.GetComponent<Image>();

    }

    public void InitializeDisplay(IResourceModule module)
    {
        Module = module;
        OwnerGlopId = module.Owner.Id;
        InnerMaterial = Inner.GetComponent<MeshRenderer>().material;
        Rerender(module.Percent);
        InnerMaterial.color = module.BaseColor;
        InnerMaterial.SetColor("_Emissive", module.GlowColor);
        InnerMaterial.SetColor("_SecondaryColor", module.SecondaryColor);
        /*Material mat = module.LoadMaterial();
        if (mat != null)
        {
            Inner.gameObject.GetComponent<MeshRenderer>().material = mat;
        }
        else
        {
            Debug.Log("Couldn't find material");
        }*/
    }

    private void BindEventListener()
    {
        BindListener(EventContext.GetEvent(EventKey), OnReceiveUpdate, EventContext);
    }

    private void OnReceiveUpdate(EventPayload payload)
    {
        if (payload.ContentType != "ResourceStateEventPayload") return;
        ResourceStateEventPayload resourceState = payload.GetContent();
        if (resourceState.Target.Id != OwnerGlopId) return;

        float percent = (float)resourceState.Amount / resourceState.Max;
        Rerender(percent);
    }

    private void Rerender(float percent)
    {
        if (Inner != null)
        {
            percent = Mathf.Min(1f, percent);
            InnerMaterial?.SetFloat("_Fullness", percent);
            

            if (Fill != null)
            {
                Fill.fillAmount = percent;
            }
            //Inner.localScale = new Vector3(Inner.localScale.x, Inner.localScale.y, MaxScale * percent);

        }

    }
}
