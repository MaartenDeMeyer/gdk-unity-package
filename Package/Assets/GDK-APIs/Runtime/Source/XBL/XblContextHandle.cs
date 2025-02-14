﻿using System;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblContextHandle : EquatableHandle
    {
        #region CALLBACKS
        [MonoPInvokeCallback]
        private static unsafe void XblMultiplayerSessionChangedCallback(
            IntPtr context,
            Interop.XblMultiplayerSessionChangeEventArgs args
            )
        {
            GCHandle contextHandle = GCHandle.FromIntPtr(context);
            ((XblContextHandle)contextHandle.Target).sessionChangedCallback?.Invoke(new XblMultiplayerSessionChangeEventArgs(args));
        }

        [MonoPInvokeCallback]
        private static unsafe void XblMultiplayerSessionSubscriptionLostCallback(
            IntPtr context
            )
        {
            GCHandle contextHandle = GCHandle.FromIntPtr(context);
            ((XblContextHandle)contextHandle.Target).sessionSubscriptionLostCallback?.Invoke();
        }

        [MonoPInvokeCallback]
        private static unsafe void XblMultiplayerConnectionIdChangedCallback(
            IntPtr context
            )
        {
            GCHandle contextHandle = GCHandle.FromIntPtr(context);
            ((XblContextHandle)contextHandle.Target).connectionIdChangedCallback?.Invoke();
        }
        #endregion

        public event SDK.XBL.XblMultiplayerSessionChangedHandler XblMultiplayerSessionChanged
        {
            add
            {
                if (sessionChangedCallback == null)
                {
                    sessionChangedHandlerId = XblInterop.XblMultiplayerAddSessionChangedHandler(this.InteropHandle, XblMultiplayerSessionChangedCallback, GCHandle.ToIntPtr(m_gCHandle));
                }
                sessionChangedCallback += value;
            }
            remove
            {
                sessionChangedCallback -= value;
                if (sessionChangedCallback == null)
                {
                    XblInterop.XblMultiplayerRemoveSessionChangedHandler(this.InteropHandle, sessionChangedHandlerId);
                    sessionChangedHandlerId = default(XblFunctionContext);
                }
            }
        }

        public event SDK.XBL.XblMultiplayerSessionSubscriptionLostHandler XblMultiplayerSessionSubscriptionLost
        {
            add
            {
                if (sessionSubscriptionLostCallback == null)
                {
                    sessionSubscriptionLostId = XblInterop.XblMultiplayerAddSubscriptionLostHandler(this.InteropHandle, XblMultiplayerSessionSubscriptionLostCallback, GCHandle.ToIntPtr(m_gCHandle));
                }
                sessionSubscriptionLostCallback += value;
            }
            remove
            {
                sessionSubscriptionLostCallback -= value;
                if (sessionSubscriptionLostCallback == null)
                {
                    XblInterop.XblMultiplayerRemoveSubscriptionLostHandler(this.InteropHandle, sessionSubscriptionLostId);
                    sessionSubscriptionLostId = default(XblFunctionContext);
                }
            }
        }

        public event SDK.XBL.XblMultiplayerConnectionIdChangedHandler XblMultiplayerConnectionIdChanged
        {
            add
            {
                if (connectionIdChangedCallback == null)
                {
                    connectionIdChangedId = XblInterop.XblMultiplayerAddConnectionIdChangedHandler(this.InteropHandle, XblMultiplayerConnectionIdChangedCallback, GCHandle.ToIntPtr(m_gCHandle));
                }
                connectionIdChangedCallback += value;
            }
            remove
            {
                connectionIdChangedCallback -= value;
                if (connectionIdChangedCallback == null)
                {
                    XblInterop.XblMultiplayerRemoveConnectionIdChangedHandler(this.InteropHandle, connectionIdChangedId);
                    connectionIdChangedId = default(XblFunctionContext);
                    m_gCHandle.Free();
                }
            }
        }

        internal XblContextHandle(Interop.XblContextHandle interopHandle)
        {
            this.InteropHandle = interopHandle;
        }

        internal override IntPtr GetInternalPtr()
        {
            return InteropHandle.handle;
        }

        internal Interop.XblContextHandle InteropHandle { get; set; }

        internal GCHandle m_gCHandle;

        internal SDK.XBL.XblMultiplayerSessionChangedHandler sessionChangedCallback;
        internal XblFunctionContext sessionChangedHandlerId;

        internal SDK.XBL.XblMultiplayerSessionSubscriptionLostHandler sessionSubscriptionLostCallback;
        internal XblFunctionContext sessionSubscriptionLostId;

        internal SDK.XBL.XblMultiplayerConnectionIdChangedHandler connectionIdChangedCallback;
        internal XblFunctionContext connectionIdChangedId;
    }
}
