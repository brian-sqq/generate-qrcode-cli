using System.Text;
using Net.Codecrete.QrCodeGenerator;

namespace generate_qrcode;
class Program
{
    static void Main(string[] args)
    {
        string url = "";
        string qrFileName = "";

        if (args.Length > 0 && (args[0] == "-h" || args[0] == "--help" || args.Length > 2))
        {
            printUsage();
            Environment.Exit(0);
        }
        else if (args.Length == 2)
        {
            url = args[0];
            qrFileName = args[1];
        }
        else if (args.Length == 1)
        {
            url = args[0];
            qrFileName = askForFileName();
        }
        else if (args.Length == 0)
        {
            url = askForUrl();
            qrFileName = askForFileName();
        }

        var qr = QrCode.EncodeText(url, QrCode.Ecc.Medium);

        if (qrFileName.EndsWith(".svg"))
        {
            string svg = qr.ToSvgString(4);
            File.WriteAllText(qrFileName, svg, Encoding.UTF8);
        }
        else if (qrFileName.EndsWith(".png"))
        {
            qr.SaveAsPng(qrFileName, 10, 3);
        }
        else
        {
            Console.WriteLine($"ERROR: The filename must end in .svg or .png.  You provided {qrFileName}.");
            Environment.Exit(1);
        }

        Console.WriteLine($"Generated {qrFileName} for {url}.");
    }

    private static string askForUrl()
    {
        Console.WriteLine("What text (e.g. URL) would you like to encode?");
        try
        {
            string _url = Console.ReadLine();
            if (string.IsNullOrEmpty(_url))
            {
                printUsage();
                Environment.Exit(1);
            }
            return _url;
        }
        catch (Exception)
        {
            printUsage();
            Environment.Exit(1);
        }
        return null;
    }

    private static string askForFileName()
    {
        Console.WriteLine("What do you want the output file to be called (must end with .svg or .png)?");
        try
        {
            string _qrFileName = Console.ReadLine();
            if (string.IsNullOrEmpty(_qrFileName))
            {
                printUsage();
                Environment.Exit(1);
            }
            return _qrFileName;
        }
        catch (Exception)
        {
            printUsage();
            Environment.Exit(1);
        }
        return null;
    }

    private static void printUsage()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("  Provide 2 arguments, the text (e.g. URL) and the output filename (.svg or .png) for the QR code.");
    }
}
