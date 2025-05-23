using System;
using System.Security;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

using FfiHandleId = System.IntPtr;

namespace LiveKit.Internal
{
    [SuppressUnmanagedCodeSecurity]
    public static class NativeMethods
    {
        #if UNITY_IOS
        const string Lib = "__Internal";
        #else
        const string Lib = "livekit_ffi";
        #endif

        const string nobo_lib = "nobodywho_unity";

        [DllImport(Lib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "livekit_ffi_drop_handle")]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        internal extern static bool FfiDropHandle(FfiHandleId handleId);

        [DllImport(Lib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "livekit_ffi_request")]
        internal extern static unsafe FfiHandleId FfiNewRequest(byte* data, int len, out byte* dataPtr, out UIntPtr dataLen);

        [DllImport(nobo_lib, CallingConvention = CallingConvention.Cdecl) ]
        public extern static void init_tracing();

        [DllImport(Lib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "livekit_ffi_initialize")]
        internal extern static FfiHandleId LiveKitInitialize(FFICallbackDelegate cb, bool captureLogs, string sdk, string sdkVersion);
    }
}