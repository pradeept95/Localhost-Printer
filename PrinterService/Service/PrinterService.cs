using System;
using System.IO;
using System.Runtime.InteropServices;

namespace HotBag.AspNetCore.WebPrintService.Service
{
    public class PrinterService
    {
        [DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, SetLastError = true, ExactSpelling = true)]
        public static extern bool ClosePrinter(IntPtr hPrinter);
        [DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, SetLastError = true, ExactSpelling = true)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);
        [DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, SetLastError = true, ExactSpelling = true)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, int dwCount, string DocName)
        {
            int num = 0;
            int dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool flag = false;
            di.pDocName = DocName;
            di.pDataType = "RAW";
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    if (StartPagePrinter(hPrinter))
                    {
                        flag = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            if (!flag)
            {
                num = Marshal.GetLastWin32Error();
            }
            return flag;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName, string DocName)
        {
            FileStream input = new FileStream(szFileName, FileMode.Open);
            byte[] buffer = new byte[input.Length];
            bool flag = false;
            IntPtr destination = new IntPtr(0);
            int cb = Convert.ToInt32(input.Length);
            destination = Marshal.AllocCoTaskMem(cb);
            Marshal.Copy(new BinaryReader(input).ReadBytes(cb), 0, destination, cb);
            flag = SendBytesToPrinter(szPrinterName, destination, cb, DocName);
            Marshal.FreeCoTaskMem(destination);
            return flag;
        }

        public static bool SendStringToPrinter(string szPrinterName, string szString, string DocName)
        {
            IntPtr pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            SendBytesToPrinter(szPrinterName, pBytes, szString.Length, DocName);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);
        [DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, SetLastError = true, ExactSpelling = true)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, SetLastError = true, ExactSpelling = true)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

        [StructLayout(LayoutKind.Sequential)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
    }

}
