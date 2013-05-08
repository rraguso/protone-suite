#region Copyright © 2008 OPMedia Research
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	ControlGauge.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using OPMedia.UI.Generic;
using OPMedia.UI.Controls;
#endregion

namespace OPMedia.UI.Controls
{
    #region Delegates
    public delegate void CellStateChangedEventHandler(int x, int y, ControlGrid.CellState state);
    #endregion

    public partial class ControlGrid : DoubleBufferedControl
    {
        public class CellState
        {
            protected int _state = 0; // CellState.Off
            public static readonly CellState On = new CellState(1);
            public static readonly CellState Off = new CellState(0);

            protected CellState(int state)
            {
                _state = state;
            }

            public CellState()
            {
            }

            public bool IsOff
            {
                get
                {
                    return (_state == 0);
                }
            }
        }

        #region Controls
        public event CellStateChangedEventHandler CellStateChanged = null;
        #endregion

        #region Members
        protected int _max = 50;
        private CellState[] _cellStates = null;
        private Timer _tmrUpdate; 

        protected int _sizeX = 10;
        protected int _sizeY = 10;

        protected Color _offColor = Color.LightGray;
        protected Color _onColor = Color.Gray;
        protected CellState _projState = CellState.On;

        List<int> _updatedCellsIndexes = new List<int>();

        #endregion

        #region Properties
        public int SizeX
        { get { return _sizeX; } set { UpdateValue(ref _sizeX, value); } }

        public int SizeY
        { get { return _sizeY; } set { UpdateValue(ref _sizeY, value); } }

        public Color OffColor
        { get { return _offColor; } set { _offColor = value; Invalidate(true); } }

        public Color OnColor
        { get { return _onColor; } set { _onColor = value; Invalidate(true); } }

        public CellState ProjectedCellState
        { get { return _projState; } set { _projState = value; } }

        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }

            set
            {
                base.Enabled = value;
            }
        }
        #endregion

        #region Construction
        public ControlGrid()
        {
            _cellStates = new CellState[_max * _max];
            ResetCellStates();
            
            _tmrUpdate = new Timer();
            _tmrUpdate.Interval = 100;
            _tmrUpdate.Enabled = false;
            _tmrUpdate.Tick += new EventHandler(_tmrUpdate_Tick);

            this.MouseUp += new MouseEventHandler(ControlGrid_MouseUp);
            this.MouseMove += new MouseEventHandler(ControlGrid_MouseMove);
        }

        void _tmrUpdate_Tick(object sender, EventArgs e)
        {
            _tmrUpdate.Enabled = false;
        }
        #endregion

        #region Event Handlers
        void ControlGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (base.Enabled && e.Button == MouseButtons.Left)
            {
                UpdateGrid(e);
            }
        }

        void ControlGrid_MouseUp(object sender, MouseEventArgs e)
        {
            if (base.Enabled)
            {
                UpdateGrid(e);
            }

            _updatedCellsIndexes.Clear();
        }
        #endregion

        #region Implementation
        public void ResetCellStates()
        {
            for (int i = 0; i < _cellStates.Length; i++)
            {
                _cellStates[i] = CellState.Off;
            }
            Invalidate(true);
        }

        public void SetCellStates(CellState[] cellStates)
        {
            _cellStates = cellStates;
            Invalidate(true);
        }

        public void SetCellState(int x, int y, CellState cellState)
        {
            SetCellState(y * _sizeX + x, cellState);
        }

        public void SetCellState(int cellIndex, CellState cellState)
        {
            CellState state = _cellStates[cellIndex];
            _cellStates[cellIndex] = cellState;
            Invalidate(true);
        }

        private void UpdateGrid(MouseEventArgs e)
        {
            int x = (e.X * _sizeX) / Width;
            int y = (e.Y * _sizeY) / Height;
            int cellIndex = y * _sizeX + x;

            if (!_updatedCellsIndexes.Contains(cellIndex))
            {
                _updatedCellsIndexes.Add(cellIndex);
                SetCellState(cellIndex, _projState);
            }
        }

        private void UpdateValue(ref int val, int newVal)
        {
            if (newVal < 1)
            {
                newVal = 1;
            }
            if (newVal > _max)
            {
                newVal = _max;
            }

            if (val != newVal)
            {
                val = newVal;
                Invalidate(true);
            } 
        }

        protected override void DrawControl(Graphics g)
        {
            int cellWidth = this.Width / _sizeX;
            int cellHeight = this.Height / _sizeY;

            // Draw cell by cell
            for (int x = 0; x < _sizeX; x++)
            {
                for (int y = 0; y < _sizeY; y++)
                {
                    // Determine cell coordinates
                    int left = x * cellWidth;
                    int top = y * cellHeight;
                    int right = left + cellWidth;
                    int bottom = top + cellHeight;

                    ControlPaint.DrawBorder(g, new Rectangle(left, top, cellWidth + 1, cellHeight + 1),
                       ThemeManager.BorderColor, ButtonBorderStyle.Solid);

                    // Determine cell state
                    int cellIndex = y*_sizeX + x;
                    CellState cellState = _cellStates[cellIndex];

                    Rectangle rcInside = new Rectangle(left + 1, top + 1, cellWidth-1, cellHeight-1);
                    SolidBrush br = new SolidBrush((cellState.IsOff) ? Color.Gray : Color.LightGray);

                    g.FillRectangle(br, rcInside);
                }
            }
        }
        #endregion
    }
}

#region ChangeLog
#region Date: 27.02.2008			Author: Octavian Paraschiv
// File created.
#endregion
#endregion