﻿using Core;
using System;
using System.Windows;
using Verse3;
using Verse3.VanillaElements;

namespace MathLibrary
{
    public class OrGate : BaseComp
    {

        

        #region Constructors

        public OrGate() : base()
        {
        }

        public OrGate(int x, int y) : base(x, y)
        {
        }

        #endregion

        public override CompInfo GetCompInfo() => new CompInfo(this, "OR Gate", "Gates", "Boolean");

        public override void Compute()
        {
            bool a = this.ChildElementManager.GetData<bool>(nodeBlock, false);
            bool b = this.ChildElementManager.GetData<bool>(nodeBlock1, false);
            this.ChildElementManager.SetData<bool>((a || b), nodeBlock2);
        }
        
        private BooleanDataNode nodeBlock;
        private BooleanDataNode nodeBlock1;
        private BooleanDataNode nodeBlock2;
        public override void Initialize()
        {
            nodeBlock = new BooleanDataNode(this, NodeType.Input);
            this.ChildElementManager.AddDataInputNode(nodeBlock, "A");

            nodeBlock1 = new BooleanDataNode(this, NodeType.Input);
            this.ChildElementManager.AddDataInputNode(nodeBlock1, "B");

            nodeBlock2 = new BooleanDataNode(this, NodeType.Output);
            this.ChildElementManager.AddDataOutputNode(nodeBlock2, "Result", true);
        }
    }
}
