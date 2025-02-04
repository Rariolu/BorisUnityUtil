﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace UbiUnity.UI
{
    /// <summary>
    /// A delegate method which represents a "UIButton"
    /// instance being clicked.
    /// </summary>
    /// <param name="sender"></param>
    public delegate void UIButtonClick(UIButton sender);

    /// <summary>
    /// Class which represents a clickable UI object
    /// (an alternative to using Unity's "UnityEngine.UI.Button").
    /// </summary>
    //[RequireComponent(typeof(Image))]
    public class UIButton : MonoBehaviour
    {
        /// <summary>
        /// After assigning an event handler to this
        /// delegate, it will be called whenever this
        /// UI button is clicked.
        /// </summary>
        public UIButtonClick Click;
        Image image;
        public Image Image
        {
            get
            {
                return image ?? (image = GetComponent<Image>());
            }
        }
        // Start is called before the first frame update
        protected virtual void Start()
        {
            EventTrigger eventTrigger = gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener((data) =>
            {
                if (Click != null)
                {
                    Click(this);
                }
                else
                {
                    Debug.LogFormat("{0} click event was null.", gameObject.name);
                }
            });
            eventTrigger.triggers.Add(entry);
        }
    }
}
