﻿using Core;
using System;
using System.Windows;
using Verse3;
using Verse3.VanillaElements;

namespace EventsLibrary
{
    public class DateTimePicker : BaseComp
    {
        internal DateTime? _value = DateTime.Now;
        //private double _inputValue = 0.0;


        
        #region Constructors

        public DateTimePicker() : base()
        {
        }

        public DateTimePicker(int x, int y) : base(x, y)
        {
        }

        #endregion


        public override CompInfo GetCompInfo() => new CompInfo(this, "DateTime Picker", "Basic UI", "DateTime");

        
        internal DateTimeElement dateTimeElement = new DateTimeElement();
        internal DateTimeDataNode nodeBlock;
        internal GenericEventNode nodeBlock1;
        public override void Initialize()
        {
            base.titleTextBlock.TextRotation = 0;

            nodeBlock1 = new GenericEventNode(this, NodeType.Output);
            this.ChildElementManager.AddEventOutputNode(nodeBlock1, "Changed");

            nodeBlock = new DateTimeDataNode(this, NodeType.Output);
            this.ChildElementManager.AddDataOutputNode(nodeBlock, "DateTime");
            
            dateTimeElement = new DateTimeElement();
            dateTimeElement.Value = _value;
            dateTimeElement.DisplayedText = dateTimeElement.Value.ToString();
            dateTimeElement.DateTimeChanged += DateTimeElement_DateTimeChanged;
            dateTimeElement.Width = 200;
            this.ChildElementManager.AddElement(dateTimeElement);
        }

        public override void Compute()
        {
            //_value = toggleBlock.Value;
            if (_value.HasValue)
            {
                this.ChildElementManager.SetData(_value.Value, nodeBlock);
                dateTimeElement.DisplayedText = dateTimeElement.Value.ToString();
            }
        }

        private void DateTimeElement_DateTimeChanged(object? sender, RoutedEventArgs e)
        {
            _value = dateTimeElement.Value;
            ComputationCore.Compute(this, false);
            this.ChildElementManager.EventOccured(nodeBlock1, new EventArgData(new DataStructure(_value)));
        }
    }
}
