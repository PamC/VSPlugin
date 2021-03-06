﻿//* Copyright 2010-2011 Research In Motion Limited.
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
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.OLE.Interop;

using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace RIM.VSNDK_Package
{
    /// <summary>
    /// Factory for creating the bar-descriptor editor
    /// </summary>
    [Guid(GuidList.guidVSNDK_PackageEditorFactoryString)]
    public sealed class EditorFactory : IVsEditorFactory, IDisposable
    {
        /// Declare Constants
        public const string defaultExtension = ".xml";

        /// Private Member Variables
        private VSNDK_PackagePackage editorPackage;
        private ServiceProvider vsServiceProvider;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="package"></param>
        public EditorFactory(VSNDK_PackagePackage package)
        {
            /// Set internal member variables
            this.editorPackage = package;
        }

        /// <summary>
        /// Close the factory
        /// </summary>
        /// <returns></returns>
        public int Close()
        {
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Create an instance of the custom editor
        /// </summary>
        /// <param name="grfCreateDoc">Behaviour Flags</param>
        /// <param name="pszMkDocument">Document to be opened.</param>
        /// <param name="pszPhysicalView">Name of the view</param>
        /// <param name="pvHier">Pointer to the IVSHierarchy</param>
        /// <param name="itemid">Item ID for this instance</param>
        /// <param name="punkDocDataExisting">This parameter is used to determine if a document buffer (DocData object) has already been created</param>
        /// <param name="ppunkDocView">Pointer to the IUnknown interface for the DocView object</param>
        /// <param name="ppunkDocData">Pointer to the IUnknown interface for the DocData object</param>
        /// <param name="pbstrEditorCaption">Caption mentioned by the editor for the doc window</param>
        /// <param name="pguidCmdUI">the Command UI Guid. Any UI element that is visible in the editor has to use this GUID. This is specified in the .vsct file</param>
        /// <param name="pgrfCDW">Flags for CreateDocumentWindow</param>
        /// <returns></returns>
        public int CreateEditorInstance(uint grfCreateDoc, string pszMkDocument, string pszPhysicalView, IVsHierarchy pvHier, uint itemid, IntPtr punkDocDataExisting, out IntPtr ppunkDocView, out IntPtr ppunkDocData, out string pbstrEditorCaption, out Guid pguidCmdUI, out int pgrfCDW)
        {
            /// Initialize variables.
            ppunkDocView = IntPtr.Zero;
            ppunkDocData = IntPtr.Zero;
            pguidCmdUI = GuidList.guidVSNDK_PackageEditorFactory;
            pgrfCDW = 0;
            pbstrEditorCaption = null;
            IVsTextLines textBuffer = null;

            /// Validate Inputs
            if ((grfCreateDoc & (VSConstants.CEF_OPENFILE | VSConstants.CEF_SILENT)) == 0)
            {
                return VSConstants.E_INVALIDARG;
            }

            if (punkDocDataExisting == IntPtr.Zero)
            { /// File is not open yet.  Create a new text buffer object.

                /// get the ILocalRegistry interface so we can use it to
                /// create the text buffer from the shell's local registry
                try
                {
                    ILocalRegistry localRegistry = (ILocalRegistry)GetService(typeof(SLocalRegistry));
                    if (localRegistry != null)
                    { /// Successfully created
                        IntPtr ptr;
                        Guid iid = typeof(IVsTextLines).GUID;
                        Guid CLSID_VsTextBuffer = typeof(VsTextBufferClass).GUID;
                        localRegistry.CreateInstance(CLSID_VsTextBuffer, null, ref iid, 1 /*CLSCTX_INPROC_SERVER*/, out ptr);
                        try
                        {
                            textBuffer = Marshal.GetObjectForIUnknown(ptr) as IVsTextLines;
                        }
                        finally
                        {
                            Marshal.Release(ptr); // Release RefCount from CreateInstance call
                        }

                        // It is important to site the TextBuffer object
                        IObjectWithSite objWSite = (IObjectWithSite)textBuffer;
                        if (objWSite != null)
                        {
                            Microsoft.VisualStudio.OLE.Interop.IServiceProvider oleServiceProvider = (Microsoft.VisualStudio.OLE.Interop.IServiceProvider)GetService(typeof(Microsoft.VisualStudio.OLE.Interop.IServiceProvider));
                            objWSite.SetSite(oleServiceProvider);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Can not get IVsCfgProviderEventsHelper" + ex.Message);
                    throw;
                }
            }
            else
            { /// File is already open.  Verify open document is a Text Buffer
               

                /// QI existing buffer for text lines
                textBuffer = Marshal.GetObjectForIUnknown(punkDocDataExisting) as IVsTextLines;
                if (textBuffer == null)
                {
                    return VSConstants.VS_E_INCOMPATIBLEDOCDATA;
                }
            }

            /// Create the Document (editor)
            EditorPane NewEditor = new EditorPane(vsServiceProvider, editorPackage, pszMkDocument, textBuffer);
            ppunkDocView = Marshal.GetIUnknownForObject(NewEditor);
            ppunkDocData = Marshal.GetIUnknownForObject(textBuffer);
            pbstrEditorCaption = "";
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Private function to return the required service.
        /// </summary>
        /// <param name="type">Service Type</param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return vsServiceProvider.GetService(serviceType);
        }

        /// <summary>
        /// This method is called by the Environment (inside IVsUIShellOpenDocument::
        /// OpenStandardEditor and OpenSpecificEditor) to map a LOGICAL view to a 
        /// PHYSICAL view.
        /// </summary>
        /// <param name="rguidLogicalView"></param>
        /// <param name="pbstrPhysicalView"></param>
        /// <returns></returns>
        public int MapLogicalView(ref Guid rguidLogicalView, out string pbstrPhysicalView)
        {
            /// Initialize our parameter
            pbstrPhysicalView = null;    

            /// we support only a single physical view
            if (VSConstants.LOGVIEWID_Primary == rguidLogicalView)
            { /// primary view uses NULL as pbstrPhysicalView
                return VSConstants.S_OK;        
            }
            else
            { /// you must return E_NOTIMPL for any unrecognized rguidLogicalView values
                return VSConstants.E_NOTIMPL;
            } 
        }

        /// <summary>
        /// Used for initialization of the editor in the environment
        /// </summary>
        /// <param name="psp">pointer to the service provider. Can be used to obtain instances of other interfaces</param>
        /// <returns></returns>
        public int SetSite(IOleServiceProvider psp)
        {
            vsServiceProvider = new ServiceProvider(psp);
            return VSConstants.S_OK;
        }

        /// <summary>
        /// IDisposable Constructor
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// IDisposable Constructor Override
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            lock (this)
            {
                if (disposing)
                { ///dispose all managed and unmanaged resources
                    if (vsServiceProvider != null)
                    {
                        vsServiceProvider.Dispose();
                        vsServiceProvider = null;
                    }
                }
            }
        }
    }
}
