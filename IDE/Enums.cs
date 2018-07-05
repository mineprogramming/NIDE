namespace NIDE
{
    public enum ImageType
    {
        ITEMS_OPAQUE,
        TERRAIN_ATLAS
    }

    public enum ProjectType
    {
        MODPE,
        COREENGINE,
        INNERCORE
    }

    public enum DialogType
    {
        SCRIPT,
        TEXTURE,
        LIBRARY
    }

    public enum ErrorHighlightStrategy
    {
        UNDERLINE,
        LINE_NUMBER
    }

    public enum StartDialogResult
    {
        OPEN,
        NEW,
        RECENT,
        IMPORT_ICMOD,
        IMPORT_MODPKG
    }
}