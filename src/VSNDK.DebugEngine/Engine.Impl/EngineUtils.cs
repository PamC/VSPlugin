//* Copyright 2010-2011 Research In Motion Limited.
//*
//* Licensed under the Apache License, Version 2.0 (the "License");
//* you may not use this file except in compliance with the License.
//* You may obtain a copy of the License at
//*
//* http://www.apache.org/licenses/LICENSE-2.0
//*
//* Unless required by applicable law or agreed to in writing, software
//* distributed under the License is distributed on an "AS IS" BASIS,
//* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//* See the License for the specific language governing permissions and
//* limitations under the License.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Debugger.Interop;
using System.Diagnostics;
using System.Globalization;

namespace VSNDK.DebugEngine
{
    /// <summary>
    /// Some utilities used in VSNDK debug engine projects.
    /// </summary>
    public static class EngineUtils
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hr"> An integer value. </param>
        public static void RequireOk(int hr)
        {
            if (hr != 0)
            {
                throw new InvalidOperationException();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"> Exception. </param>
        /// <returns> VSConstants.E_NOTIMPL. </returns>
        public static int UnexpectedException(Exception e)
        {
            Debug.Fail("Unexpected exception:" + e);
            return VSConstants.E_NOTIMPL;
        }
    }
}
