﻿//
// DotNetCoreDebuggerLocationPanel.cs
//
// Author:
//       Matt Ward <matt.ward@microsoft.com>
//       Lex Li <support@lextm.com>
//
// Copyright (c) 2018 Microsoft
// Copyright (c) 2019 LeXtudio Inc. (http://www.lextudio.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.


using System;
using System.Linq;
using System.Threading.Tasks;
using MonoDevelop.Components;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui.Dialogs;
using MonoDevelop.Projects;

namespace MonoDevelop.Debugger.DotNetCore.Gui
{
    public class DotNetCoreDebuggerLocationPanel : OptionsPanel
    {
        DotNetCoreDebuggerLocationWidget widget;

        public override Control CreatePanelWidget()
        {
            widget = new DotNetCoreDebuggerLocationWidget(this);
            return widget.ToGtkWidget();
        }

        public FilePath LoadDebuggerLocationSetting()
        {
            return DotNetCoreDebuggerRuntime.FileName;
        }

        public void SaveDebuggerLocationSetting(FilePath location)
        {
            if (location == DotNetCoreDebuggerRuntime.FileName)
            {
                return;
            }

            var path = new DotNetCoreDebuggerPath(location);

            DotNetCoreDebuggerRuntime.Update(path);
        }

        public DotNetCoreDebuggerPath DotNetCoreDebuggerPath { get; private set; }

        public void ValidateDebuggerLocation(FilePath location)
        {
            if (!location.IsNullOrEmpty)
            {
                DotNetCoreDebuggerPath = new DotNetCoreDebuggerPath(location);
            }
            else
            {
                DotNetCoreDebuggerPath = null;
            }
        }

        public override void ApplyChanges()
        {
            widget.ApplyChanges();
        }
    }
}
