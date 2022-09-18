using System;
using System.Runtime.InteropServices;

namespace CurrencyCalculatorClient.Infrastructure.Extensions
{
    public static class StructMarshallingExtensions
    {
        /// <summary>
        /// Gets the bytes array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="structAry">The structure ary.</param>
        /// <returns>byte[]</returns>
        public static byte[] GetBytesArray<T>(this T[] structAry) where T : struct
        {
            int len = structAry.Length;
            int size = Marshal.SizeOf(default(T));
            byte[] arr = new byte[size * len];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            for (int i = 0; i < len; ++i)
            {
                Marshal.StructureToPtr(structAry[i], ptr, true);
                Marshal.Copy(ptr, arr, i * size, size);
            }
            Marshal.FreeHGlobal(ptr);

            return arr;
        }

        /// <summary>
        /// Gets the bytes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str">The string.</param>
        /// <returns>byte[]</returns>
        public static byte[] GetBytes<T>(this T str) where T : struct
        {
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);

            return arr;
        }

        /// <summary>
        /// Froms the bytes array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">The arr.</param>
        /// <returns>t[]</returns>
        public static T[] FromBytesArray<T>(this byte[] arr) where T : struct
        {
            int size = Marshal.SizeOf(default(T));
            int len = arr.Length / size;
            T[] result = new T[len];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            for (int i = 0; i < len; ++i)
            {
                Marshal.Copy(arr, i * size, ptr, size);
                result[i] = (T)Marshal.PtrToStructure(ptr, typeof(T));
            }
            Marshal.FreeHGlobal(ptr);

            return result;
        }

        /// <summary>
        /// Froms the bytes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">The arr.</param>
        /// <returns>T</returns>
        public static T FromBytes<T>(this byte[] arr) where T : struct
        {
            T str = default;

            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = (T)Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str; ;
        }
    }
}
