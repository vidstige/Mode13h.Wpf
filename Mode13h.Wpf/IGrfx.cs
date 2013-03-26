namespace Mode13h.Wpf
{
    interface IGrfx
    {
        byte[] Screen { get; }
        void VRetrace();
        
        byte[] Load(string path, out int width, out int height, out int stride);

        bool Done { get; }
    }
}
