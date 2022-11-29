namespace Main;

public class Preprocessors
{
    string OS()
    {
#if WIN32
        string os = "Win32";
#warning This class is bad.
#error Okay, just stop.
#elif MACOS
        string os = "MacOS";
#else
        string os = "Unknown";
#endif
        return os;
    }
}