using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    public static unsafe partial class XboxLiveContext
    {
        [DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblContextDuplicateHandle([NativeTypeName("XblContextHandle")] IntPtr xboxLiveContextHandle, [NativeTypeName("XblContextHandle *")] IntPtr* duplicatedHandle);

        [DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblContextGetUser([NativeTypeName("XblContextHandle")] IntPtr context, [NativeTypeName("XblUserHandle *")] IntPtr* user);

        [DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblContextGetXboxUserId([NativeTypeName("XblContextHandle")] IntPtr context, [NativeTypeName("uint64_t *")] ulong* xboxUserId);
    }
}
